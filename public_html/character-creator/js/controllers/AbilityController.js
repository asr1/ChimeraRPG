app.controller('AbilityController', function($scope, $http) {
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
});