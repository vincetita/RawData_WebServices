define(['knockout', 'dataservice', 'postman', 'config', 'jqcloud2'],
    function (ko, dataService, postman, config, jq) {
        return function (params) {
            //var wordList = ko.observableArray([]);
            var searchWord = ko.observable("map");

            //var callback = function (data) {
            //    console.log(data.data);
            //    wordList(data.data);
            //};

            //dataService.getWordCloud(searchWord(), callback);
            dataService.getWordCloud(searchWord(), function (data) {
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
    });