$(document).ready(function () {
    // AJAX load every 5 seconds
    var interval = 5000;
    window.setInterval(getList, interval);

    // Send to ItemController
    var src = "/Items/ListBids" + id;
    var getList = function () {
        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: src,
            success: display,
            error: oops
        })
    }

    // If successful push to page
    function display(data) {
        var updateBids = "<table class = \"table\"><thead><tr><th>Bidder Name</th><th>Bid Price</th></tr></thead><tbody>";

        $.each(data, function (i, item) {
            updateBids += "<tr>" + "<td>" + item.Name + "</td>" + "<td> $" + item.Price + "</td>" + "</tr>";
        });
        $('#displayBids').html(updateBids);
    }

    // If there's a problem...
    function oops() {
        console.log("Something went wrong.");
    }
});