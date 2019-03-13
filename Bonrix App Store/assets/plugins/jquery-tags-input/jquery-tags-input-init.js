

//tags input

$('.tags-input').each(function() {
    var tagsType = $(this).data('type')
    if (tagsType === 'tags') {
        $(this).tagsInput({
            width: 'auto'
            	
        });
    }
    if (tagsType === 'fruits-tags') {
        $(this).tagsInput({
            width: 'auto'
            	 
        	  // change color of specific string code
        	    ,onChange: function(elem, elem_tags) {
                 var languages = ['apple', 'banana', 'guava'];
                 var highlightColor = $(this).data('highlight-color');
                 $('.tag', elem_tags).each(function() {
                     if ($(this).text().search(new RegExp('\\b(' + languages.join('|') + ')\\b')) >= 0) $(this).css('background-color', highlightColor);
                 });
             }
        });
    }
    if (tagsType === 'fixedWidth-tags') {
        $(this).tagsInput({
            width: '350',
        });
    }
});

