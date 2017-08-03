$(document).ready(function () {
    $('#cardArea1 .card-item').each(function (i, e) {
        $(e).on("mouseenter", function () {
            $(e).addClass("active").siblings().removeClass("active");
        });
    });

    $('.product .item').each(function (i, e) {
        $(e).on("mouseenter", function () {
            $(e).addClass("active").siblings().removeClass("active");
        });
    });
})