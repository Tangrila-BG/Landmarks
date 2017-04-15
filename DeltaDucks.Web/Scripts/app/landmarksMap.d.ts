declare namespace App.GoogleMap {
    class LandmarkMap {
        options: google.maps.MapOptions;
        mapDiv: Element;
        map: google.maps.Map;
        infoWindow: google.maps.InfoWindow;
        constructor(container: Element, options: any);
        addMarker: (location: any) => void;
        private listenToMarker;
        private addCustomIcon;
        private bindToLocation;
    }
}
