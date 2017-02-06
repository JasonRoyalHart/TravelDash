//Skyscanner Search

function carSearch() {
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/autosuggest/v1.0/GB/GBP/en-GB?query=rome&apiKey=tr906266896253037258757243379113";
  pickup = document.getElementById("pickup").value;
  pickupDate = document.getElementById("pickupDate").value;
  dropoffDate = document.getElementById("dropoffDate").value;
  var carURL = makeURL(pickup, pickupDate, dropoffDate);
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/MKE/DAL/anytime/anytime?apikey=tr906266896253037258757243379113";
  getCars(carURL);
}

function makeURL(pickup, pickupDate, dropoffDate) {
// http://partners.api.skyscanner.net/apiservices/carhire/liveprices/v2/{market}/{currency}/{locale}/{pickupplace}/{dropoffplace}/{pickupdatetime}/{dropoffdatetime}/{driverage}?apiKey={apiKey}&userip={userip}
// http://api.sandbox.amadeus.com/v1.2/cars/search-airport?location=SFO&pick_up=2015-11-09&drop_off=2015-11-18&apikey=<YOUR API KEY HERE>

  api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
  URL = "http://api.sandbox.amadeus.com/v1.2/cars/search-airport?";
  URL += "apikey=" + api;
  URL += "&location=" + pickup;
  URL += "&pick_up=" + pickupDate;
  URL += "&drop_off=" + dropoffDate;
//  URL = "http://partners.api.skyscanner.net/apiservices/hotels/autosuggest/v2/UK/EUR/en-GB/pari?apikey=tr906266896253037258757243379113";
  console.log(URL);
  return URL;
}

// http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/{country}/{currency}/{locale}/
function getCars(URL) {
  $.ajax({
    url: URL,
    dataType: "json",
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
  var html = "<table><tr><td>Image</td><td>Provider</td><td></td><td>Type</td><td>Cost</td></tr>";
  html += "<tr>";
  var results = data.results;
  for (i in results) {
    result = results[i];
    provider = result.provider.company_name;
    for (j in result.cars) {
      car = result.cars[j];
      html += "<td><img src =" + car.images[0].url + "></td>";
      html += "<td>" + provider + "</td>";
      html += "<td>" + car.vehicle_info.type + "</td>";
      html += "<td>" + car.rates[0].price.amount + "</td>";
      html += "</tr>";
    }
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
