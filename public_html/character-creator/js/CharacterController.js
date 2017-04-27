let calculateValue = function(obj) {
    obj.value = 0;
    for(var prop in obj) {
        if(obj.hasOwnProperty(prop) && prop !== 'value') {
            obj.value += obj[prop];
        }
    }
}

app.controller('CharacterController', function($scope, $rootScope, $http) {
    //Skills
    $scope.skillsRemaining = 5;
    $http.get('data/skills.json').then(success => {
        $scope.skills = success.data.skills;
    }, err => {
        console.log(err);
    });

    $scope.skillSelected = function($event, index) {
        const checkbox = $event.target;

        const skill = $scope.skills[index];

        skill.value += (checkbox.checked ? 15 : -15);
        $scope.skillsRemaining += (checkbox.checked ? -1 : 1);

        const value = skill.value;
        const mod = calculateModifier(value);

        switch(skill.name) {
            case 'Enlightenment':
                $scope.ep.fromSkill = value;
                calculateValue($scope.ep);

                break;
        }
    };

    //Talents
    $scope.talentsRemaining = 1;
    $http.get('data/talents.json').then(success => {
        $scope.talents = success.data.talents;
    }, err => {
        console.log(err);
    });

    $scope.talentSelected = function($event, index) {
        const checkbox = $event.target;

        $scope.talents[index].selected = checkbox.checked;
        $scope.talentsRemaining += (checkbox.checked ? -1 : 1);
    };
    
    //Abilities
    $scope.controlRemaining = 1;
    $scope.destructionRemaining = 1;
    $scope.enhancementRemaining = 1;
    $scope.utilityRemaining = 1;
    $http.get('data/abilities.json').then(success => {
        $scope.abilities = success.data.abilities;
    }, err => {
        console.log(err);
    });

    $scope.abilitySelected = function($event, index, type) {
        const checkbox = $event.target;

        $scope.abilities[type][index].selected = checkbox.checked;
        $scope[type + "Remaining"] += (checkbox.checked ? -1 : 1);
    };

    //Attributes
    $scope.attributeHomebrew = 0;
    $http.get('data/attributes.json').then(success => {
        $scope.attributes = success.data.attributes;
    }, err => {
        console.log(err);
    });

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
            case 'Constitution':
                $scope.hp.fromAttr = Math.floor(1.5 * value);
                calculateValue($scope.hp);


                break;
            case 'Dexterity':

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

                break;
            case 'Strength':

                break;
            case 'Wisdom':
                $scope.ap.fromAttr = 5 * value;
                calculateValue($scope.ap);

                break;
        }
    };

    //Basic character info
    $scope.sizes = ["Small", "Medium", "Large"],
    $scope.size = $scope.sizes[1];
    $scope.hp = {
        value: 30,
        fromAttr: 30,
        fromTalents: 0
    };
    $scope.movement = {
        value: 5,
        fromAttr: 2,
        fromTalents: 0,
        base: 3
    };
    $scope.ap = {
        value: 100,
        fromAttr: 100,
        fromTalents: 0
    };
    $scope.apRegen = {
        value: 20,
        fromAttr: 20,
        fromTalents: 0
    };
    $scope.fp = {
        value: 2,
        fromAttr: 20,
        fromTalents: 0
    };
    $scope.initiative = {
        value: 2,
        fromAttr: 2,
        fromTalents: 0
    };
    $scope.ep = {
        value: 12,
        fromSkill: 12,
        fromTalents: 0
    };
    $scope.ac = {
        value: 10,
        fromAttr: 2,
        fromSkill: 1,
        fromTalents: 0,
        shield: 0,
        base: 7
    };
    $scope.fort = {
        value: 12,
        fromAttr: 2,
        fromTalents: 0,
        base: 10
    };
    $scope.reflex = {
        value: 12,
        fromAttr: 2,
        fromSkill: 0,
        fromTalents: 0,
        base: 10
    };
    $scope.will = {
        value: 12,
        fromAttr: 2,
        fromTalents: 0,
        base: 10
    };

    $scope.armorType = 'Light';
    $scope.armorChange = function(choice) {
       
    };

    $scope.useShield = false;
    $scope.shieldChange = function() {
        $scope.ac.shield = +$scope.useShield;
        calculateValue($scope.ac);

        let blockSkill = $scope.skills.filter(s => s.name === 'Block')[0];
        blockSkill.value += $scope.useShield ? 5 : -5;
    };
});