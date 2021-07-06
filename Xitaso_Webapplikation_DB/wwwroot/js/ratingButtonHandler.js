$(document).ready(function () {
    //$("#analysen").hide();
    //$(".card").css("background-color", "yellow");
    //$("#2").css("background-color", "yellow");
    //$("#2").show();
    //$(".testklasse").css("background-color", "yellow");
    $(".ist").on("click", function () {
        $(this).css("background", "#EDC951").siblings().css("background", "white");
    });
    $(".soll").on("click", function () {
        $(this).css("background", "#CC333F").siblings().css("background", "white");
    });
});

//"#EDC951", "#CC333F"
//test