namespace App.Controllers {
    import MapService = Services.MapService;
    import LandmarkMap = GoogleMap.LandmarkMap;

    export class MapsController {
        mapService: MapService;

        constructor(mapService: MapService) {
            this.mapService = mapService;
        }

        initializeMap = (container: Element): void => {
            let landmarkMap: LandmarkMap;

            this.mapService.getOptions()
                .done((data) => {
                    landmarkMap = new LandmarkMap(container, data["options"]);
                    
                    for (var location of data["locations"])
                        landmarkMap.addMarker(location);
                });
        }
    }
}