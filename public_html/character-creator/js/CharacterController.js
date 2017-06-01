let skillChange = function(scope, name) {
    let skill = scope.skills.filter(s => s.name === name)[0];
    const value = skill.value;
    const mod = calculateModifier(value);

    switch(name) {
        case 'Enlightenment':
            scope.ep.fromSkill = value;
            calculateValue(scope.ep);
            
            if(scope.fp.fromTalents !== 0) {
                scope.fp.fromTalents = Math.floor(mod / 2.0);
                calculateValue(scope.fp);
            }
            
            break;
        case 'Light armor':
            scope.ac.fromSkill = mod;
            calculateValue(scope.ac);

            break;
        case 'Heavy armor':
            scope.ac.fromSkill = mod;
            calculateValue(scope.ac);

            break;
        case 'Control':
            scope.controlMax = mod;

            break;
        case 'Destruction':
            scope.destructionMax = mod;

            break;
        case 'Enhancement':
            scope.enhancementMax = mod;

            break;
        case 'Utility':
            scope.utilityMax = mod;

            break;
    }
}

let checkHomebrew = function(scope) {
    let newHomebrewTalents = [];
    for(let i in scope.validTalents) {
        const talentName = scope.validTalents[i];
        if(!scope.canTake(talentName)) {
            removeFromArray(scope.validTalents, talentName);
            newHomebrewTalents.push(talentName);
        }
    }

    let newValidTalents = [];
    for(let i in scope.homebrewTalents) {
        const talentName = scope.homebrewTalents[i];
        if(scope.canTake(talentName)) {
            removeFromArray(scope.homebrewTalents, talentName);
            newValidTalents.push(talentName);
        }
    }

    let newHomebrewAbilities = [];
    for(let i in scope.validAbilities) {
        const abilityName = scope.validAbilities[i];
        if(!scope.canTake(abilityName)) {
            removeFromArray(scope.validAbilities, abilityName);
            newHomebrewAbilities.push(abilityName);
        }
    }

    let newValidAbilities = [];
    for(let i in scope.homebrewAbilities) {
        const abilityName = scope.homebrewAbilities[i];
        if(scope.canTake(abilityName)) {
            removeFromArray(scope.homebrewAbilities, abilityName);
            newValidAbilities.push(abilityName);
        }
    }

    scope.homebrewTalents = scope.homebrewTalents.concat(newHomebrewTalents);
    scope.validTalents = scope.validTalents.concat(newValidTalents);
    scope.homebrewAbilities = scope.homebrewAbilities.concat(newHomebrewAbilities);
    scope.validAbilities = scope.validAbilities.concat(newValidAbilities);
}

