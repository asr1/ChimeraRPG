app.controller('AttributeController', function($scope, $http) {
    $http.get('data/attributes.json').then(success => {
        $scope.attributes = success.data.attributes;
    }, err => {
        console.log(err);
    });
});