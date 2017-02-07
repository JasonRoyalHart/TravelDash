//Amadeus Search

function flightSearch() {
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/autosuggest/v1.0/GB/GBP/en-GB?query=rome&apiKey=tr906266896253037258757243379113";
  origin = document.getElementById("origin").value;
  destination = document.getElementById("destination").value;
  outbound = document.getElementById("outbound").value;
  inbound = document.getElementById("inbound").value;
  results = document.getElementById("results").value;
  var flightURL = makeURL(origin, destination, outbound, inbound, results);
//  var flightURL = "http://partners.api.skyscanner.net/apiservices/xd/browsedates/v1.0/US/USD/en-US/MKE/DAL/anytime/anytime?apikey=tr906266896253037258757243379113";
  getFlights(flightURL);
}

function makeURL(origin, destination, outbound, inbound, results) {
  api = "bG7HZQsZILLmjpOhLihxd9K4CMGGJsWG";
  URL = "http://api.sandbox.amadeus.com/v1.2/flights/low-fare-search?";
  URL += "origin=" + origin;
  URL += "&destination=" + destination;
  URL += "&departure_date=" + outbound;
  URL += "&return_date=" + inbound;
  URL += "&number_of_results=" + results;
  URL += "&apikey=" + api;
//  console.log(URL);
  return URL;
}

// http://partners.api.skyscanner.net/apiservices/browsequotes/v1.0/{country}/{currency}/{locale}/
function getFlights(URL) {
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
  var html = "<table><tr><td>Select</td><td>Price</td><td>Departure Airline</td><td>Departure Time</td><td>Return Airline</td><td>Return Time</td></tr>";
  var results = data.results;
  html += "<form>";
  for (i in results) {
    result = results[i];
    html += "<tr>";
    html += "<td><input type="+"'"+"radio"+"' "+"name="+"'"+"select"+"' "+"value="+"'"+"other"+"'"+
    "></td>";
    html += "<td>" + result.fare.total_price + "</td>";
    html += "<td>" + getAirline(result.itineraries[0].inbound.flights[0].marketing_airline) + "</td>";
    html += "<td>" + result.itineraries[0].inbound.flights[0].departs_at + "</td>";
    html += "<td>" + getAirline(result.itineraries[0].outbound.flights[0].marketing_airline) + "</td>";
    html += "<td>" + result.itineraries[0].outbound.flights[0].departs_at + "</td>";
    html += "</tr>";
  }
  html += "</form>";
  html += "</table>";
  jQuery('#flight-results').html(html);
}

