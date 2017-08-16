// jQuery for page scrolling feature - requires jQuery Easing plugin
$(function() {
    $('.page-scroll a').bind('click', function(event) {
        var $anchor = $(this);
        $('html, body').stop().animate({
            scrollTop: $($anchor.attr('href')).offset().top
        }, 1500, 'easeInOutExpo');
        event.preventDefault();
    });

    /* USAGE
            
            $('#pink').hoverZoom({
                overlay: true, // false to turn off (default true)
                overlayColor: '#2e9dbd', // overlay background color
                overlayOpacity: 0.7, // overlay opacity
                zoom: 25, // amount to zoom (px)
                speed: 300 // speed of the hover
            });
            
            */

    $('.blue').hoverZoom({
        overlayColor: '#3498db',
        zoom: 0
    });
});