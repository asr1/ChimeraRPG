app.controller('AbilityController', function($scope, $http) {
    $http.get('data/abilities.json').then(success => {
        $scope.abilities = success.data.abilities;
    }, err => {
        console.log(err);
    });
});