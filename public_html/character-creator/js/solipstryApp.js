var calculateModifier = (value) => { return ((value - (value % 10)) / 10); }

var app = angular.module("solipstryApp", []);