
function carSearch() {
  pickup = "MKE";
  dropoff = "MKE";
  pickupdatetime = "2017-02-07T12:30"
  dropoffdatetime = "2017-02-07T1:30";
  var carURL = makeURL(pickup, dropoff, pickupdatetime, dropoffdatetime);
  getCars(carURL);
}

function makeURL(pickup, dropoff, pickupdatetime, dropoffdatetime) {
  URL = "http://partners.api.skyscanner.net/apiservices/carhire/liveprices/v2/US/USD/en-US/";
  URL += pickup + "/" + dropoff + "/" + pickupdatetime + "/" + dropoffdatetime + "/30?apiKey=prtl6749387986743898559646983194&userip=12.247.118.54";
  return URL;
}

function getCars(URL) {
  $.ajax({
    url: URL,
    method: "GET",
    dataType: "jsonp",
    success: function(data) {displayData(data)},
    error: function(data) {displayError(data)}
  });
}

function displayError(data) {
  console.log("Failure!");
  console.log(data);
}

function displayData(data) {
  console.log(data);
  var airlines = getAirlines(data.Carriers);
  var html = "<table><tr><td>Price</td><td>Departure Airline</td><td>Departure Time</td><td>Return Airline</td><td>Return Time</td></tr>";
  var quotes = data.Quotes;
  for (i in quotes) {
    quote = quotes[i];
    html += "<tr>";
    html += "<td>" + quote.MinPrice + "</td>";
    html += "<td>" + airlines[quote.OutboundLeg.CarrierIds[0]] + "</td>";
    html += "<td>" + quote.OutboundLeg.DepartureDate + "</td>";
    html += "<td>" + airlines[quote.InboundLeg.CarrierIds[0]] + "</td>";
    html += "<td>" + quote.InboundLeg.DepartureDate + "</td>";
    html += "</tr>";
  }
  jQuery('#cars-results').html(html);
}

function getAirlines(carriers) {
  var returnCarriers = {};
  for (i in carriers) {
    carrier = carriers[i];
    returnCarriers[carrier.CarrierId] = carrier.Name;
  }
  return returnCarriers;
}
