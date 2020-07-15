var connection = new signalR.HubConnectionBuilder().withUrl("/signalrhub").build();
connection.on("UpdateDeliveryRequestCount", function (count) {
    document.getElementById("TotalDeliveryRequests").value = count;
    document.getElementById("TotalDeliveryRequestsText").innerHTML = "<i class='icon icon-data_usage text-red'></i> " + count + " new Delivery Requests";
    SumOfNotifications();
});

connection.on("UpdateShippingRequestCount", function (count) {
    document.getElementById("TotalShippingRequests").value = count;
    document.getElementById("TotalShippingRequestsText").innerHTML = "<i class='icon icon-data_usage text-green'></i> " + count + " new Shipping Requests";
    SumOfNotifications();
});

connection.on("UpdateReceivingLogCount", function (count) {
    document.getElementById("TotalReceivingLogs").value = count;
    document.getElementById("TotalReceivingLogsText").innerHTML = "<i class='icon icon-data_usage text-orange'></i> " + count + " new Receiving Logs";
    SumOfNotifications();
});

connection.on("UpdatePickupListCount", function (count) {
    document.getElementById("TotalPickupLists").value = count;
    document.getElementById("TotalPickupListsText").innerHTML = "<i class='icon icon-data_usage text-yellow'></i> " + count + " new Pickup Lists";
    SumOfNotifications();
});

function SumOfNotifications() {
    var TotalDeliveryRequests = 0;
    var TotalShippingRequests = 0;
    var TotalReceivingLogs = 0;
    var TotalPickupLists = 0;
    if (document.getElementById("TotalDeliveryRequests") != null) {
         TotalDeliveryRequests = parseInt(document.getElementById("TotalDeliveryRequests").value);
    }
    if (document.getElementById("TotalShippingRequests") != null) {
         TotalShippingRequests = parseInt(document.getElementById("TotalShippingRequests").value);

    }
    if (document.getElementById("TotalReceivingLogs") != null) {
        TotalReceivingLogs = parseInt(document.getElementById("TotalReceivingLogs").value);

    }
    if (document.getElementById("TotalReceivingLogs") != null) {
        TotalPickupLists = parseInt(document.getElementById("TotalPickupLists").value);

    }
    var TotalNotifications = TotalDeliveryRequests + TotalShippingRequests + TotalReceivingLogs + TotalPickupLists;
    document.getElementById("TotalNotification").innerHTML = TotalNotifications;
    document.getElementById("TotalNotificationSubMenuText").innerHTML = "You have " + TotalNotifications + "  notifications  ";
}

connection.start().catch(function (err) {
    return console.error(err.toString());
});