app.controller('SkillController', function($scope, $http, $rootScope) {
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

    $rootScope.$on('attributeUpdated', (event, args) => {
        for(var index in $scope.skills) {
            let s = $scope.skills[index];

            if(s.attribute !== args.attribute) {
                continue;
            }

            s.value -= calculateModifier(args.oldValue);
            s.value += calculateModifier(args.newValue);
        }
    });

    $rootScope.$on('shieldChange', (event, args) => {
        $scope.skills.filter(s => s.name === 'Block')[0].value += (args.shield ? 5 : -5);
    });
});