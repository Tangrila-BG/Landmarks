var App;
(function (App) {
    var GoogleMap;
    (function (GoogleMap) {
        class LandmarkMap {
            constructor(container, mapService) {
                this.loadLandmarks = () => {
                    // TODO: READ LANDMARKS FROM JSON FILE
                };
                this.loadOptions = () => {
                    // TODO: LOAD OPTIONS
                    this.mapService.getStyles()
                        .done((styles) => {
                        this.options.styles = styles;
                    });
                    this.options.zoom = 7;
                    this.options.center = new google.maps.LatLng(42.7339, 25.4858);
                };
                this.initialize = () => {
                    this.map = new google.maps.Map(this.mapDiv, this.options);
                };
                this.mapDiv = container;
                this.mapService = mapService;
            }
        }
        GoogleMap.LandmarkMap = LandmarkMap;
    })(GoogleMap = App.GoogleMap || (App.GoogleMap = {}));
})(App || (App = {}));
//# sourceMappingURL=landmarks-map.js.map