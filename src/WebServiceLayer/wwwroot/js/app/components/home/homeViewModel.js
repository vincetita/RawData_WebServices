define(['knockout', 'dataservice', 'postman', 'config', 'jqcloud2'],
    function (ko, dataService, postman, config, jq) {
        return function (params) {

            var searchkeyword = ko.observable("");
            var total = ko.observable();
            var SearchPostsList = ko.observableArray([]);
            var prev = ko.observable();
            var next = ko.observable();

            var callback = function (data) {
              
                total(data.total);
                SearchPostsList(data.data);
                prev(data.prev);
                next(data.next);
                total(data.total);
            };

            var searchRankPost = function () {
                
                dataService.getSearchPosts(searchkeyword(), callback);
                
                dataService.getWordCloud(searchkeyword(), function (data) {
                    $('#wordcloud').jQCloud(data.data, {
                        classPattern: null,
                        colors: ["#0cf", "#0cf",
                        "#0cf", "#39d", "#90c5f0", "#90a0dd",
                        "#a0ddff", "#99ccee", "#aab5f0"],

                        fontSize: {
                            from: 0.15,
                            to: 0.03
                        }
                    });
                });

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
                searchkeyword: searchkeyword,
                searchRankPost: searchRankPost,
                SearchPostsList: SearchPostsList,
                prevLink: prevLink,
                nextLink: nextLink,
                postDetail: postDetail,
                total:total
                
            };
        };
    });



