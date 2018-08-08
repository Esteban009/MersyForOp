$(function () {
    var articleId = window.location.pathname.split('/')[2];
    if ($('#ratingCount').text() == '0') {
        $('.rating-value').text('Not yet rated. Be the first!').removeAttr('itemprop');
        $('.rating-count').hide();
    }

    var initRating = function () {
        return $('.star-rating .fa').each(function () {
            if (parseFloat($('#rating-value').val()) >= parseFloat($(this).data('rating'))) {
                return $(this).removeClass('fa-star-o fa-star-half-o').addClass('fa-star');
            } else {
                if (parseFloat($('#rating-value').val()) > parseFloat($(this).prev().data('rating'))) {
                    return $(this).removeClass('fa-star-o fa-star').addClass('fa-star-half-o');
                }
                else {
                    return $(this).removeClass('fa-star fa-star-half-o').addClass('fa-star-o');
                }
            }
        });
    };

    $('.star-rating .fa').on('click', function () {
        $.post('/article/rate', { rating: $(this).data('rating'), id: articleId }, function (data) {
            if (data == "false") {
                alert('You have already rated this article');
            } else {
                $('#rating-value').val(data.AverageRating.toFixed(2));
                $('span.rating-value').text(data.AverageRating.toFixed(2));
                $('.rating-count').show();
                $('#ratingCount').text(data.TotalRaters)
                $('.rating-vote').text(data.TotalRaters > 1 ? 'votes' : 'vote');
                $('#current-rating').effect('highlight', { color: '#ff9900' }, 2000);
            }
            return initRating();
        });
    });

    $('.star-rating i.fa').on('mouseenter', function (e) {
        var currentStar = $(this).index();
        $('.star-rating i.fa').each(function (i, v) {
            if (i <= currentStar) {
                $(this).removeClass('fa-star-o fa-star-half-o').addClass('fa-star');
            } else {
                $(this).removeClass('fa-star fa-star-half-o').addClass('fa-star-o');
            }
        })
    });
    $('.star-rating').on('mouseleave', function () {
        return initRating();
    });

    initRating();

    // show comment form if article less than 3 months old
    if (Date.parse($('time[itemprop="datePublished"]').first().text()) > new Date().getTime() - (90 * 24 * 60 * 60 * 1000)) {
        $('#comment-form-wrapper').load('/comment/form', function () {
            $.validator.unobtrusive.parse($("#comment-form"));
            $('#url').val(window.location.href);
        });
    }

    $.post('/article/addview/' + articleId);
    $("#comment-form-wrapper").on('submit', function (e) {
        e.preventDefault();

        var url = $('#comment-form').attr('action');
        var data = $('#comment-form').serialize();
        $('#comment-form').validate();
        if ($('#comment-form').valid()) {
            $('#spinner').empty().html('<img src="/images/loading2.gif" />');
            $.ajax({
                url: url,
                type: "POST",
                data: data,
                success: function (data) {
                    $('#comment-form-wrapper').slideUp('slow').empty();
                    if (data == "True") {
                        $('#success').show();
                    } else {
                        $('#error').show();
                    }
                },
                error: function () {
                    $('#comment-form-wrapper').slideUp('slow').empty();
                    $('#error').show();
                }
            });
        }
    });
});