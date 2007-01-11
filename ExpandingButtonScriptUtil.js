//Original MetaBuilders : www.metabuilders.com
function ExpandingButtons_Init() {
	if ( !ExpandingButtons_BrowserCapable() ) { return; }
	if ( MetaBuilders_WebControls_ExpandingButtons.length % 6 != 0 ) {
		alert("MetaBuilders ExpandingButtons has a problem. Please check the page configuration.");
	}
	for( var i=0; i<MetaBuilders_WebControls_ExpandingButtons.length; i += 6 ) {
		var expanderControl = document.getElementById( MetaBuilders_WebControls_ExpandingButtons[i] );
		var targetControl = document.getElementById( MetaBuilders_WebControls_ExpandingButtons[i+1] );
		var trackerControl = document.getElementById( MetaBuilders_WebControls_ExpandingButtons[i+2] );
		var expandedValue = MetaBuilders_WebControls_ExpandingButtons[i+3];
		var contractedValue = MetaBuilders_WebControls_ExpandingButtons[i+4];
		var valueChanger = MetaBuilders_WebControls_ExpandingButtons[i+5];
		if ( expanderControl != null && targetControl != null ) {
			expanderControl.TargetControl = targetControl;
			expanderControl.TrackerControl = trackerControl;
			expanderControl.ToggleView = ExpandingButtons_Toggle;
			expanderControl.onclick = expanderControl.ToggleView;
			expanderControl.ExpandedValue = expandedValue;
			expanderControl.ContractedValue = contractedValue;
			switch( valueChanger ) {
				case "b":
					expanderControl.ToggleValue = ExpandingButtons_ToggleButtonText;
					break;
				case "l":
					expanderControl.ToggleValue = ExpandingButtons_ToggleLinkText;
					break;
				case "i":
					expanderControl.ToggleValue = ExpandingButtons_ToggleImageSrc;
					break;
				case "c":
					expanderControl.ToggleValue = ExpandingButtons_ToggleCheckBoxChecked;
					break;
				default:
					expanderControl.ToggleValue = function() { return true; };
			}
		} else {
			alert("MetaBuilders ExpandingButtons has a problem. Please check the page configuration.");
		}
	}
}
function ExpandingButtons_BrowserCapable() {
	if ( typeof( document.getElementById ) == "undefined" ) {
		return false;
	}
	return true;
}
function ExpandingButtons_Toggle() {
	if ( typeof( window.event ) != "undefined" && typeof( window.event.returnValue ) != "undefined" ) {
		window.event.returnValue = false;
	}
	if ( this.TargetControl.style.display == "none" ) {
		this.TargetControl.style.display = "";
		if ( this.TrackerControl != null ) {
			this.TrackerControl.value = "True";
		}
		return this.ToggleValue(this.ExpandedValue);
	} else {
		this.TargetControl.style.display = "none";
		if ( this.TrackerControl != null ) {
			this.TrackerControl.value = "False";
		}
		return this.ToggleValue(this.ContractedValue);
	}
}
function ExpandingButtons_ToggleButtonText(newValue) {
	this.value = newValue;
	return false;
}
function ExpandingButtons_ToggleLinkText(newValue) {
	this.innerText = newValue;
	return false;
}
function ExpandingButtons_ToggleImageSrc(newValue) {
	var newValues = newValue.split("__");
	this.alt = newValues[0];
	this.src = newValues[1];
	return false;
}
function ExpandingButtons_ToggleCheckBoxChecked(newValue) {
	return ( ( newValue == "true" ) == this.checked );
}