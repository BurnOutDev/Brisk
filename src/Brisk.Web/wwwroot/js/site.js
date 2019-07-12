var content = $('#content-container');
var settings = $('#settings-container');

$('#settings-btn').on('click', function () {
    content.addClass('hidden');
    settings.removeClass('hidden');
    $('#settings-btn').addClass('active');
    $('#new-game-btn').removeClass('active');
});

$('#new-game-btn').on('click', function () {
    settings.addClass('hidden');
    content.removeClass('hidden');
    $('#new-game-btn').addClass('active');
    $('#settings-btn').removeClass('active');
});