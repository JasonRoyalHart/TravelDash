//Skyscanner Search

function hotelSearch() {
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/autosuggest/v1.0/GB/GBP/en-GB?query=rome&apiKey=tr906266896253037258757243379113";
  city = document.getElementById("city").value;
  checkIn = document.getElementById("checkIn").value;
  checkOut = document.getElementById("checkOut").value;
  distance = document.getElementById("distance").value;
  numberResults = document.getElementById("numberResults").value;
  var hotelURL = makeURL(city, checkIn, checkOut, distance, numberResults);
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/MKE/DAL/anytime/anytime?apikey=tr906266896253037258757243379113";
  getHotels(hotelURL);
}

function makeURL(city, checkIn, checkOut, distance, numberResults) {
//  URL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/"
//  URL += origin + "/" + destination + "/" + outbound + "/" + inbound + "?apikey=tr906266896253037258757243379113";
//  console.log(URL);
//  URL = "http://partners.api.skyscanner.net/apiservices/hotels/liveprices/v2/UK/EUR/en-GB/27539733/2014-02-10/2014-02-15/2/1?apiKey=tr906266896253037258757243379113";
  api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
  URL = "https://api.sandbox.amadeus.com/v1.2/hotels/search-airport?apikey=" + api;
  URL += "&location=" + city;
  URL += "&check_in=" + checkIn;
  URL += "&check_out=" + checkOut;
  URL += "&radius=" + distance;
  URL += "&number_of_results=" + numberResults;
  return URL;
}

// http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/{country}/{currency}/{locale}/
function getHotels(URL) {
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
//  console.log("Success!");
//  console.log(data);
//  var airlines = getAirlines(data.Carriers);
  var html = "<table><tr><td>Select</td><td>Hotel</td><td>Address</td><td>Price Per Night</td><td>Total Price</td></tr>";
  var results = data.results;
  html += "<form>";
  for (i in results) {
    result = results[i];
    html += "<tr>";
    html += "<td><input type="+"'"+"radio"+"' "+"name="+"'"+"select"+"' "+"value="+"'"+"other"+"'"+
    "></td>";
    html += "<td>" + result.property_name + "</td>";
    html += "<td>" + result.address.line1 + "</td>";
    html += "<td>" + result.min_daily_rate.amount + "</td>";
    html += "<td>" + result.total_price.amount + "</td>";
    html += "</tr>";
  }
  html += "</form>";
  jQuery('#hotels-results').html(html);
}
