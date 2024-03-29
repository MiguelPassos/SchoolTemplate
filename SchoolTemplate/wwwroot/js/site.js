﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    $(".alert").delay(1000).slideDown(200).delay(6000).slideUp(200);

	document.addEventListener('contextmenu', event => event.preventDefault());

    jQuery.event.special.touchstart = {
        setup: function (_, ns, handle) {
            if (ns.includes("noPreventDefault")) {
                this.addEventListener("touchstart", handle, { passive: false });
            } else {
                this.addEventListener("touchstart", handle, { passive: true });
            }
        }
    };

    jQuery.event.special.touchmove = {
        setup: function (_, ns, handle) {
            if (ns.includes("noPreventDefault")) {
                this.addEventListener("touchmove", handle, { passive: false });
            } else {
                this.addEventListener("touchmove", handle, { passive: true });
            }
        }
    };

    jQuery.event.special.wheel = {
        setup: function (_, ns, handle) {
            this.addEventListener("wheel", handle, { passive: true });
        }
    };

    jQuery.event.special.mousewheel = {
        setup: function (_, ns, handle) {
            this.addEventListener("mousewheel", handle, { passive: true });
        }
	};

	$("#reg-box .cpf, #reg-box .username, #reg-box input[type='password']").bind({
		mousemove: changeTooltipPosition,
		mouseenter: showTooltip,
		mouseleave: hideTooltip
	});

	$(".modal").on('hide.bs.modal', function () {
		$(".user-box input[type='text'], .user-box input[type='password']").val('');
	});

	$("#dropdownMenu1").on('click', function () {
		$("#divLogin input[type='text'], #divLogin input[type='password']").val('');
	});

	$('#divLogin a').on('click', function () {
		$(document).click();
	});

	if ($('#message-box') != undefined)
		$('#message-box').modal();
});


