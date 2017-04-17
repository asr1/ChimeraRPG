app.controller('TalentController', function($scope, $http) {
    $http.get('data/talents.json').then(success => {
        $scope.talents = success.data.talents;
    }, err => {
        console.log(err);
    });
});