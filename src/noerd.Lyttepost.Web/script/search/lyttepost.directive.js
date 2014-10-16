angular.module("lyttepost", ["ngSanitize"])
    .directive("lpsearch", ["lpService", lpDirective]);

function lpDirective(lpService) {
    var directive = {
        link: link,
        templateUrl: '/template/lyttepost.search.html',
        restrict: 'E'
    };
    return directive;
    
    // ---------------------------------------------------------

    function link(scope, element, attrs) {
        scope.doSearch = doSearch;
        scope.parseMessage = parseMessage;

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

        function parseMessage(txtIn) {
            var txtOut = txtIn;
            txtOut = replaceHashtags(txtOut);
            txtOut = replaceUrls(txtOut);
            return txtOut;
        }

        function replaceHashtags(txtIn) {
            var regEx = new RegExp("#([a-z]+)", "ig");
            var txtOut = txtIn.replace(regEx, "<a href='#'>#$1</a>");
            return txtOut;
        }

        function replaceUrls(txtIn) {
            var regEx = new RegExp("((http:\/\/)([\da-z-]+)\.([a-z]{2,6})([\/\.-]*)*\/?)", "ig");
            var txtOut = txtIn.replace(regEx, "<a href='$1'>$1</a>");
            return txtOut;
        }
    }
    
};