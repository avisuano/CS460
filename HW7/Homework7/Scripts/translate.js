$(document).ready(function () {

    // Add the text as typed to the DOM... for fun...
    $("#translate").keyup(function (event) {
        var txt = $(this).val();
        $("#destination").text(txt);
    });


     
});