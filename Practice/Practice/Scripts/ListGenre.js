function ListGenre(id)
{
    $.ajax({
        type: "GET",
        url: "/Home/GetGenre/" + id,
        dataType: "json",
        success: function (data) { push(data); },
        error: function (data) { alert("Something went terribly wrong, please contact someone who knows something."); }
    });
}

function push(data)
{
    $('#output').empty();
    var str = "<dl>"
    $.each(data, function (i, item) {
        str = str + "<dt>" + item["artwork"] + " <dd> by  " + item["artist"] + "</dd>" + "</dt>"
    });
    str += "</dl>"
    $('#output').append(str);
}