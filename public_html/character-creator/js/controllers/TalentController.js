app.controller('TalentController', function($scope, $http) {
    $scope.remaining = 1;
    $http.get('data/talents.json').then(success => {
        $scope.talents = success.data.talents;
    }, err => {
        console.log(err);
    });

    $scope.talentSelected = function($event, index) {
        const checkbox = $event.target;

        $scope.talents[index].selected = checkbox.checked;
        $scope.remaining += (checkbox.checked ? -1 : 1);
    }
});