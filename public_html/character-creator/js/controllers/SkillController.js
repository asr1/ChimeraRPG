app.controller('SkillController', function($scope, $http) {
    $http.get('data/skills.json').then(success => {
        $scope.skills = success.data.skills;
    }, err => {
        console.log(err);
    });
});