
define([], function () {
    var serverUrl = 'http://localhost:5489';
    
    return {
        events: {

            searchUrl: server + "/api/rankword?rankword=",
            postUrl: server + "/api/posts",
            historyUrl: server + "/api/history",
            postsmarkedUrl: server + "/api/markedposts",
            owncommentsUrl: server + "/api/owncomments",
        },

        menuElements: {

            menunav: "menu",
            homenav: "Home",
            commentsnav: "Comments",
            historynav: "History",
            postsmarkednav: "Posts Marked",
            changemenu: "changeMenuEvent"
        }
    };
});