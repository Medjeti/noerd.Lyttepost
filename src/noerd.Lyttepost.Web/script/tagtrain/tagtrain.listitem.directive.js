angular.module("tagtrain")
    .directive("ttitems", ttItems);

function ttItems($compile) {
    var directive = {
        link: link,
        templateUrl: '/template/tagtrain.listitem.html',
        restrict: 'E',
        scope: {
            level: '=',
            tag: '=',
            items: '='
        }
    };

    return directive;

    // ---------------------------------------------------------

    function link(scope, element, attrs) {
        
        if (scope.level < 2) {

            var ul = element.find("ul");
            var li = ul.find("li");
            var placeholder = li.find("span");

            console.log(element);
        placeholder.remove();
        //element.append('<ttitems level="3" tag="\'nogleafos\'" items="subitems"></ttitems>');
        //    $compile(element.contents())(scope);

            $compile('<ttitems level="3" tag="\'nogleafos\'" items="subitems"></ttitems>')(scope, function (cloned, scope) {
                element.append(cloned);
            });

        }



        scope.subitems = [
            {
                Id: "823862225730872929_193050840",
                CreatorImage: "http://photos-e.ak.instagram.com/hphotos-ak-xfa1/10706864_339474102895372_692685891_a.jpg",
                CreatorName: "Louise Maria jensen",
                CreatorNick: "louisemariajensen",
                Id: "823862225730872929_193050840",
                Media: { Id: null },
                Place: null,
                Source: "Instagram",
                Tags: ["klitternegåramok", "fisse", "18års", "nogleafos"],
                Text: "Er klar til at fejre mine bedste damer @kamillalundjensen og @kristinalundjensen #18års #klitternegåramok #nogleafos #fisse @annevaldis @chelinabukdahl @louisevestergaardjacobsen @klyssing",
                Type: "image",
                URL: "http://instagram.com/p/tu8lRMjSZh/"
            }
        ];
    }

};