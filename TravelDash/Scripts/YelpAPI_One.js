

function cb(data) {
    console.log("cb: " + JSON.stringify(data));
}

var auth = {
    consumerKey: "-H424RZyK5jKczrI6U7TSg",
    consumerSecret: "Hr9xu-dzpsfEvYK0x6zJa6jMhJ4",
    accessToken: "_zmDBvb401h8pw7tfCIWkyuwt1nrOd0g",
    accessTokenSecret: "oM_rtzpoZ2GG_yIqWqAvJaBWCz4",
    serviceProvider: {
        signatureMethod: "HMAC-SHA1"
    }
};


$('form').submit(function (event) {
    event.preventDefault();
    var terms = $("#termInput").val();
    var near = $("#nearInput").val();



    var accessor = {
        consumerSecret: auth.consumerSecret,
        tokenSecret: auth.accessTokenSecret
    };

    var parameters = [];
    parameters.push(['term', terms]);
    parameters.push(['location', near]);
    parameters.push(['category', 'restaurants'])
    parameters.push(['sort', 2])
    parameters.push(['callback', 'cb']);
    parameters.push(['oauth_consumer_key', auth.consumerKey]);
    parameters.push(['oauth_consumer_secret', auth.consumerSecret]);
    parameters.push(['oauth_token', auth.accessToken]);
    parameters.push(['oauth_signature_method', 'HMAC-SHA1']);

    var message = {
        'action': 'https://api.yelp.com/v2/search',
        'method': 'GET',
        'parameters': parameters
    };

    OAuth.setTimestampAndNonce(message);
    OAuth.SignatureMethod.sign(message, accessor);

    var parameterMap = OAuth.getParameterMap(message.parameters);

    $.ajax({
        'url': message.action,
        'data': parameterMap,
        'dataType': 'jsonp',
        'jsonpCallback': 'cb',
        'cache': true,
        success: function (data) {
            parseData(data);
        },
        error: function (data) {
            console.log(data);
        }
    })
    $("#chooseButton").show();
});

function parseData(data) {
    for (let i = 0; i < data.businesses.length; i++) {
        currentResults = formatRow(data["businesses"][(i.toString())]);
        $("#resultsTable").append(currentResults);
    }
}
function formatRow(object) {
    cleanedObject = "<tr><td><form> <input type=" + "'" + "radio" + "' " + "name=" + "'" + "select" + "' " + "value=" + "'" + "other" + "'" +
    "></form></td><td><img src=" + object["image_url"] +
    "></td><td><img src=" + object["rating_img_url_small"] +
    "><td><b>" + object.name +
    "</b></td><td>" + object["display_phone"] +
    "</td><td>" + object["categories"]["0"]["0"] +
    "</td><td>" + object["snippet_text"] +
    "</td><td><a href=" + object["url"] +
    ">" + "More info" + "</a></td>" +
    "</tr>";
    return cleanedObject;
}