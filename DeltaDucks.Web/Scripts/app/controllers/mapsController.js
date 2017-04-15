var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var LandmarkMap = App.GoogleMap.LandmarkMap;
        class MapsController {
            constructor(mapService) {
                this.toggleMapSize = (mapDiv, button) => {
                    var text = button.text() === "Увеличи" ? "Намали" : "Увеличи";
                    button.text(text);
                    mapDiv.toggleClass('map-fullsize');
                    google.maps.event.trigger(this.map, 'resize');
                    this.map.setCenter(this.map.getCenter());
                };
                this.initializeMap = (container) => {
                    let landmarkMap;
                    var promise = this.mapService.getOptions();
                    promise.done((data) => {
                        landmarkMap = new LandmarkMap(container, data["options"]);
                        for (var location of data["locations"])
                            landmarkMap.addMarker(location);
                        this.map = landmarkMap.map;
                    });
                    return promise;
                };
                this.mapService = mapService;
            }
        }
        Controllers.MapsController = MapsController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=mapsController.js.map