
var serviceRoot = 'http://localhost:55555';

var HistoryViewM = function HistoryViewModel() {
                var self = this;
                self.history = ko.observableArray();

                var baseUri = '@ViewBag.ApiUrl';
                $.getJSON(baseUri, self.products);

                self.create = function (formElement) {
                    // If the form data is valid, post the serialized form data to the web API.
                    $(formElement).validate();
                    if ($(formElement).valid()) {
                        $.post(baseUri, $(formElement).serialize(), null, "json")
                            .done(function (o) {
                                // Add the new product to the view-model.
                                self.products.push(o);
                            });
                    }
    }
}