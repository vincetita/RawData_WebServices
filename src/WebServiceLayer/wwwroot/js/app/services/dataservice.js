

var dataservice = {
     search : function(searchString, callback) {
         $.getJSON("http://localhost:5489/api/searchkeyword?search=" + searchString, callback);
           }
}

$("#btn").on('click', function () {
    dataservice.search($("#input").val(), function (data) {
        $("#output").text(JSON.stringify(
            data.items.map(function (e) {
                return {
                    login: e.login,
                    id: e.id
                }
            })
            ));
    });
});