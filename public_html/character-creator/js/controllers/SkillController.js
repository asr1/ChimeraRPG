app.controller('SkillController', function($scope, $http) {
    $scope.remaining = 5;
    $http.get('data/skills.json').then(success => {
        $scope.skills = success.data.skills;
    }, err => {
        console.log(err);
    });
});