var Order = function () {
    var self = this;
    self.OrdersCollection = ko.observableArray();
    self.CurrentFilter = ko.observable('');
    self.Filters = ko.observableArray();

    self.FilteredItems = ko.computed(function () {
        var CurrentFilter = self.CurrentFilter();
        if (!CurrentFilter || CurrentFilter == "select instrument") {
            return self.OrdersCollection();
        } else {
            return ko.utils.arrayFilter(self.OrdersCollection(), function (i) {
                return i.MusicInstrumentId == CurrentFilter;
            });
        }
    });
};

var Orders = new Order();
ko.applyBindings(Orders);

$(document).ready(function () {     
    $.ajax({
        type: "GET",
        url: "/Admin/GetAllOrders",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $(data).each(function (index, element) {
            Orders.OrdersCollection.push(element);
        });        
    })
});

$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Admin/GetAllMusicInstruments",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $(data).each(function (index, element) {
            Orders.Filters.push(element);
        });
    })
});