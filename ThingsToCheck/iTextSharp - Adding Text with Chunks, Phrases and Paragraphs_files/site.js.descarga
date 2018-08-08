(function (i, s, o, g, r, a, m) {
    i['GoogleAnalyticsObject'] = r; i[r] = i[r] || function () {
        (i[r].q = i[r].q || []).push(arguments)
    }, i[r].l = 1 * new Date(); a = s.createElement(o),
    m = s.getElementsByTagName(o)[0]; a.async = 1; a.src = g; m.parentNode.insertBefore(a, m)
})(window, document, 'script', '//www.google-analytics.com/analytics.js', 'ga');

ga('create', 'UA-1264020-9', 'auto');
ga('send', 'pageview');

$(function () {
    if (document.cookie.indexOf("cookies") < 0) {
        $('#cookie-consent').slideDown('slow');
    }
    $('#consent').on('click', function () {
        document.cookie = "cookies=yes; max-age=" + (5 * 365 * 24 * 60 * 60);
        $('#cookie-consent').slideUp('slow');
    });
    $('#learn-more').on('click', function () {
        location.href = '/privacy';
    })
});