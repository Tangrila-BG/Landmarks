namespace App.GoogleMap {
    import MapTypeId = google.maps.MapTypeId;
    import MapService = Services.MapService;

    export class LandmarkMap implements ILandmarkMap {
        options: google.maps.MapOptions;
        landmarks: { [index: string]: { lat: number;long: number }; };
        mapDiv: Element;
        map: google.maps.Map;
        mapType: MapTypeId;
        latitude: number;
        longitude: number;
        mapService: MapService;

        constructor(container: Element, mapService: MapService) {
            this.mapDiv = container;
            this.mapService = mapService;
        }

        private loadLandmarks = (): void => {
            // TODO: READ LANDMARKS FROM JSON FILE
        }

        private loadOptions = (): void => {
            // TODO: LOAD OPTIONS
            this.mapService.getStyles()
                .done((styles) => {
                    this.options.styles = styles;
                });
            this.options.zoom = 7;
            this.options.center = new google.maps.LatLng(42.7339, 25.4858);
        }

        initialize = (): void => {
            this.map = new google.maps.Map(this.mapDiv, this.options);
        }
    }
}