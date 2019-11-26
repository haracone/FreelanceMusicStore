/*var Orders = {
    OrdersCollection: ko.observableArray(),
    Filters: ko.observable()
};*/

function Orders() {
    var self = this;
    self.OrdersCollection = ko.observableArray();
    self.CurrentFilter = ko.observable();

    self.filterOrders= ko.computed(function () {
        if (!self.CurrentFilter()) {
            return self.Orders;
        } else {
            return ko.utils.arrayFilter(self.Orders(), function (ord) {
                return ord.ClientId == self.CurrentFilter();
            });
        }
    });
}

$(document).ready(function () {
    var Order = new Orders();
    $.ajax({
        type: "GET",
        url: "/Admin/GetAllOrders",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
    }).done(function (data) {
        $(data).each(function (index, element) {
            Order.OrdersCollection.push(element);
        });
        ko.applyBindings(Order);
    })
});
