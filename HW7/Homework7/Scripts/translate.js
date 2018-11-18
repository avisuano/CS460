// Some simple words to search Giphy with
var simpleDictionary =
    [
        "cat", "dog", "brother", "sister", "husband", "wife", "kids", "son", "daughter", "computer", "friend",
        "lobster", "class", "homework", "school", "hard", "sometimes", "fun", "hard", "back", "to", "the",
        "military", "please", "so", "much", "easier", "did", "if", "of", "course", "pay", "more", "attention",
        "less", "stress"
    ];

// When the document is loaded
$(document).ready(function () {

    // Add the text as typed to the DOM... for 'fun' and practice
    $("#translate").keyup(function (event) {
        var txt = $(this).val();
        $("#tippitytype").text(txt);
    });

    // The main work horse
    $('#trans').click(function () {
        // Trim off extra white space
        var searchText = $('#translate').val().trim();
        // Remove special characters, don't want those going to the database
        searchText = searchText.replace(/[^a-zA-Z0-9]/g, ' ');
        // Remove any extra white space created
        searchText = searchText.trim();
        // Replace spaces with "+" to make it easier to search
        searchText = searchText.replace(/\s+/g, '+');

        // Check the dictionary, if there search Giphy, if not just place the word
        if (checkDictionary(searchText) == true) {
            var search = "/SearchGiphy/?q=" + searchText;
            $.ajax(
                {
                    type: "GET",
                    dataType: "json",
                    url: search,
                    success: placeWords
                });
        }
        else {
            placeWords(searchText);
        }
    });

    // check the dictionary
    function checkDictionary(searchText) {
        var tmp = searchText;
        var inDictionary = false;
        for (var i = 0; i < simpleDictionary.length; i++) {
            if (simpleDictionary[i].toLowerCase() === tmp.toLowerCase()) {
                inDictionary = true;
            }
        }
        return inDictionary;
    }

    // Simple function to append search text to the containter
    function placeWords(searchText) {
        $('#searches').append(" " + "<label>" + searchText + "</label>");
    }
});