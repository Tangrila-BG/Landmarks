var App;
(function (App) {
    var Controllers;
    (function (Controllers) {
        var LandmarkMap = App.GoogleMap.LandmarkMap;
        class MapsController {
            constructor(mapService) {
                this.initializeMap = (container) => {
                    let landmarkMap;
                    this.mapService.getOptions()
                        .done((data) => {
                        landmarkMap = new LandmarkMap(container, data["options"]);
                        for (var location of data["locations"])
                            landmarkMap.addMarker(location);
                    });
                };
                this.mapService = mapService;
            }
        }
        Controllers.MapsController = MapsController;
    })(Controllers = App.Controllers || (App.Controllers = {}));
})(App || (App = {}));
//# sourceMappingURL=mapsController.js.map