$(document).ready(function () {
    $('#cardArea .card-item').each(function (i, e) {
        $(e).on("mouseenter", function () {
            $(e).addClass("active").siblings().removeClass("active");
        });
    });

    $('#cardArea1 .card-item').each(function (i, e) {
        $(e).on("mouseenter", function () {
            $(e).addClass("active").siblings().removeClass("active");
        });
    });
})