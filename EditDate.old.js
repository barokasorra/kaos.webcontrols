function DataUtil(src,mask,e)
{
	var key;
	var keychar;
	var reg;

	var str = src.value
	var i = str.length;
	var saida = mask.substring(0,1);
	var texto = mask.substring(i);

	if (texto.substring(0,1) != saida) 
  	{
	src.value += texto.substring(0,1);
  	}
	
	if(window.event) {
		// for IE, e.keyCode or window.event.keyCode can be used
		key = e.keyCode; 
	}
	else if(e.which) {
		// netscape
		key = e.which; 
	}
	else {
		// no event, so pass through
		return true;
	}
	
	keychar = String.fromCharCode(key);
	reg = /\D/;
	
	var selectedText = document.selection;
	var newRange = selectedText.createRange();
	
	if ( i < 10) {return !reg.test(keychar);}
	else {
	if ( newRange.text == "" ) {
	reg = /\D\d/;return reg.test(keychar);
	}
	} 
}