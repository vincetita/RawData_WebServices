
define(['jquery', 'config', 'knockout'], function ($, config, ko) {
    
    //historyUrl: serverUrl + "/api/history",
    //postsmarkedUrl: serverUrl + "/api/markedposts",
    //owncommentsUrl: serverUrl + "/api/owncomments"

    var getSearchHistory = function (callback) {
        var url = config.serverApi.historyUrl;
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
        var url = config.serverApi.owncommentsUrl;
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
   
    var getWordCloud = function (searchValue, callback) {

        return $.ajax({
            type: "Get",
            url: "api/wordcloud?word=" + searchValue,
            dataType: 'json',
            contentType: "application/json",
            success: function (data) {
                callback(data);
            }

        });

    };

    var SearchpostsRankword = function (url, searchword, callback) {
        url = config.serverApi.searchUrl + searchword;
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    var postsLists = function (url, callback) {
        url = config.serverApi.postUrl;
        $.getJSON(url, function (data) {
            callback(data);
        });
    };


    return {
        getSearchHistory,
        getAnnotation,
        getPaginationData,
        deleteHistory,
        SearchpostsRankword,
        postsLists,
        getWordCloud

    };
});


