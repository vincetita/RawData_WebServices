define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
        return function (params) {

            var PostDetails = ko.observableArray([]);
            var annotationData = ko.observable();

            var callback = function (data) {
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
                alert('Comments Saved! Click Comments from menu to see Comments list');
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

            //var MarkPost = function () {
            //    alert(config.serverApi.postsmarkedUrl + "/POST");
            //    //dataService.markPost(data.url);

            //    $.ajax({

            //        type: "POST",
            //        url: config.serverApi.postsmarkedUrl + "/POST",
            //        //  contentType: "application/json; charset=utf-8",
            //        data: { ids: $('#lblboliids').val() },
            //        traditional: true,
            //        dataType: "json",
            //        success: function (message) {

            //            $('#cartdiv').empty();
            //            $('#cartdiv').html(message.message);
            //            //$('#cartdesign').text(message);
            //        },
            //        error: function (result) {
            //            alert('Der skete en fejl, prøv igen senere');
            //        }
            //    });

            //};



            return {
                PostDetails: PostDetails,
                postReceived: postReceived,
                title: title,
                rank: rank,
                body: body,
                saveAnnotation: saveAnnotation,
                annotationData: annotationData
                

            };
        };
    });
