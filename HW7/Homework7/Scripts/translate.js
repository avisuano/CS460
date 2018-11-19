// Some simple words to search Giphy with
var simpleDictionary =
    [
        "cat", "dog", "brother", "sister", "husband", "wife", "kids", "son", "daughter", "computer", "friend",
        "lobster", "class", "homework", "school", "hard", "sometimes", "fun", "hard", "back", "to", "the",
        "military", "please", "so", "much", "easier", "did", "if", "of", "course", "pay", "more", "attention",
        "less", "stress"
    ];

// Add the text as typed to the DOM... for 'fun' and practice
$("#translate").keyup(function (event) {
    var txt = $(this).val();
    $("#tippitytype").text(txt);
});

// Meat and potatoes, when clicked start breaking stuff down
$('#submit').click(function ()
{
    // Take the user input and trim any extra white space
    var searchText = $('#translate').val().trim();
    // Remove special characters.. don't want those going to the database
    searchText = searchText.replace(/[^a-zA-Z0-9]/g, ' ');
    // Trim extra if special characters are removed
    searchText = searchText.trim();

    // Search dictionary for words
    for (var i = 0; i < searchText.length; i++)
    {
        if (searchText.indexOf(simpleDictionary) > -1) {

            // send a word found to the controller
            var query = "/Search/?q=" + searchText;
            $.ajax({
                type: "GET",
                dataType: "json",
                url: query,
                success: loadSticker,
            });
        }
        else
        {
            // If not there, just append to the container
            placeWords(searchText);
        }
    }
});

// Trying to use more helper methods
function loadSticker(data)
{
    var tmp = JSON.parse(data);
    $('#searches').append('<img src="' + tmp.url + '">')
}
function placeWords(text)
{
    $('#searches').append(" " + text + " ");    
}