function getAirline(code) {
  airlineCodes = {};
  airlineCodes["6A"]	= "AVIACSA";
  airlineCodes["9K"] =	"Cape Air";
  airlineCodes["A0"] =	"L'Avion";
  airlineCodes["A7"] =	"Air Plus Comet";
  airlineCodes["AA"] =	"American";
  airlineCodes["AC"] =	"Air Canada";
  airlineCodes["AF"] =	"Air France";
  airlineCodes["AI"] =	"Air India";
  airlineCodes["AM"] =	"Aeromexico";
  airlineCodes["AR"] =	"Aerolineas Argentinas";
  airlineCodes["AS"] =	"Alaska";
  airlineCodes["AT"] =	"Royal Air Maroc";
  airlineCodes["AV"] =	"Avianca";
  airlineCodes["AY"] =	"Finnair";
  airlineCodes["AZ"] =	"Alitalia";
  airlineCodes["B6"] =	"JetBlue";
  airlineCodes["BA"] =	"British Airways";
  airlineCodes["BD"] =	"bmi british midland";
  airlineCodes["BR"] =	"EVA Airways";
  airlineCodes["C6"] =	"CanJet Airlines";
  airlineCodes["CA"] =	"Air China";
  airlineCodes["CI"] =	"China";
  airlineCodes["CO"] =	"Continental";
  airlineCodes["CX"] =	"Cathay";
  airlineCodes["CZ"] =	"China Southern";
  airlineCodes["DL"] =	"Delta";
  airlineCodes["EI"] =	"Aer Lingus";
  airlineCodes["EK"] =	"Emirates";
  airlineCodes["EO"] =	"EOS";
  airlineCodes["F9"] =	"Frontier";
  airlineCodes["FI"] =	"Icelandair";
  airlineCodes["FJ"] =	"Air Pacific";
  airlineCodes["FL"] =	"AirTran";
  airlineCodes["G4"] =	"Allegiant";
  airlineCodes["GQ"] =	"Big Sky";
  airlineCodes["HA"] =	"Hawaiian";
  airlineCodes["HP"] =	"America West";
  airlineCodes["HQ"] =	"Harmony";
  airlineCodes["IB"] =	"Iberia";
  airlineCodes["JK"] =	"Spanair";
  airlineCodes["JL"] =	"JAL";
  airlineCodes["JM"] =	"Air Jamaica";
  airlineCodes["KE"] =	"Korean";
  airlineCodes["KU"] =	"Kuwait";
  airlineCodes["KX"] =	"Cayman";
  airlineCodes["LA"] =	"LanChile";
  airlineCodes["LH"] =	"Lufthansa";
  airlineCodes["LO"] =	"LOT";
  airlineCodes["LT"] =	"LTU";
  airlineCodes["LW"] =	"Pacific Wings";
  airlineCodes["LX"] =	"SWISS";
  airlineCodes["LY"] =	"El Al";
  airlineCodes["MA"] =	"MALEV";
  airlineCodes["MH"] =	"Malaysia";
  airlineCodes["MU"] =	"China Eastern";
  airlineCodes["MX"] =	"Mexicana";
  airlineCodes["NH"] =	"ANA";
  airlineCodes["NK"] =	"Spirit";
  airlineCodes["NW"] =	"Northwest";
  airlineCodes["NZ"] =	"Air New Zealand";
  airlineCodes["OS"] =	"Austrian";
  airlineCodes["OZ"] =	"Asiana";
  airlineCodes["PN"] =	"Pan American";
  airlineCodes["PR"] =	"Philippine";
  airlineCodes["QF"] =	"Qantas";
  airlineCodes["QK"] =	"Air Canada Jazz";
  airlineCodes["RG"] =	"VARIG";
  airlineCodes["SA"] =	"South African";
  airlineCodes["SK"] =	"SAS";
  airlineCodes["SN"] =	"SN Brussels";
  airlineCodes["SQ"] =	"Singapore";
  airlineCodes["SU"] =	"Aeroflot";
  airlineCodes["SY"] =	"Sun Country";
  airlineCodes["TA"] =	"Taca";
  airlineCodes["TG"] =	"Thai";
  airlineCodes["TK"] =	"Turkish";
  airlineCodes["TN"] =	"Air Tahiti Nui";
  airlineCodes["TP"] =	"TAP";
  airlineCodes["TS"] =	"Air Transat";
  airlineCodes["U5"] =	"USA 3000";
  airlineCodes["UA"] =	"United";
  airlineCodes["UP"] =	"Bahamasair";
  airlineCodes["US"] =	"US Air";
  airlineCodes["V3"] =	"Copa";
  airlineCodes["VS"] =	"Virgin Atlantic";
  airlineCodes["VX"] =	"Virgin America";
  airlineCodes["WA"] =	"Western";
  airlineCodes["WN"] =	"Southwest";
  airlineCodes["WS"] =	"WestJet";
  airlineCodes["XE"] =	"ExpressJet";
  airlineCodes["Y2"] =	"Globespan";
  airlineCodes["Y7"] =	"Silverjet";
  airlineCodes["YV"] =	"Mesa";
  airlineCodes["YX"] =	"Midwest";
  airlineCodes["ZK"] =	"Great Lakes";
  return airlineCodes[code];
}
