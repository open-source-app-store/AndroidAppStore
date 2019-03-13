
"use strict";
$(document).ready(function () {
    

      $(".tstInfo").on("click",function(){
           $.toast({
            heading: 'Welcome to my Elite admin',
            text: 'Use the predefined ones, or specify a custom position object.',
            position: 'top-right',
            loaderBg:'#ff6849',
            icon: 'info',
            hideAfter: 3000, 
            stack: 6
          });

     });

      $(".tstWarning").on("click",function(){
           $.toast({
            heading: 'Welcome to my Elite admin',
            text: 'Use the predefined ones, or specify a custom position object.',
            position: 'top-right',
            loaderBg:'#ff6849',
            icon: 'warning',
            hideAfter: 3500, 
            stack: 6
          });

     });
      $(".tstSuccess").on("click",function(){
           $.toast({
            heading: 'Welcome to my Elite admin',
            text: 'Use the predefined ones, or specify a custom position object.',
            position: 'top-right',
            loaderBg:'#ff6849',
            icon: 'success',
            hideAfter: 3500, 
            stack: 6
          });

     });

      $(".tstError").on("click",function(){
           $.toast({
            heading: 'Welcome to my Elite admin',
            text: 'Use the predefined ones, or specify a custom position object.',
            position: 'top-right',
            loaderBg:'#ff6849',
            icon: 'error',
            hideAfter: 3500
            
          });

     });
      $(".tstSimple").on("click",function(){
    	  $.toast({
    		  	position: 'top-left',
    		    text: 'This will become the toast message'
    		})
      }); 
      $(".tstArray").on("click",function(){
    	  $.toast({
      	    heading: 'How to contribute?!',
      	    position: 'top-left',
      	    text: [
      	        'Fork the repository', 
      	        'Improve/extend the functionality', 
      	        'Create a pull request'
      	    ],
      	    icon: 'info'
      	})

    });
      
      $(".tstHtml").on("click",function(){
    	  $.toast({
    		    heading: 'Can I add <em>icons</em>?',
    		    position: 'top-left',
    		    text: 'Yes! check this <a href="https://github.com/kamranahmedse/jquery-toast-plugin/commits/master">update</a>.',
    		    hideAfter: false,
    		    icon: 'success'
    		})

    });
      $(".tstSticky").on("click",function(){
    	  $.toast({
    		    text: 'Set the `hideAfter` property to false and the toast will become sticky.',
    		    hideAfter: false
    		})
    }); 
//      Animation
      $(".tstFade").on("click",function(){
    	  $.toast({
    		    text: 'Set the `showHideTransition` property to fade|plain|slide to achieve different transitions',
    		    heading: 'Fade transition',
    		    position: 'top-left',
    		    showHideTransition: 'fade'
    		})
      });
      $(".tstSlide").on("click",function(){
    	  $.toast({
    		    text: 'Set the `showHideTransition` property to fade|plain|slide to achieve different transitions',
    		    heading: 'Slide transition',
    		    position: 'top-left',
    		    showHideTransition: 'slide'
    		})
      });
      $(".tstPlain").on("click",function(){
    	  $.toast({
    		    text: 'Set the `showHideTransition` property to fade|plain|slide to achieve different transitions',
    		    heading: 'Plain transition',
    		    position: 'top-left',
    		    showHideTransition: 'plain'
    		})
      });
//      position

      $(".tstBtmLeft").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Specify the custom position object or use one of the predefined ones',
    		    position: 'bottom-left',
    		    stack: false
    		})
      });
      $(".tstBtmRight").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Specify the custom position object or use one of the predefined ones',
    		    position: 'bottom-right',
    		    stack: false
    		})
      });
      $(".tstBtmCenter").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Use the predefined ones, or specify a custom object',
    		    position: 'bottom-center',
    		    stack: false
    		})
      });
      $(".tstTopLeft").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Use the predefined ones, or specify a custom object',
    		    position: 'top-left',
    		    stack: false
    		})
      });
      $(".tstTopCenter").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Use the predefined ones, or specify a custom position object.',
    		    position: 'top-center',
    		    stack: false
    		})
      });
      $(".tstTopRight").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Use the predefined ones, or specify a custom position object.',
    		    position: 'top-right',
    		    stack: false
    		})
      });
      $(".tstMidCenter").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Use the predefined ones, or specify a custom position object.',
    		    position: 'mid-center',
    		    stack: false
    		})
      });
      $(".tstCustom").on("click",function(){
    	  $.toast().reset('all');
    	  $.toast({
    		    heading: 'Positioning',
    		    text: 'Use the predefined ones, or specify a custom position object.',
    		    position: {
    		        left: 120,
    		        top: 120
    		    },
    		    stack: false
    		})
      });
});
//amir
function Notification(textmsg, icons) {
    
    var loader;
    if (icons == "success")
    {
        loader = "#00A65A";
    }
    else
    {
        loader = "#ff6849";
    }
    $.toast().reset('all');
    $.toast({
        text: textmsg,
        position: 'top-center',
        loaderBg: loader,
        icon: icons,
        hideAfter: 3000,
        stack: 6
    });
}
          