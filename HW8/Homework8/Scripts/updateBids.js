$(document).ready(function () {

    // Lots of trouble shooting
    console.log("the script actually loaded")

    var getList = function () {
        // Make sure integers are 
        var id = parseInt($('#itemId').html().trim());

        // More trouble shooting
        console.log('item id: ' + id);

        // Send to ItemController
        var src = "/Items/ListBids?Id=" + id;

        // Can we get an ajax call?
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

        // Is the data actually the data we need?
        console.log('the data: ' + data);

        // Convert to a Json object
        var tmp = JSON.parse(data);

        // Set up the display table
        $('.displayBids').empty();
        $('.displayBids').append('<tr><th> Current Bidders: </th> <th> Bid Price </th> </tr>');

        // Fill the table
        for (var i = 0; i < tmp.length; i++)
        {
            $('.displayBids').append('<tr> <td>' + tmp[i].BuyerName + '</td><td>' + tmp[i].Price + '</td></tr>');
        }

        // Did we get anything?
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