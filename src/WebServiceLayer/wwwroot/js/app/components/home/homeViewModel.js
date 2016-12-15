define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {

            var searchkeyword = ko.observable("");
            var total = ko.observable();
            var SearchPostsList = ko.observableArray([]);
            var prev = ko.observable();
            var next = ko.observable();

            var callback = function (data) {
                //console.log(data);

                total(data.total);
                SearchPostsList(data.data);
                prev(data.prev);
                next(data.next);
            };

            var searchRankPost = function () {
                dataService.getSearchPosts(searchkeyword(), callback);
            };

            var prevLink = function () {
                dataService.getPaginationData(prev(), callback);
            };

            var nextLink = function () {
                dataService.getPaginationData(next(), callback);
            };

            var nextPageUrl = ko.observable(params ? params.url : undefined);

            var postDetail = function (data) {
                //dataService.getPostDetail(data.url);
                postman.publish(config.events.searchPosts, { postToSend: data, url: data.url });
            };

            return {
                searchkeyword,
                searchRankPost: searchRankPost,
                SearchPostsList: SearchPostsList,
                prevLink: prevLink,
                nextLink: nextLink,
                postDetail: postDetail
                
            };
        };
    });



