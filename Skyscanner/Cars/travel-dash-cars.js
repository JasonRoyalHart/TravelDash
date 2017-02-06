//Skyscanner Search

function carSearch() {
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/autosuggest/v1.0/GB/GBP/en-GB?query=rome&apiKey=tr906266896253037258757243379113";
  pickup = document.getElementById("pickup").value;
  dropoff = document.getElementById("dropoff").value;
  pickupdatetime = document.getElementById("pickupdatetime").value;
  dropoffdatetime = document.getElementById("dropoffdatetime").value;
  var carURL = makeURL(pickup, dropoff, pickupdatetime, dropoffdatetime);
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/MKE/DAL/anytime/anytime?apikey=tr906266896253037258757243379113";
  getCars(carURL);
}

function makeURL(pickup, dropoff, pickupdatetime, dropoffdatetime) {
// http://partners.api.skyscanner.net/apiservices/carhire/liveprices/v2/{market}/{currency}/{locale}/{pickupplace}/{dropoffplace}/{pickupdatetime}/{dropoffdatetime}/{driverage}?apiKey={apiKey}&userip={userip}
  URL = "http://partners.api.skyscanner.net/apiservices/carhire/liveprices/v2/US/USD/en-US/";
  URL += pickup + "/" + dropoff + "/" + pickupdatetime + "/" + dropoffdatetime + "/30?apiKey=prtl6749387986743898559646983194&userip=12.247.118.54";
  console.log(URL);
//  URL = "http://partners.api.skyscanner.net/apiservices/hotels/autosuggest/v2/UK/EUR/en-GB/pari?apikey=tr906266896253037258757243379113";
  return URL;
}

// http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/{country}/{currency}/{locale}/
function getCars(URL) {
  $.ajax({
    headers: {
    Accept : "application/jsonp"
},
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
