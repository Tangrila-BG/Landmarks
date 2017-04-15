var App;
(function (App) {
    var GoogleMap;
    (function (GoogleMap) {
        class LandmarkMap {
            constructor(container, options) {
                this.addMarker = (location) => {
                    var marker = new google.maps.Marker(location);
                    marker.setMap(this.map);
                    this.addCustomIcon(marker);
                    google.maps.event
                        .addListener(marker, 'click', () => this.listenToMarker(location["title"], marker));
                };
                this.listenToMarker = (title, marker) => {
                    this.infoWindow.setContent(title);
                    this.infoWindow.open(this.map, marker);
                };
                this.addCustomIcon = (marker) => {
                    marker.setIcon({
                        url: "https://cdn0.iconfinder.com/data/icons/flat-world-flags/128/Bulgaria_Flag_Map_County_Pin_National-512.png",
                        scaledSize: new google.maps.Size(50, 50),
                    });
                };
                this.map = new google.maps.Map(container, options);
                this.infoWindow = new google.maps.InfoWindow();
            }
        }
        GoogleMap.LandmarkMap = LandmarkMap;
    })(GoogleMap = App.GoogleMap || (App.GoogleMap = {}));
})(App || (App = {}));
//# sourceMappingURL=landmarksMap.js.map