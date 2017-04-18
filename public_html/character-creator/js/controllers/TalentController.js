app.controller('TalentController', function($scope, $http) {
    $scope.remaining = 1;
    $http.get('data/talents.json').then(success => {
        $scope.talents = success.data.talents;
    }, err => {
        console.log(err);
    });
});