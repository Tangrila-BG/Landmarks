declare namespace App.GoogleMap {
    class LandmarkMap {
        options: google.maps.MapOptions;
        mapDiv: Element;
        map: google.maps.Map;
        constructor(container: Element, options?: any);
    }
}
