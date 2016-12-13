
(function (undefined) {
    require.config({
        baseUrl: "js",
        paths: {
            "jquery": "lib/jquery/dist/jquery",
            "knockout": "lib/knockout/dist/knockout",
            "text": "lib/requirejs-text/text",
            "bootstrap": "lib/bootstrap/dist/js/bootstrap",
           
            "dataservice": "app/services/dataservice",
            "postman": "app/services/postman",
            "config": "app/Config"
        }, 
        shim: {
            "bootstrap": { "deps": ['jquery'] }
        }
    });

    require(['knockout'], function (ko) {
        ko.components.register("menu-nav", {
            viewModel: { require: 'app/components/menu/menuViewModel' },
            template: { require: 'text!app/components/menu/menu.html' }
        });

        ko.components.register("search-posts", {
            viewModel: { require: 'app/components/home/homeViewModel' },
            template: { require: 'text!app/components/post/home.html' }
        });

        ko.components.register("posts-lists", {
            viewModel: { require: 'app/components/post/posts' },
            template: { require: 'text!app/components/post/post.html' }
        });

        ko.components.register("annotation", {
            viewModel: { require: 'app/components/annotation/annotationViewModel' },
            template: { require: 'text!app/components/annotation/annotation.html' }
        });


        ko.components.register("search-history", {
            viewModel: { require: 'app/components/history/historyViewModel' },
            template: { require: 'text!app/components/history/history.html' }
        });

        
        ko.components.register("mark-post", {
            viewModel: { require: 'app/components/markpost/markpostViewModel' },
            template: { require: 'text!app/components/markpost/markpost.html' }
        });

        
        ko.components.register("post-details", {
            viewModel: { require: 'app/components/postDetails/postDetailsViewModel' },
            template: { require: 'text!app/components/postDetails/postDetails.html' }
        });

        ko.components.register("word-cloud", {
            viewModel: { require: 'app/components/wordCloud/wordCloudViewModel' },
            template: { require: 'text!app/components/postDetails/word.html' }
        });
    });

        require(['knockout'], function(ko) {
            ko.applyBindings();
        });

    })();