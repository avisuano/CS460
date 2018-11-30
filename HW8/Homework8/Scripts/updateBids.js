$(document).ready(function () {

    console.log("the script actually loaded")


    var getList = function () {
        var id = parseInt($('#itemId').html().trim());

        console.log('item id: ' + id);

        // Send to ItemController
        var src = "/Items/ListBids?Id=" + id;

        console.log("step 1");

        $.ajax({
            type: 'GET',
            dataType: 'json',
            url: src,
            success: display,
            error: oops
        });
    };

    // If successful push to page
    function display(data) {
        console.log('the data: ' + data);
        var tmp = JSON.parse(data);
        $('.displayBids').empty();
        $('.displayBids').append('<tr><th> Bidder Name </th> <th> Bid Price </th> </tr>');

        for (var i = 0; i < tmp.length; i++)
        {
            $('.displayBids').append('<tr> <td>' + tmp[i].BuyerName + '</td><td>' + tmp[i].Price + '</td></tr>');
        }

        console.log("maybe we can get somewhere");
    }

    // If there's a problem...
    function oops() {
        console.log("Something went wrong.");
    }

    // AJAX load every 3 seconds
    var interval = 3000;
    window.setInterval(getList, interval);
});