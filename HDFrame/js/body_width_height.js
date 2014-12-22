function changeSize(){		
		var body_H=$(window).height();
		var main_H=body_H-66;
		var main_W=$(window).width()-186;
		$('.navigotar').height(main_H);
		$('.main_home').height(main_H);
		$('.main_home').width(main_W);
		$('.pro_part1').width(main_W);
		$('.pro_part2').width(main_W);
		$('.pro_part3').width(main_W);
		$('.search_table table').width(main_W);
}
jQuery.clickToggle = function(clickBtn,showCont) {
		$(clickBtn).bind('click',function(){
			$(showCont).toggle();
		})
		return false;
	};
jQuery.navClick = function(navBtn,dropCont) {
		$(clickBtn).toggle(function(){
				$(this).addClass('active'); 
				$(dropCont).show();
			},
		function(){
				$(this).removeClass('active'); 
				$(dropCont).hide();
			})
		return false;
	};