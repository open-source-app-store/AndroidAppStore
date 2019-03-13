/**
 *  Document   : pages.js
 *  Author     : @M!R
 *  Description: pages script
 *
 **/
// Toggle Function
$(document).on('click','.toggle',function(){ 
	'use strict';
  // Switches the Icon and form
  if($(this).children('i').attr('class')=='fa fa-user-plus')
  {
      $(this).children('i').removeClass('fa-user-plus');
      $(this).children('i').addClass('fa-times');
      //$('.formLogin').slideUp("slow");
      //$('.formRegister').slideDown("slow");
  }
  else
  {
      $(this).children('i').removeClass('fa-times');
      $(this).children('i').addClass('fa-user-plus');
      $('.formLogin').slideDown("slow");
      if($('.formRegister').is(':visible'))
         $('.formRegister').slideUp("slow");
      else
    	 $('.formReset').slideUp("slow");
  }
  
});

$(document).on('click','.forgetPassword a',function(){ 
	'use strict';
  // Switches the Icon and form
  $('.toggle').children('i').removeClass('fa-user-plus');
  $('.toggle').children('i').addClass('fa-times');
  $('.formLogin').slideUp("slow");
  $('.formReset').slideDown("slow");
});

$(window).resize(function(){
	 $( "body" ).css( "min-height",$( window ).height() );
});
$(document).ready(function(){
	 $( "body" ).css( "min-height",$( window ).height() );
});