$(document).ready(function () {

    // Add the text as typed to the DOM... for fun...
    $("#translate").keyup(function (event) {
        var txt = $(this).val();
        $("#destination").text(txt);
    });

    // When submit is clicked...
    $('#trans').click(function () {
        // First step is to trim off any extra white space
        var searchText = $('#translate').val().trim();

        // Now we need to trim special characters, trim any space that created
        searchText = searchText.replace(/[^a-zA-Z0-9]/g, ' ');
        searchText = searchText.trim();
        // Replace white space between words with a + for easier query strings
        searchText = searchText.replace(/\s+/g, '+');

        // Build a query to search the database
        var query = "/Search/?q=" + searchText;

        // Query the server
        $.ajax({
            type: "GET",
            dataType: "json",
            url: query,
            success: loadImages,
            error: failed
        });
    });

    // When stickers are found, load the stickers to the seaches div
    function loadImages(data)
    {
        $('#searches').empty();
        var temp = JSON.parse(data);
        for (var i = 0; i < temp.length; i += 1)
        {
            $('#searches').append('<img src="' + temp[i].url + '">');
        }
    }

    // If everything failed... most likely event
    function loadFail()
    {
        $('#searches').empty();
        $('#searches').append('<h3>ERROR LOADING IMAGES</h3>');
    }
});