// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$('.card').click(function () {
    $(".active").removeClass("active");
    $(this).toggleClass('active');

    //get the id of the clicked element 
    var elmId = $(this).attr("id");
});
