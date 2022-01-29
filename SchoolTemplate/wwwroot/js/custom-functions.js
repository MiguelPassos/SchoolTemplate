var changeTooltipPosition = function (event) {
    var tooltipX = event.pageX - 8;
    var tooltipY = event.pageY + 8;
    $('div.tooltip').css({ top: tooltipY, left: tooltipX });
};

var hideTooltip = function () {
    $('div.tooltip').remove();
};

var showTooltip = function (event) {
    var message = $(this).attr('alt');
    $('div.tooltip').remove();
    $('<div class="tooltip">' + message + '</div>').appendTo('body');
    changeTooltipPosition(event);
};