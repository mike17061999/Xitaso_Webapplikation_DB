$(document).ready(function () {
    //$("#analysen").hide();
    //$(".card").css("background-color", "yellow");
    //$("#2").css("background-color", "yellow");
    //$("#2").show();
    //$(".testklasse").css("background-color", "yellow");
    $(".projectCard").on("click", function () {
        //$(".analysen").hide();
        //$(event.target).css("background-color", "blue");
        //alert(event.target.closest('div').className);
        analyseID = event.target.parentElement.id;
        console.log(analyseID);
        //$('#' + analyseID ".analysen").hide();
        //$("#2, .projectanalysis").hide();
        //$(".projectanalysis").hide();
        //$(".projectanalysis").filter($("#1")).hide();
        $(".projectanalysis").filter(function () {
            return $(this).attr("id") === analyseID;
        }).show().siblings().hide();
    });
});