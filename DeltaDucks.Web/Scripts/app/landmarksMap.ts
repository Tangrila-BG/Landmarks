namespace App.GoogleMap {
    export class LandmarkMap {
        options: google.maps.MapOptions;
        mapDiv: Element;
        map: google.maps.Map;
        infoWindow: google.maps.InfoWindow;

        constructor(container: Element, options) {
            this.map = new google.maps.Map(container, options);
            this.infoWindow = new google.maps.InfoWindow();
            this.bindToLocation();
        }

        addMarker = (location): void => {
            var marker = new google.maps.Marker(location);
            marker.setMap(this.map);

            this.addCustomIcon(marker);

            google.maps.event
                .addListener(marker,
                    'click',
                    () =>
                        this.listenToMarker(location["title"], marker));
        }

        private listenToMarker = (title: string, marker: google.maps.Marker): void => {
            this.infoWindow.setContent(title);
            this.infoWindow.open(this.map, marker);
        }
        
        private addCustomIcon = (marker: google.maps.Marker) => {
            marker.setIcon({
                url:
                    "https://cdn0.iconfinder.com/data/icons/flat-world-flags/128/Bulgaria_Flag_Map_County_Pin_National-512.png",
                scaledSize: new google.maps.Size(50, 50),
                //labelOrigin: new google.maps.Point(50, 50)
            });
        }

        private bindToLocation = (): void => {
            // bounds of Bulgaria
            // south-west and north-east corners
            var allowedBounds = new google.maps.LatLngBounds(
                new google.maps.LatLng(41.236022, 22.360067),
                new google.maps.LatLng(44.214555, 28.607050)
            );
            
            var lastValidCenter = this.map.getCenter();

            google.maps.event.addListener(this.map, 'center_changed', () => {
                if (allowedBounds.contains(this.map.getCenter())) {
                    // still within valid bounds, so save the last valid position
                    lastValidCenter = this.map.getCenter();
                    return;
                }

                // not valid anymore => return to last valid position
                this.map.panTo(lastValidCenter);
            });
        }
    }
}