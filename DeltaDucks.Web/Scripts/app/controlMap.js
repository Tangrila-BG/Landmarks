var App;
(function (App) {
    var GoogleMap;
    (function (GoogleMap) {
        class ControlMap {
            constructor() {
                this.resizeControl = (controlDiv, map) => {
                    // Set CSS for the control border.
                    var controlUI = document.createElement('div');
                    controlUI.style.backgroundColor = '#fff';
                    controlUI.style.border = '2px solid #fff';
                    controlUI.style.borderRadius = '3px';
                    controlUI.style.boxShadow = '0 2px 6px rgba(0,0,0,.3)';
                    controlUI.style.cursor = 'pointer';
                    controlUI.style.marginBottom = '22px';
                    controlUI.style.textAlign = 'center';
                    controlUI.title = 'Click to resize the map';
                    controlUI.id = "landmarks-map-resize";
                    controlDiv.appendChild(controlUI);
                    // Set CSS for the control interior.
                    var controlText = document.createElement('div');
                    controlText.style.color = 'rgb(25,25,25)';
                    controlText.style.fontFamily = 'Roboto,Arial,sans-serif';
                    controlText.style.fontSize = '16px';
                    controlText.style.lineHeight = '38px';
                    controlText.style.paddingLeft = '5px';
                    controlText.style.paddingRight = '5px';
                    controlText.innerHTML = 'Увеличи';
                    controlUI.appendChild(controlText);
                    // Setup the click event listeners: simply set the map to Chicago.
                    controlUI.addEventListener('click', function () {
                        map.setCenter(map.getCenter());
                    });
                    map.controls[google.maps.ControlPosition.LEFT_BOTTOM].push(controlDiv);
                };
            }
        }
        GoogleMap.ControlMap = ControlMap;
    })(GoogleMap = App.GoogleMap || (App.GoogleMap = {}));
})(App || (App = {}));
//# sourceMappingURL=controlMap.js.map