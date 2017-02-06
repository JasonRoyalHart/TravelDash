$(function() {
    $("#search").on("click", function() {
      var searchTerm = $("#searchTerm").val();
    var url = "http://api.openweathermap.org/data/2.5/weather?&units=imperial&APPID=aa6b1550989d2570caa91f5781d5c8b4&q="+ searchTerm;
    $.ajax({
      url: url,
      method: 'GET',
          dataType: "jsonp",
          success: function(response) {
            $("#output").html();
              $("#output").prepend("<div><div class='well'><img src= " + " ' " + response.weather[0]["icon"] + " ' " + "><p>" + "Current weather forecast is: " + response.weather[0].description + "</p>" + "<p>" + "Current temperature is: " + response.main.temp + "</p>" + "<p>" + "Current wind speed is: " + response.wind.speed + "</p> </a></div></div>");       
          console.log(response);
          }
     })
    .done(function() {
      console.log("success");
    })
    .fail(function() {
      console.log("error");
    })
    .always(function() {
      console.log("complete");
    })
    });
  });
