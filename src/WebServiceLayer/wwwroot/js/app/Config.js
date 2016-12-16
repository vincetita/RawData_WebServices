
define([], function () {
    var serverUrl = 'http://localhost:5489';
    
    return {
        events: {
            searchPosts: "Search",
            selectOwnComment: "SelectComment",
            saveOwnComment: "SaveComment",
            selectPost: "SelectPost",
            annotationToPost: "AnnotationPost",
            changeMenu: "ChangeMenu"
            // Remember to add for word cloud later api
        },

        menuElements: {

            menunav: "menu",
            homenav: "Home",
            commentsnav: "Comments",
            historynav: "History",
            postsmarkednav: "Posts Marked",
            wordcloudnav: "Word Cloud",
            changemenu: "changeMenuEvent"
        },    

        // For access to server

       serverApi: {
        searchUrl: serverUrl + "/api/rankword?rankword=",
        postUrl: serverUrl + "/api/posts",
        historyUrl: serverUrl + "/api/history",
        postsmarkedUrl: serverUrl + "/api/markedposts",
        owncommentsUrl: serverUrl + "/api/owncomments"
        }
};
});