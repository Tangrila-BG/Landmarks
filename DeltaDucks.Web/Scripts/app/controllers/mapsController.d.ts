declare namespace App.Controllers {
    import MapService = Services.MapService;
    class MapsController {
        mapService: MapService;
        constructor(mapService: MapService);
        initializeMap: (container: Element) => void;
    }
}
