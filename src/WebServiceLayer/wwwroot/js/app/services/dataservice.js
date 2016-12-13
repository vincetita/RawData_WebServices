define(['jquery', 'config'], function ($, config) {

    var getSearchHistory = function (callback) {
        var url = "api/history";
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    var getPaginationData = function (url, callback) {
        $.getJSON(url,
            function (data) {
                callback(data);
            });
    };

    var getAnnotation = function (callback) {
        var url = "api/owncomments";
        $.getJSON(url,
            function (data) {
                callback(data);
            });
    };

    var deleteHistory = function (url) {
        $.ajax({
            type: "DELETE",
            url: url
        });
    };

    return {
        getSearchHistory,
        getAnnotation,
        getPaginationData,
        deleteHistory
    };
});

