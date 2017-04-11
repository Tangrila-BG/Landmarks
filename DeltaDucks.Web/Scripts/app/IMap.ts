namespace App.GoogleMap
{
    import Map = google.maps.Map;

    export interface IMap {
        mapDiv: Element,
        map: Map,
        mapType: google.maps.MapTypeId;
        latitude: number,
        longitude: number;
    }

    export interface ILandmarkMap extends IMap {
        // Map structure
        landmarks: { [key: string]: { lat: number, long: number }; },
        options: google.maps.MapOptions;
    }
}