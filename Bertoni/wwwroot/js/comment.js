$(document).ready(function() {
    $('.Handlercomment').click(function() {
        var photoId = $(this).attr('photo-id');
        $.ajax({
            type: 'GET',
            url: `/Photos/${photoId}/Comments`,
            contentType: 'json',
            success: function(response) {
                $("#comments-section").html(response);
            },
            failure: function (err) {
                alert(err);
            },
        });
    });
});