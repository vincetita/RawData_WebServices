define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {
            var PostDetails = ko.observableArray([]);
            var annotationData = ko.observable();

            var callback = function (data) {
                console.log(data);
                PostDetails(data);
            };

            var postUrlReceived = params.url;
            var postIdForAnnotation = postUrlReceived.substr(postUrlReceived.lastIndexOf('/') + 1);

            var postReceived = params.postToSend;
            //console.log(postReceived);
            var title = postReceived.title;
            var rank = postReceived.rank;
            var body = postReceived.body;
            dataService.getPostDetailsFromDB(postUrlReceived, callback);

            var saveAnnotation = function () {
                var annotationToSendToDb = annotationData();
                //var date = new Date();
                var dateTime = new Date().toJSON().substring(0, 19).replace('T', ' ');
                console.log(dateTime);
                var annoationDataToSave = {
                    "postId": postIdForAnnotation,
                    "commentText": annotationToSendToDb,
                    "commentCreated": dateTime
                };

                dataService.sendannotationToSendToDb(annoationDataToSave);

                console.log(postIdForAnnotation);
            };
            return {
                PostDetails: PostDetails,
                postReceived: postReceived,
                title: title,
                rank: rank,
                body: body,
                saveAnnotation,
                annotationData

            };
        };
    });
