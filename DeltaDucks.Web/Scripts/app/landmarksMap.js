var App;
(function (App) {
    var GoogleMap;
    (function (GoogleMap) {
        class LandmarkMap {
            constructor(container, options) {
                this.map = new google.maps.Map(container, options);
            }
        }
        GoogleMap.LandmarkMap = LandmarkMap;
    })(GoogleMap = App.GoogleMap || (App.GoogleMap = {}));
})(App || (App = {}));
//# sourceMappingURL=landmarksMap.js.map