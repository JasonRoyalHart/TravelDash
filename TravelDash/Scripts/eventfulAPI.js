$('form').submit(function (event) {
    event.preventDefault();

    var oArgs = {
        app_key: "DzmC74sw8ngVbbrr",
        where: $('#cityInput').val(),
        q: $('#keywordInput').val(),
        page_size: 10,
        sort_order: "popularity",
    };
    EVDB.API.call("/events/search", oArgs, function (oData) {
        parseData(oData);
    });

});


function parseData(data) {
    for (let i = 0; i < data.events.event.length; i++) {
        currentResults = formatRow(data["events"]["event"][(i.toString())]);
        $("#resultsTable").append(currentResults);
    }
}
function formatRow(object) {
    cleanedObject = "<tr><td><img src=" + object["image"]["medium"]["url"] +
    "><td><b>" + object.title +
    "</b></td><td>" + object["start_time"] +
    "</td><td>" + object["venue_name"] +
    "</td><td><a href=" + object["url"] +
    ">" + "More info" + "</a></td>" +
    "</tr>";
    return cleanedObject;
}
