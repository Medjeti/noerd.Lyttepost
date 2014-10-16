angular.module('tagtrain', [])
    .controller("ttController", ttController);

function ttController($scope) {
    $scope.searchTerm = "";
    $scope.items = [
        //{
        //    Id: "823862225730872929_193050840",
        //    CreatorImage: "http://photos-e.ak.instagram.com/hphotos-ak-xfa1/10706864_339474102895372_692685891_a.jpg",
        //    CreatorName: "Louise Maria jensen",
        //    CreatorNick: "louisemariajensen",
        //    Id: "823862225730872929_193050840",
        //    Media: {Id:null},
        //    Place: null,
        //    Source: "Instagram",
        //    Tags: ["klitternegåramok", "fisse", "18års", "nogleafos"],
        //    Text: "Er klar til at fejre mine bedste damer @kamillalundjensen og @kristinalundjensen #18års #klitternegåramok #nogleafos #fisse @annevaldis @chelinabukdahl @louisevestergaardjacobsen @klyssing",
        //    Type: "image",
        //    URL: "http://instagram.com/p/tu8lRMjSZh/" 
        //}
    ];
}