//Customs JS Scripts
jQuery(document).ready(function ($) {
	"use strict";

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-1').length) {
		$("#owl-carousel-1").owlCarousel({
			items: 1, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-2').length) {
		$("#owl-carousel-2").owlCarousel({
			items: 2, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-3').length) {
		$("#owl-carousel-3").owlCarousel({
			items: 3, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-4').length) {
		$("#owl-carousel-4").owlCarousel({
			items: 4, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true,
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-5').length) {
		$("#owl-carousel-5").owlCarousel({
			items: 5, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-6').length) {
		$("#owl-carousel-6").owlCarousel({
			items: 6, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-7').length) {
		$("#owl-carousel-7").owlCarousel({
			items: 7, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-8').length) {
		$("#owl-carousel-8").owlCarousel({
			items: 8, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-9').length) {
		$("#owl-carousel-9").owlCarousel({
			items: 9, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-carousel-10').length) {
		$("#owl-carousel-10").owlCarousel({
			items: 10, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($(".owl-slider-carousel").length) {
		$(".owl-slider-carousel").owlCarousel({
			items: 3, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 2], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-demo-main').length) {
		$("#owl-demo-main").owlCarousel({
			items: 1, //10 items above 1000px browser width
			itemsDesktop: [1000, 1], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 1], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-demo-blog').length) {
		$("#owl-demo-blog").owlCarousel({
			items: 1, //10 items above 1000px browser width
			itemsDesktop: [1000, 1], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 1], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
		});

		// Custom Navigation Events
		$(".next").on('click', function () {
			owl.trigger('owl.next');
		})
		$(".prev").on('click', function () {
			owl.trigger('owl.prev');
		})
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-demo-8').length) {
		$("#owl-demo-8").owlCarousel({
			items: 4, //10 items above 1000px browser width
			itemsDesktop: [1000, 3], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 3], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false, // itemsMobile disabled - inherit from itemsTablet option
			navigation: true
		});
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-demo-1').length) {
		$("#owl-demo-1").owlCarousel({
			items: 3, //10 items above 1000px browser width
			itemsDesktop: [1000, 2], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 2], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: [400, 1] // itemsMobile disabled - inherit from itemsTablet option
		});

		// Custom Navigation Events
		$(".next").on('click', function () {
			owl.trigger('owl.next');
		})
		$(".prev").on('click', function () {
			owl.trigger('owl.prev');
		})
		$(".play").on('click', function () {
			owl.trigger('owl.play', 1000); //owl.play event accept autoPlay speed as second parameter
		})
		$(".stop").on('click', function () {
			owl.trigger('owl.stop');
		})

	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-demo-9').length) {
		$("#owl-demo-9").owlCarousel({
			items: 2, //10 items above 1000px browser width
			itemsDesktop: [1000, 2], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 2], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: [400, 1] // itemsMobile disabled - inherit from itemsTablet option
		});

		// Custom Navigation Events
		$(".next").on('click', function () {
			owl.trigger('owl.next');
		})
		$(".prev").on('click', function () {
			owl.trigger('owl.prev');
		})
		$(".play").on('click', function () {
			owl.trigger('owl.play', 1000); //owl.play event accept autoPlay speed as second parameter
		})
		$(".stop").on('click', function () {
			owl.trigger('owl.stop');
		})
	}

	/*
	==============================================================
	   OwlCarousel Script Start
	============================================================== */
	if ($('#owl-demo-23').length) {
		$("#owl-demo-23").owlCarousel({
			autoPlay: 3000, //Set AutoPlay to 3 seconds
			items: 1, //10 items above 1000px browser width
			itemsDesktop: [1000, 1], //5 items between 1000px and 901px
			itemsDesktopSmall: [900, 1], // betweem 900px and 601px
			itemsTablet: [600, 1], //2 items between 600 and 0
			itemsMobile: false // itemsMobile disabled - inherit from itemsTablet option
		});
	}

	/*
	==============================================================
	   SelectBox Script Start
	============================================================== */
	if ($("#select-menu").length) {
		$("#select-menu").selectbox();
	}

	/*
	==============================================================
	   Select Script Start
	============================================================== */
	if ($("select").length) {
		$('select').selectric();
	}

	/*
	==============================================================
	   VTicker Script Start
	============================================================== */
	if ($("#news").length) {
		$('#news').vTicker();
	}

	/*
	==============================================================
	   Slidr Menu Script Start
	============================================================== */
	if ($("#simple-menu").length) {
		$('#simple-menu').sidr();
	}

	/*
	==============================================================
	   Responsive Menu Script Start
	============================================================== */
	if ($("#responsive-menu-button").length) {
		$('#responsive-menu-button').sidr({
			name: 'sidr-main',
			source: '#navigation'
		});
	}

	/*
	==============================================================
	   CountDown Script Start
	============================================================== */
	if ($('.countdown').length) {
		$('.countdown').downCount({ date: '08/08/2016 12:00:00', offset: +1 });
	}

	/*
	==============================================================
	   Counter Script Start
	============================================================== */
	if ($('.counter').length) {
		$('.counter').counterUp({
			delay: 10,
			time: 1000
		});
	}


	/*
	==============================================================
	   BXSLider Script Start
	============================================================== */
	if ($('.bxslider').length) {
		$('.bxslider').bxSlider({
			pagerCustom: '#bx-pager'
		});
	}

	/*
	==============================================================
	   PROGRESS BAR Script Start
	============================================================== */

	if ($('.progressbar').length) {
		$('.progressbar').each(function () {
			var t = $(this),
				dataperc = t.attr('data-perc'),
				barperc = parseInt(Math.round(dataperc * 5.56), 10);
			t.find('.bar').animate({ width: barperc }, dataperc * 25);
			t.find('.label').append('<div class="perc"></div>');

			function perc() {
				var length = t.find('.bar').css('width'),
					perc = Math.round(parseInt(length) / 5.56, 10),
					labelpos = (parseInt(length) - 2, 10);
				t.find('.label').css('left', labelpos);
				t.find('.perc').text(perc + '%');
			}
			perc();
			setInterval(perc, 0);
		});
	}

	/*
	==============================================================
	   Filterable Script Start
	============================================================== */
	if ($('#filterable-item-holder-1').length) {
		jQuery(window).load(function () {
			var filter_container = jQuery('#filterable-item-holder-1');

			filter_container.children().css('position', 'relative');
			filter_container.masonry({
				singleMode: true,
				itemSelector: '.filterable-item:not(.hide)',
				animate: true,
				animationOptions: { duration: 800, queue: false }
			});
			jQuery(window).resize(function () {
				var temp_width = filter_container.children().filter(':first')();
				filter_container.masonry({
					columnWidth: temp_width,
					singleMode: true,
					itemSelector: '.filterable-item:not(.hide)',
					animate: true,
					animationOptions: { duration: 800, queue: false }
				});
			});
			jQuery('ul#filterable-item-filter-1 a').on('click', function (e) {

				jQuery(this).addClass("active");
				jQuery(this).parents("li").siblings().children("a").removeClass("active");
				e.preventDefault();

				var select_filter = jQuery(this).attr('data-value');

				if (select_filter == "All" || $(this).parent().index() == 0) {
					filter_container.children().each(function () {
						if ($(this).hasClass('hide')) {
							$(this).removeClass('hide');
							$(this).fadeIn();
						}
					});
				} else {
					filter_container.children().not('.' + select_filter).each(function () {
						if (!$(this).hasClass('hide')) {
							$(this).addClass('hide');
							$(this).fadeOut();
						}
					});
					filter_container.children('.' + select_filter).each(function () {
						if ($(this).hasClass('hide')) {
							$(this).removeClass('hide');
							$(this).fadeIn();
						}
					});
				}

				filter_container.masonry();

			});
		});
	}

	/*
	==============================================================
	   PrettyPhoto Script Start
	============================================================== */
	if ($("area[data-rel^='prettyPhoto']").length) {
		$("area[data-rel^='prettyPhoto']").prettyPhoto();
	}



	/*
	==============================================================
	   PrettyPhoto Script Start
	============================================================== */
	if ($(".edu_masonery_thumb a[data-rel^='prettyPhoto']").length) {
		$(".edu_masonery_thumb:first a[data-rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'light_square', slideshow: 3000, autoplay_slideshow: true });
		$(".edu_masonery_thumb:gt(0) a[data-rel^='prettyPhoto']").prettyPhoto({});
	}

	/*
	==============================================================
	   PrettyPhoto Script Start
	============================================================== */
	if ($(".gallery a[rel^='prettyPhoto']").length) {
		$(".gallery:first a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'normal', theme: 'light_square', slideshow: 3000, autoplay_slideshow: true });
		$(".gallery:gt(0) a[rel^='prettyPhoto']").prettyPhoto({});
	}

	/*
	==============================================================
	   SlideToggle Script Start
	============================================================== */
	$(".show").on('click', function () {
		$(".searchform").slideToggle("slow", function () {
			// Animation complete.
		});
	});

	/*
	==============================================================
	   Map Script Start
	============================================================== */
	if ($('#map-canvas').length) {
		google.maps.event.addDomListener(window, 'load', initialize);
	}


	/*
	==============================================================
	   Map Script Start
	============================================================== */
	if ($('.defaultCountdown').length) {
		var newYear = new Date();
		newYear = new Date(newYear.getFullYear() + 1, 1 - 1, 1);
		$('.defaultCountdown').countdown({ until: newYear });
	}

});


/* ---------------------------------------------------------------------- */
/*	Google Map Function for Custom Style
/* ---------------------------------------------------------------------- */
function initialize() {
	var MY_MAPTYPE_ID = 'custom_style';
	var map;
	var brooklyn = new google.maps.LatLng(40.6743890, -73.9455);
	var featureOpts = [
		{
			stylers: [
				{ hue: '#f9f9f9' },
				{ visibility: 'simplified' },
				{ gamma: 0.7 },
				{ saturation: -200 },
				{ lightness: 15 },
				{ weight: 0.6 }
			]
		},
		{
			featureType: "road",
			elementType: "geometry",
			stylers: [
				{ lightness: 30 },
				{ visibility: "simplified" }
			]
		},
		{
			elementType: 'labels',
			stylers: [
				{ visibility: 'on' }
			]
		},
		{
			featureType: 'water',
			stylers: [
				{ color: '#ffffff' }
			]
		}
	];

	var mapOptions = {
		zoom: 13,
		scrollwheel: false,
		center: brooklyn,
		mapTypeControlOptions: {
			mapTypeIds: [google.maps.MapTypeId.ROADMAP, MY_MAPTYPE_ID]
		},
		mapTypeId: MY_MAPTYPE_ID
	};

	map = new google.maps.Map(document.getElementById('map-canvas'),
		mapOptions);

	var styledMapOptions = {
		name: 'Custom Style'
	};

	var customMapType = new google.maps.StyledMapType(featureOpts, styledMapOptions);

	map.mapTypes.set(MY_MAPTYPE_ID, customMapType);
}