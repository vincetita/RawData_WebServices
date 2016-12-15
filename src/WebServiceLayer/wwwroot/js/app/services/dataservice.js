
define(['jquery', 'config', 'knockout'], function ($, config, ko) {
    
    //historyUrl: serverUrl + "/api/history",
    //postsmarkedUrl: serverUrl + "/api/markedposts",
    //owncommentsUrl: serverUrl + "/api/owncomments"
    //searchUrl: serverUrl + "/api/rankword?rankword=",

    var getSearchPosts = function (searchword, callback) {
        var url = config.serverApi.searchUrl + searchword;
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

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

    //var SearchpostsRankword = function (url, searchword, callback) {
    //    url = config.serverApi.searchUrl + searchword;
    //    $.getJSON(url, function (data) {
    //        callback(data);
    //    });
    //};

    var postsLists = function (url, callback) {
        url = config.serverApi.postUrl;
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    var getPostDetail = function (url, callback) {
        $.getJSON(url, function (data){
            callback(data);
        });
    };

    var getPostDetailsFromDB = function (url, callback) {
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    return {
        getSearchPosts,
        getSearchHistory,
        getAnnotation,
        getPaginationData,
        deleteHistory,
        //SearchpostsRankword,
        postsLists,
        getPostDetailsFromDB

    };
});


