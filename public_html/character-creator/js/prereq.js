"use strict";

let meetsAttributeRequirement = function(scope, attrName, value) {
    const attr = filterArrayByName(scope.attributes, attrName);
    return attr.value >= value;
}

let meetsSkillRequirement = function(scope, skillName, value) {
    const skill = filterArrayByName(scope.skills, skillName);
    return skill.value >= value;
}

let meetsTalentRequirement = function(scope, talentName) {
    const talent = filterArrayByName(scope.talents, talentName);
    return talent.selected;
}

let meetsAbilityRequirement = function(scope, abilityName) {
    let ability;
    const types = ['control', 'destruction', 'enhancement', 'utility'];   

    for(let i in types) {
        ability = filterArrayByName(scope.abilities[types[i]], abilityName);

        if(ability) {
            break;
        }
    }

    return ability.selected;
}