   var Orders = {
        OrdersCollection: ko.observableArray(),
};

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
            ko.applyBindings(Orders);
        })
    });
