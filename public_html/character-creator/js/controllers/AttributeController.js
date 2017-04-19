app.controller('AttributeController', function($scope, $http, $rootScope) {
    $http.get('data/attributes.json').then(success => {
        $scope.attributes = success.data.attributes;
    }, err => {
        console.log(err);
    });

    $scope.showHomebrew = false;

    $scope.textChange = function(lastValue, name) {
        $scope.showHomebrew = false;
        for(var index in $scope.attributes) {
            if($scope.attributes[index].value < 10 || $scope.attributes[index].value > 30) {
                $scope.showHomebrew = true;
                break;
            }
        }

        
        const modifiedAttr = $scope.attributes.filter(a => a.name === name)[0];
        const data = {
            newValue: calculateModifier(modifiedAttr.value),
            oldValue: calculateModifier(lastValue),
            attribute: modifiedAttr.name
        };

        $rootScope.$broadcast('attributeUpdated', data);
    };
});