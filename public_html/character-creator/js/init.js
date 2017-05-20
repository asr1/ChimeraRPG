let init = function($scope, $http) {
    $scope.loading = 0;
    
    //Skills
    $scope.skillsRemaining = 5;
    $scope.skillsLoading = true;
    $http.get('data/skills.json').then(success => {
        $scope.skills = success.data.skills;
        $scope.loading++;
    }, err => {
        console.log(err);
    });

    //Talents
    $scope.homebrewTalents = [];
    $scope.validTalents = [];
    $scope.talentsRemaining = 1;
    $http.get('data/talents.json').then(success => {
        $scope.talents = success.data.talents;
        $scope.loading++;
    }, err => {
        console.log(err);
    });

    //Abilities
    $scope.homebrewAbilities = [];
    $scope.validAbilities = [];
    $scope.controlRemaining = 1;
    $scope.destructionRemaining = 1;
    $scope.enhancementRemaining = 1;
    $scope.utilityRemaining = 1;
    $http.get('data/abilities.json').then(success => {
        $scope.abilities = success.data.abilities;
        $scope.loading++;
    }, err => {
        console.log(err);
    });

    //Attributes
    $scope.attributeHomebrew = 0;
    $http.get('data/attributes.json').then(success => {
        $scope.attributes = success.data.attributes;
        $scope.loading++;
    }, err => {
        console.log(err);
    });

    //Basic character info
    $scope.hp = {
        value: 30,
        fromAttr: 30,
        fromTalents: 0
    };
    $scope.movement = {
        value: 5,
        fromAttr: 2,
        fromTalents: 0,
        base: 3
    };
    $scope.ap = {
        value: 100,
        fromAttr: 100,
        fromTalents: 0
    };
    $scope.apRegen = {
        value: 20,
        fromAttr: 20,
        fromTalents: 0
    };
    $scope.fp = {
        value: 2,
        fromAttr: 20,
        fromTalents: 0
    };
    $scope.initiative = {
        value: 2,
        fromAttr: 2,
        fromTalents: 0
    };
    $scope.ep = {
        value: 12,
        fromSkill: 12,
        fromTalents: 0
    };
    $scope.ac = {
        value: 10,
        fromAttr: 2,
        fromSkill: 1,
        fromTalents: 0,
        shield: 0,
        base: 7
    };
    $scope.fort = {
        value: 12,
        fromAttr: 2,
        fromTalents: 0,
        base: 10
    };
    $scope.reflex = {
        value: 12,
        fromAttr: 2,
        fromSkill: 0,
        fromTalents: 0,
        fromSize: 0,
        base: 10
    };
    $scope.will = {
        value: 12,
        fromAttr: 2,
        fromTalents: 0,
        base: 10
    };

    $scope.sizes = ['Small', 'Medium', 'Large'],
    $scope.size = $scope.sizes[1];
    $scope.armorType = 'Light';
    $scope.showQualified = true;
    $scope.useShield = false;
    $scope.name = '';
    $scope.class = '';
    $scope.race = '';
    $scope.height = '';
    $scope.weight = '';
    $scope.age = '';
    $scope.occupation = '';
    $scope.aspiration = '';
    $scope.background = '';
}