angular.module("lyttepost", [])
    .directive("lpsearch", ["lpService", lpDirective]);

function lpDirective(lpService) {
    var directive = {
        link: link,
        templateUrl: '/template/lyttepost.html',
        restrict: 'E'
    };
    return directive;
    
    // ---------------------------------------------------------

    function link(scope, element, attrs) {
        scope.doSearch = doSearch;

        function doSearch() {
            var query = scope.searchTerm.replace("#", "");
            if (query == "")
                return;
            lpService.getItems(query, callback);

            function callback(data) {
                scope.items = data;
                console.log(data);
            }
        }
    }
    
};