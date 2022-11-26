$(window).scroll(function () {
    if ($(this).scrollTop() >= 350) {
        $('#yukari').fadeIn(200);
    } else {
        $('#yukari').fadeOut(200);
    }
});

$('#yukari').on('click', function () {
    $("html, body").animate({ scrollTop: 0 }, 1000);
});