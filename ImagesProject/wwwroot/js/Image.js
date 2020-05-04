$(() => {

    let id = $("#like-btn").data("id");
    function updateLikes() {
        $.get('/home/getLikes', { id }, function (obj) {
            $("#likes").text(`${obj.likes}`);
        });
    }

    setInterval(() => {
        updateLikes()
    }, 100);

    $("#like-btn").click(function () {
        $.post('/home/likeimage', { id }, function () {
            $('#like-btn').prop('disabled', true);
            updateLikes(id);
        });
    });
});