
var searchTerm = banana;
var url = "http://api.openweathermap.org/data/2.5/forecast?us&units=imperial&APPID=aa6b1550989d2570caa91f5781d5c8b4&q=" + searchTerm
$.ajax({
    url: url,
    method: 'GET',
    dataType: "json",
    success: function (response) {
        $("#output").html();
        parseDataInit(response);
        console.log(response);
    }
})


function parseDataInit(data) {
    parseCity(data["city"]["name"])
    parseData(data["list"]["0"], "#output");
    parseFuture(data["city"]["name"]);
    var j = 1;
    for (let i = 1; i < 6; i++) {
        j = (j + 6);
        $("#outputTwo").append("<br>");
        parseData(data["list"][j], "#outputTwo");
    }
}

function parseCity(city) {
    $("#output").prepend("<div><div class='well'><p><b>" +
  "Current Weather in " + city + "</b></p>");
}
function parseFuture(city) {
    $("#outputTwo").prepend("<div><div class='well'><p><b>" +
  "Future Forecast for " + city + "</b></p>");
}
function parseData(data, place) {
    $(place).append("<p>" +
     "Overall conditions on " + (parseDate(data["dt_txt"])) + ": " + data.weather[0].description + "</p><p>" +
      "Temperature: " + data.main.temp + "</p>");
    if (place == "#output") {
        $("#output").append(
          "<p> Wind speed: " + data.wind.speed +
           "</p><p> Cloud Cover: " + data["clouds"]["all"] + "%</p>");
    }

}
function parseDate(string) {
    dateArray = string.split("-");
    dayArray = dateArray[2].split(" ");
    cleanDate = dateArray[1] + "/" + dayArray[0] + "/" + dateArray[0];
    return cleanDate;
}
