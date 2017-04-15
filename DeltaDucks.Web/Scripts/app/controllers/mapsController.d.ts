declare namespace App.Controllers {
    import MapService = Services.MapService;
    class MapsController {
        mapService: MapService;
        map: google.maps.Map;
        constructor(mapService: MapService);
        toggleMapSize: (mapDiv: any, button: any) => void;
        initializeMap: (container: Element) => JQueryPromise<any>;
    }
}
