$(".btn-menu").click(function () {
    $(".menu-principal .menu").slideToggle();
});

$(window).resize(function () {
    if ($(document).width() > 991) {
        $(".menu-principal .menu").css({ "display": "block" });
    } else {
        $(".menu-principal .menu").css({ "display": "none" });
    }
});