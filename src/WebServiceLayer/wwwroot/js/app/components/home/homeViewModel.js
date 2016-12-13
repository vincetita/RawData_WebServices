var dataservice = {
    search: function (searchString, callback) {
        $.getJSON("http://localhost:5489/api/searchkeyword?search=" + searchString, callback);
        //var searchedstring = ko.observableArray([]);
        //    var addsearchedstr = function () {
        //        searchstring.push({
        //            searchstring: searchString()
        //        });
        //        searchString("");
        //    }
    }
}

$("#btn").on('click', function () {
    dataservice.search($("#input").val(), function (result) {
        ko.applyBindings({
            result: result
        });

    });
});

//ko.applyBindings(data);

//function Posts(Searchword) {
//    var self = this;
//    //self.PostId = ko.observable(Postid);
//    self.Post = ko.observable(Searchword);
//    self.PostUrl = ko.computed(function () {
//        return "../api/searchkeyword?artistId=" + this.Post();
//    }, this);
//}

//function PostsViewModel() {
//    // Properties
//    var self = this;
//    this.PostsSearched = ko.observableArray([]);

//    // Functions
//    this.searchPosts = function () {
//        var keyword = $('#Searchinput').val();
//        $('#tbodySearchPosts').empty();
//        $.getJSON("/api/searchkeyword?search=" + keyword, function (posts) {
//            $.each(posts, function (index, post) {
//                self.PostsSearched.push(new Posts(post.postsid, post.body, post.score, post.creationDate));
//            });
//        });
//    };
//}



