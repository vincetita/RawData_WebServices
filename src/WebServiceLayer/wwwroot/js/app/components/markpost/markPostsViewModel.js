define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function () {
            var markPostList = ko.observableArray([]);
            var prev = ko.observable();
            var next = ko.observable();

            var callback = function (data) {
                markPostList(data.data);
                prev(data.prev);
                next(data.next);
            };

            dataService.getMarkPosts(callback);


            var prevLink = function () {
                dataService.getPaginationData(prev(), callback);
            };

            var nextLink = function () {
                dataService.getPaginationData(next(), callback);
            };

            return {
                markPostList: markPostList,
                prevLink: prevLink,
                nextLink: nextLink
            };
        };
    });

