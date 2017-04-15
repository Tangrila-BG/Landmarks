namespace App.Controllers {
    import MapService = Services.MapService;
    import LandmarkMap = GoogleMap.LandmarkMap;

    export class MapsController {
        mapService: MapService;
        map: google.maps.Map;

        constructor(mapService: MapService) {
            this.mapService = mapService;
        }

        toggleMapSize = (mapDiv, button): void => {
            var text = button.text() === "Увеличи" ? "Намали" : "Увеличи";
            button.text(text);

            mapDiv.toggleClass('map-fullsize');

            google.maps.event.trigger(this.map, 'resize');
            this.map.setCenter(this.map.getCenter());
        };

        initializeMap = (container: Element): JQueryPromise<any> => {
            let landmarkMap: LandmarkMap;
            var promise = this.mapService.getOptions();

            promise.done((data) => {
                landmarkMap = new LandmarkMap(container, data["options"]);

                for (var location of data["locations"])
                    landmarkMap.addMarker(location);

                this.map = landmarkMap.map;
            });

            return promise;
        }
    }
}