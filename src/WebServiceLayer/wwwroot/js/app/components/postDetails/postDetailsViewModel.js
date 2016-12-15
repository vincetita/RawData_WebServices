define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
            var PostDetails = ko.observableArray([]);

            var callback = function (data) {
                console.log(data);
                PostDetails(data);
            };

            var postUrlReceived = params.url;
            

            var postReceived = params.postToSend;
            console.log(postReceived);
            var title = postReceived.title;
            var rank = postReceived.rank;
            var body = postReceived.body;
            dataService.getPostDetailsFromDB(postUrlReceived, callback);

            return {
                PostDetails: PostDetails,
                postReceived: postReceived,
                title: title,
                rank: rank,
                body:body
            };
        };
    });
