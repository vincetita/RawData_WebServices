var serviceRoot = 'http://localhost:5489/api/posts';

var dataservice = {
    postlists: function (serviceRoot, callback) {
        $.getJSON(serviceRoot, callback);
    }
};

var vm = {
    total: ko.observable(),
    posts: ko.observableArray([])
    //length: ko.observable()
   
};

$("#btn").on('click', function () {
    dataservice.postlists(serviceRoot, function (data)
    {
        vm.total(data.total);
        vm.posts(data.data);

        //var showLength = function () {
        //    console.log("show function called");
        //}
        //vm.length = ko.computed(function () {
        //    console.log(data.data.body.length());
        //    return data.data.body.length();
            
        //});
    //vm.posts([{ body: "<script>alert('this is danger');</script>" }]);
        //$("#output").text(JSON.stringify(data));

    });
});

ko.applyBindings(vm);

//var postslists = function PostsViewModel() {
//    data.showposts(function (data) {
//        ko.appybindings({
//            posts: data
//        })
//    });
//}
//postUrl: server + "/api/posts",
//$("#btn").on('click', function () {
//    dataservice.search($("#input").val(), function (data) {
//        ko.applyBindings({
//            posts: data
//        });

    