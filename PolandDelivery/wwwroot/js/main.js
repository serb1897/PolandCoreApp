// Прелоадер
window.onload = function () {
    document.body.classList.add('loaded_hiding');
    window.setTimeout(function () {
        document.body.classList.add('loaded');
        document.body.classList.remove('loaded_hiding');
    }, 500);
}

function print_doc(){
    window.print() ;
}

// Плавная прокрутка к якорю
var $page = $('html, body');
$('a[href*="#"]').click(function() {
    $page.animate({
        scrollTop: $($.attr(this, 'href')).offset().top
    }, 400);
    return false;
});

// Ограничение количества отображаемых символов на странице Новости
$(document).ready(function(){
    $(".short-news__desc").each(function(){
        if ($(this).prop("innerHTML").length > 300){
            let val = $(this).prop("innerHTML");
            $(this).attr("title", val);
            $(this).prop("innerHTML", val.substr(0,300) + "...")
        }
    });
});

// Для печати только одной конкретно открытой новости
$(".news li").on('click', function(e){
    $(this).attr("id","active-tab");
})

//Показать сообщение
function show_message(title, message, isError) {
    $("#popup-title").text(title);
    $("#popup-message").text(message);
    if (isError) {
        $("#popup-form").addClass("popup-notify--error");
    } else {
        $("#popup-form").removeClass("popup-notify--error");
    }
    $('#popup-default_background').css('visibility', 'visible');
    $('#popup-default').css('visibility', 'visible');
}