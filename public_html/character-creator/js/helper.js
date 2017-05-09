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
    return array.filter(a => a.name === name)[0];
}