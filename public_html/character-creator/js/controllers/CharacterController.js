app.controller('CharacterController', function($scope, $rootScope) {
    $scope.sizes = ["Small", "Medium", "Large"],
    $scope.size = $scope.sizes[1];

    //Default values
    $scope.hp = 30;
    $scope.movement = 5;
    $scope.ap = 100;
    $scope.apRegen = 20;
    $scope.fp = 2;
    $scope.initiative = 2;
    $scope.ep = 12;
    $scope.ac = {
        value: 10,
        attributeMod: 2
    };
    $scope.fort = 12;
    $scope.reflex = {
        value: 12,
        attributeMod: 2
    };
    $scope.will = 12;

    $scope.armorType = 'Light';
    $scope.armorChange = function(choice) {
        switch(choice) {
            case 'Light':

                break;
            case 'Heavy':

                break;
        }
    }

    $scope.useShield = false;
    $scope.shieldChange = function() {
        $scope.ac.value += $scope.useShield ? 1 : -1;        
        $rootScope.$broadcast('shieldChange', {shield: $scope.useShield});
    }

    $rootScope.$on('attributeUpdated', (event, args) => {
        switch(args.attribute) {
            case 'Constitution':
                $scope.hp = Math.floor(1.5 * args.newValue);
                $scope.fort = 10 + calculateModifier(args.newValue);
                break;
            case 'Intelligence':
                $scope.apRegen = args.newValue;
                break;
            case 'Wisdom':
                $scope.ap = 5 * args.newValue;
                $scope.will = 10 + calculateModifier(args.newValue);
                break;
            case 'Speed':
                $scope.movement = 3 + calculateModifier(args.newValue);
                $scope.initiative = calculateModifier(args.newValue);
                break;
            case 'Dexterity':

                break;
            case 'Luck':
                $scope.fp = calculateModifier(args.newValue);
                break;
        }
    });
});