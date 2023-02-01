$(document).ready(function(){
    $('.main-slider').slick({
        autoplay: true,
        autoplaySpeed: 5000,
        dots: true,
        slidesToShow: 1,
        slidesToScroll: 1,
        infinite: true,
        arrows: true,
        speed: 500,
        prevArrow: $('.main-slider__arrow-prev'),
        nextArrow: $('.main-slider__arrow-next'),
        fade: true,
        cssEase: 'linear'
    });
});