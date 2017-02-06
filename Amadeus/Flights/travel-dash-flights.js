//Skyscanner Search

function flightSearch() {
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/autosuggest/v1.0/GB/GBP/en-GB?query=rome&apiKey=tr906266896253037258757243379113";
  origin = document.getElementById("origin").value;
  destination = document.getElementById("destination").value;
  outbound = document.getElementById("outbound").value;
  inbound = document.getElementById("inbound").value;
  var flightURL = makeURL(origin, destination, outbound, inbound);
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/MKE/DAL/anytime/anytime?apikey=tr906266896253037258757243379113";
  getFlights(flightURL);
}

function makeURL(origin, destination, outbound, inbound) {
  URL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/"
  URL += origin + "/" + destination + "/" + outbound + "/" + inbound + "?apikey=tr906266896253037258757243379113";
//  console.log(URL);
  return URL;
}

// http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/{country}/{currency}/{locale}/
function getFlights(URL) {
  $.ajax({
    url: URL,
    dataType: "jsonp",
    method: "GET",
    crossDomain: true,
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
  jQuery('#flight-results').html(html);
}

function getAirlines(carriers) {
  var returnCarriers = {};
  for (i in carriers) {
    carrier = carriers[i];
    returnCarriers[carrier.CarrierId] = carrier.Name;
  }
  return returnCarriers;
}
