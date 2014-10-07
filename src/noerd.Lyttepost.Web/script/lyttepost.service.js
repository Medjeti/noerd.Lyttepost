angular.module('lyttepost')
    .factory('lpService', ['$http', lpService]);

function lpService($http) {

    var service = {
        getItems: getItems
    }
    return service;

    // ---------------------------------------------------------

    function getItems(query, callback) {
        //return $http.get("/services/dealers.json");

        $http.get("/api/Message/GetMessages/?q=" + escape(query)).
            success(function (data, status, headers, config) {
                //$scope.data = data;
                callback(data);
            }).
            error(function (data, status, headers, config) {
                alert("Årh hvad, det er gået totalt i kage... :(");
                // log error
            });
    }
}