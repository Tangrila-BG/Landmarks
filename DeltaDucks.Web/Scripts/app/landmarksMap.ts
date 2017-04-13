namespace App.GoogleMap {
    export class LandmarkMap {
        options: google.maps.MapOptions;
        mapDiv: Element;
        map: google.maps.Map;

        constructor(container: Element, options?) {
            this.map = new google.maps.Map(container, options);
        }
    }
}