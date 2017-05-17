"use strict";

let calculateModifier = function(value) {
    return ((value - (value % 10)) / 10);
}

let calculateValue = function(obj) {
    obj.value = 0;
    for(var prop in obj) {
        if(obj.hasOwnProperty(prop) && prop !== 'value') {
            obj.value += obj[prop];
        }
    }
}

let filterArrayByName = function(array, name) {
    let items = array.filter(a => a.name === name);
    
    if(items.length === 0) {
        return null;
    } else {
        return items[0];
    }
}

let findAbility = function(scope, abilityName) {
    let ability = null;
    const types = ['control', 'destruction', 'enhancement', 'utility'];   

    for(let i in types) {
        ability = filterArrayByName(scope.abilities[types[i]], abilityName);

        if(ability) {
            break;
        }
    }

    return ability;
}

let removeFromArray = function(array, item) {
    let index = array.indexOf(item);
    if(index !== -1) {
        array.splice(index, 1);
    }
}