app.controller('CharacterController', function($scope, $http, $uibModal) {    
    init($scope, $http);

    $scope.submit = function() {
        let abilities = [];
        const takenAbilities = $scope.homebrewAbilities.concat($scope.validAbilities);
        for(let i in takenAbilities) {
            const ability = findAbility($scope, takenAbilities[i]);
            abilities.push({
                name: ability.name,
                cost: ability.cost,
                effect: ability.short,
                school: ability.type
            });
        }

        let talents = $scope.homebrewTalents.concat($scope.validTalents);

        let skills = {};
        for(let i in $scope.skills) {
            const skill = $scope.skills[i];
            skills[skill.name.replace(' ', '_').replace(' ', '_').replace('/', '_')] = {
                score: skill.value,
                mod: calculateModifier(skill.value)
            };
        }

        let attributes = {};
        for(let i in $scope.attributes) {
            const attr = $scope.attributes[i];
            attributes[attr.abbreviation] = {
                score: attr.value,
                mod: calculateModifier(attr.value)
            };
        }

        let data = {
            name: $scope.name,
            size: $scope.size,
            class: $scope.class,
            race: $scope.race,
            height: $scope.height,
            weight: $scope.weight,
            age: $scope.age,
            occupation: $scope.occupation,
            aspiration: $scope.aspiration,
            background: $scope.background,
            hp: $scope.hp.value,
            movement: $scope.movement.value,
            initiative: $scope.initiative.value,
            ap: $scope.ap.value,
            apRegen: $scope.apRegen.value,
            ep: $scope.ep.value,
            fort: $scope.fort.value,
            reflex: $scope.reflex.value,
            will: $scope.will.value,
            ac: $scope.ac.value,
            fp: $scope.fp.value,
            skills: skills,
            abilities: abilities,
            talents: talents,
            attributes: attributes
        };
        $http.get('create-sheet.php?character=' + JSON.stringify(data)).then(res => {
            window.open(res.data);
        });
    }

    $scope.skillSelected = function($event, index) {
        const checkbox = $event.target;

        const skill = $scope.skills[index];

        skill.value += (checkbox.checked ? 15 : -15);
        $scope.skillsRemaining += (checkbox.checked ? -1 : 1);

        const value = skill.value;
        const mod = calculateModifier(value);

        skillChange($scope, skill.name);

        checkHomebrew($scope);
    };

    $scope.talentSelected = function($event, index) {
        const checkbox = $event.target;
        const talent = $scope.talents[index];

        $scope.talentsRemaining += (checkbox.checked ? -1 : 1);

        if(checkbox.checked) {
            const valid = $scope.canTake(talent.name);

            if(talent.multiple) {
                $scope.talents.splice(index, 0, talent);
            }

            if(valid) {
                $scope.validTalents.push(talent.name);
            } else {
                $scope.homebrewTalents.push(talent.name);
            }
        } else {
            removeFromArray($scope.validTalents, talent.name);
            removeFromArray($scope.homebrewTalents, talent.name);

            if(talent.multiple) {
                $scope.talents.splice(index, 1);
            }
        }

        let update;

        switch(talent.name) {
            case 'Devout Follower':
                $scope.ep.fromTalents += (checkbox.checked ? 10 : -10);
                calculateValue($scope.ep);

                break;
            case 'Devout Gambler':
                if(checkbox.checked) {
                    const mod = calculatMod(filterArrayByName($scope.skills, 'Enlightenment').value);
                    $scope.fp.fromTalents = Math.floor(mod / 2.0);
                    calculateValue($scope.fp);
                } else {
                    $scope.fp.fromTalents = 0;
                    calculateValue($scope.fp);
                }

                break;
            case 'Improved Defense':
                let defenseList = checkbox.checked ? ['Armor Class', 'Fortitude', 'Reflex', 'Will'] : $scope.improvedDefense;

                $uibModal.open({
                    templateUrl: 'selector-modal.html',
                    size: 'sm',
                    controller: function($scope) {
                        $scope.title = 'Improved Defense';
                        $scope.list = defenseList;
                        $scope.selected = function(item) {
                            $scope.$close(item);
                        }
                    }
                }).result.then(item => {
                    let def;
                    switch(item) {
                        case 'Armor Class':
                            def = 'ac';
                            break;
                        case 'Fortitude':
                            def = 'fort';
                            break;
                        case 'Reflex':
                            def = 'reflex';
                            break;
                        case 'Will':
                            def = 'will';
                            break;
                    }

                    $scope[def].fromTalents += checkbox.checked ? 1 : -1;
                    calculateValue($scope[def]);

                    if(checkbox.checked) {
                        $scope.improvedDefense.push(item);
                    } else {
                        removeFromArray($scope.improvedDefense, item);
                    }
                });

                break;
            case 'Skill Specialization':                
                let skillList = checkbox.checked ? $scope.skillNames : $scope.skillSpecialization;

                $uibModal.open({
                    templateUrl: 'selector-modal.html',
                    size: 'sm',
                    controller: function($scope) {
                        $scope.title = 'Skill Specialization';
                        $scope.list = skillList;
                        $scope.selected = function(item) {
                            $scope.$close(item);
                        }
                    }
                }).result.then(item => {
                    let skill = filterArrayByName($scope.skills, item);
                    skill.value += checkbox.checked ? 6 : -6;

                    if(checkbox.checked) {
                        $scope.skillSpecialization.push(item);
                    } else {
                        removeFromArray($scope.skillSpecialization, item);
                    }

                    skillChange($scope, item);
                });
                
                break;
            case 'Studious':
                let abilities;

                if(checkbox.checked) { 
                    abilities = [];
                    let addToList = type => {
                        for(let i in type) {
                            if(!type[i].selected && $scope.canTake(type[i].name)) {
                                abilities.push(type[i].name);
                            }
                        }
                    };
                    addToList($scope.abilities.control);
                    addToList($scope.abilities.enhancement);
                    addToList($scope.abilities.destruction);
                    addToList($scope.abilities.utility);
                } else {
                    abilities = $scope.studious;
                }

                $uibModal.open({
                    templateUrl: 'selector-modal.html',
                    size: 'sm',
                    controller: function($scope) {
                        $scope.title = 'Studious';
                        $scope.list = abilities;
                        $scope.selected = function(item) {
                            $scope.$close(item);
                        }
                    }
                }).result.then(item => {
                    let a = findAbility($scope, item);
                    $scope[a.type + 'Taken'] += (checkbox.checked ? 1 : -1);
                    a.selected = checkbox.checked;
                    a.studious = checkbox.checked ? true : undefined;
                    
                    if(checkbox.checked) {
                        $scope.studious.push(a.name);
                        $scope.validAbilities.push(a.name);
                    } else {
                        removeFromArray($scope.studious, a.name);
                        removeFromArray($scope.validAbilities, a.name);
                    }   
                });

                break;
            case 'Improved Initiative':
                $scope.initiative.fromTalents += (checkbox.checked ? 3 : -3);
                calculateValue($scope.initiative);

                break;
            case 'Improved Recharge':
                $scope.apRegen.fromTalents += (checkbox.checked ? 5 : -5);
                calculateValue($scope.apRegen);

                break;
            case 'More Efficient, Less Wasteful':
                update = a => a.cost *= (checkbox.checked ? 0.5 : 2);

                for(let i in $scope.abilities.control) {
                    update($scope.abilities.control[i]);
                }
                for(let i in $scope.abilities.destruction) {
                    update($scope.abilities.destruction[i]);
                }
                for(let i in $scope.abilities.enhancement) {
                    update($scope.abilities.enhancement[i]);
                }
                for(let i in $scope.abilities.utility) {
                    update($scope.abilities.utility[i]);
                }

                break;
            case 'Quick Steps':
                $scope.movement.fromTalents += (checkbox.checked ? 1 : -1);
                calculateValue($scope.movement);

                break;
            case 'Resilience':
                const change = (checkbox.checked ? 1 : -1);
                update = d => {
                    d.fromTalents += change;
                    calculateValue(d);
                };
                update($scope.fort);
                update($scope.reflex);
                update($scope.will);

                break;
            case 'Resourcefulness':
                $scope.ap += (checkbox.checked ? 10 : -10);
                calculateValue($scope.ap);

                break;
            case 'Thick Skin':
                $scope.hp += (checkbox.checked ? 5 : -5);
                calculateValue($scope.hp);
        }

        checkHomebrew($scope);
    };

    $scope.abilitySelected = function($event, index, type) {
        const checkbox = $event.target;
        const ability = $scope.abilities[type][index];

        ability.selected = checkbox.checked;
        $scope[type + 'Taken'] += (checkbox.checked ? 1 : -1);

        if(checkbox.checked) {
            const valid = $scope.canTake(ability.name);

            if(valid) {
                $scope.validAbilities.push(ability.name);
            } else {
                $scope.homebrewAbilities.push(ability.name);
            }
        } else {
            removeFromArray($scope.validAbilities, ability.name);
            removeFromArray($scope.homebrewAbilities, ability.name);
        }

        checkHomebrew($scope);
    };

    $scope.attributeChange = function(lastValue, name) {
        const attr = $scope.attributes.filter(a => a.name === name)[0];
        const value = attr.value;
        const mod = calculateModifier(value);

        let skills = $scope.skills.filter(s => s.attribute === name);
        for(var i in skills) {
            skills[i].value -= calculateModifier(lastValue);
            skills[i].value += calculateModifier(attr.value);
        }

        switch(name) {
            case 'Charisma':
                skillChange($scope, 'Englightenment');

                break;
            case 'Constitution':
                $scope.hp.fromAttr = Math.floor(1.5 * value);
                calculateValue($scope.hp);

                $scope.fort.fromAttr = mod;
                calculateValue($scope.fort);

                if($scope.armorType === 'Heavy') {
                    $scope.ac.fromAttr = mod;
                    calculateValue($scope.ac);
                    skillChange($scope, 'Heavy armor');
                }

                break;
            case 'Dexterity':
                const speed = filterArrayByName($scope.attributes, 'Speed');
                const spdMod = calculateModifier(speed.value);

                if(mod >= spdMod) {
                    $scope.reflex.fromAttr = mod;
                    calculateValue($scope.reflex);
                }

                
                if($scope.armorType === 'Light' && mod >= spdMod) {
                    $scope.ac.fromAttr = mod;
                    calculateValue($scope.ac);
                }

                break;
            case 'Intelligence':
                $scope.apRegen.fromAttr = value;
                calculateValue($scope.apRegen);

                break;
            case 'Luck':
                $scope.fp.fromAttr = mod;
                calculateValue($scope.fp);

                break;
            case 'Speed':
                $scope.movement.fromAttr = mod;
                calculateValue($scope.movement);

                $scope.initiative.fromAttr = mod;
                calculateValue($scope.initiative);

                const dexterity = filterArrayByName($scope.attributes, 'Dexterity');
                const dexMod = calculateModifier(dexterity.value);

                if(mod >= dexMod) {
                    $scope.reflex.fromAttr = mod;
                    calculateValue($scope.reflex);
                }
                
                if($scope.armorType === 'Light' && mod >= dexMod) {
                    $scope.ac.fromAttr = mod;
                    calculateValue($scope.ac);
                }
                skillChange($scope, 'Light armor');

                break;
            case 'Strength':

                break;
            case 'Wisdom':
                $scope.ap.fromAttr = 5 * value;
                calculateValue($scope.ap);

                $scope.will.fromAttr = mod;
                calculateValue($scope.will);
                break;
        }

        checkHomebrew($scope);
    };

    $scope.canTake = function(itemName) {
        let item = filterArrayByName($scope.talents, itemName);
        if(!item) {
            item = findAbility($scope, itemName);
        }

        if(!item) {
            return false;
        }

        if(item instanceof Array) {
            for(let i in item) {
                const str = item[i];
                if(str === $scope.size) {
                    break;
                }
            }
        }

prereqLoop:
        for(let i in item.prereqs) {
            const p = item.prereqs[i];

            if(p instanceof Array) {
                for(let i in p) {
                    const str = p[i];
                    
                    if(str === $scope.size) {
                        continue prereqLoop;
                    }

                    const split = str.split(' ');
                    const req = filterArrayByName($scope.attributes, split[0]);
                    if(!req) {
                        continue;
                    }
                    if(req.value >= parseInt(split[1])) {
                        continue prereqLoop;
                    }
                }

                return false;
            }

            if(p === $scope.size) {
                continue;
            }

            let req = filterArrayByName($scope.talents, p);
            if(!req) {
                req = findAbility($scope, p);
            }
            if(req) {
                if(req.selected) {
                    continue;
                } else {
                    return false;
                }
            }

            const split = p.split(' ');

            req = filterArrayByName($scope.attributes, split[0]);
            if(!req) {
                req = filterArrayByName($scope.skills, split[0]);
            }
            if(req && req.value < parseInt(split[1])) {
                return false;
            }
        }

        return true;
    };
    
    $scope.sizeChange = function() {
        let stealth = filterArrayByName($scope.skills, 'Stealth');
        stealth.value -= $scope.sizeChange.lastStealthMod;

        let stealthMod = 0;
        switch($scope.size) {
            case 'Small':
                $scope.reflex.fromSize = 1;
                stealthMod = 5;

                break;
            case 'Medium':
                $scope.reflex.fromSize = 0;

                break;
            case 'Large':
                $scope.reflex.fromSize = -1;
                stealthMod = -5;

                break;
        }

        stealth.value += stealthMod;
        $scope.sizeChange.lastStealthMod = stealthMod;

        calculateValue($scope.reflex);

        checkHomebrew($scope);
    }
    $scope.sizeChange.lastStealthMod = 0;

    $scope.armorChange = function(choice) {
        const dex = calculateModifier($scope.attributes.filter(a => a.name === 'Dexterity')[0].value);
        const spd = calculateModifier($scope.attributes.filter(a => a.name === 'Speed')[0].value);

        switch($scope.armorType) {
            case 'Heavy':
                const heavyMod = calculateModifier(filterArrayByName($scope.skills, 'Heavy armor').value);
                $scope.ac.base = 12;
                $scope.ac.fromSkill = heavyMod;
                $scope.ac.fromAttr = calculateModifier(filterArrayByName($scope.attributes, 'Constitution').value);

                $scope.reflex.base = 5;
                $scope.reflex.fromAttr = Math.max(dex, spd);
                $scope.reflex.fromSkill = Math.floor(heavyMod / 2);
                
                break;
            case 'Light':
                $scope.ac.base = 7;
                $scope.ac.fromSkill = calculateModifier($scope.skills.filter(s => s.name === 'Light armor')[0].value);
                
                $scope.ac.fromAttr = Math.max(dex, spd);

                $scope.reflex.base = 10;
                $scope.reflex.fromSkill = 0;
                $scope.reflex.fromAttr = Math.max(dex, spd);

                break;
        }

        calculateValue($scope.ac);
        calculateValue($scope.reflex);

        checkHomebrew($scope); //Not sure this one is needed?
    };

    $scope.shieldChange = function() {
        $scope.ac.shield = +$scope.useShield;
        calculateValue($scope.ac);

        let blockSkill = $scope.skills.filter(s => s.name === 'Block')[0];
        blockSkill.value += $scope.useShield ? 5 : -5;

        checkHomebrew($scope); //Not sure this one is needed?
    };
});