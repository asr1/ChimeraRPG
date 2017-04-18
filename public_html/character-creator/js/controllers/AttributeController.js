app.controller('AttributeController', function($scope, $http) {
    $http.get('data/attributes.json').then(success => {
        $scope.attributes = success.data.attributes;
    }, err => {
        console.log(err);
    });

    $scope.showHomebrew = false;

    $scope.textChange = function() {
        $scope.showHomebrew = false;
        for(var index in $scope.attributes) {
            if($scope.attributes[index].value < 10 || $scope.attributes[index].value > 30) {
                $scope.showHomebrew = true;
                break;
            }
        }
    };
});