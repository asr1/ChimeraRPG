app.controller('SkillController', function($scope, $http) {
    $scope.remaining = 5;
    $http.get('data/skills.json').then(success => {
        $scope.skills = success.data.skills;
    }, err => {
        console.log(err);
    });

    $scope.skillSelected = function($event, index) {
        const checkbox = $event.target;

        $scope.skills[index].value += (checkbox.checked ? 15 : -15);
        $scope.remaining += (checkbox.checked ? -1 : 1);
    };
});