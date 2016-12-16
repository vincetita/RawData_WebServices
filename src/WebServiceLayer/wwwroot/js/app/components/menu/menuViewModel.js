define(['knockout', 'postman', 'config', 'dataservice'], function (ko, postman, config, dataservice) {
    return function () {
        var menuItems = [
            { title: config.menuElements.homenav, component: 'search-posts' },
            { title: config.menuElements.commentsnav, component: 'annotation-owncomments' },
            { title: config.menuElements.historynav, component: 'history-search' },
            { title: config.menuElements.postsmarkednav, component: 'mark-post' },
            { title: config.menuElements.postsdetailsnav, component: 'post-details' }
        ];

        var currentComponent = ko.observable();
        var currentParams = ko.observable();
        var selectedMenu = ko.observable();


        var selectMenu = function (menu, params) {
            selectedMenu(menu);
            currentParams(params);
            currentComponent(menu.component);
        };

        var isSelected = function (menu) {
            return menu === selectedMenu();
        };

        postman.subscribe(config.events.searchPosts, function (params) {
            currentParams(params);
            currentComponent("search-posts");
        });

        postman.subscribe(config.events.searchPosts, function (params) {
            currentParams(params);
            currentComponent("post-details");
        });

        postman.subscribe(config.events.annotationToPost, function (params) {
            currentParams(params);
            currentComponent("post-details");
        });
        //postman.subscribe(config.events.searchPosts, function (params) {
        //    currentParams(params);
        //    currentComponent("post-details");
        //});

        //postman.subscribe(config.events.historyUrl, function (params) {
        //    currentParams(params);
        //    currentComponent("history-search");
        //});

        //postman.subscribe(config.events.postsmarkedUrl, function (params) {
        //    currentParams(params);
        //    currentComponent("mark-post");
        //});

        //postman.subscribe(config.events.owncommentsUrl, function (params) {
        //    currentParams(params);
        //    currentComponent("annotation-owncomments");
        //});

        postman.subscribe(config.events.changeMenu, function (data) {
            for (var i = 0; i < menuItems.length; i++) {
                if (menuItems[i].title === data.title) {
                    selectMenu(menuItems[i], data.params);
                    break;
                }
            }
        });

        selectMenu(menuItems[0]);

        return {
            menuItems,
            currentComponent,
            currentParams,
            selectMenu,
            isSelected
        };
    };
});