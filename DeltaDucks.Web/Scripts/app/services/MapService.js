var App;
(function (App) {
    var Services;
    (function (Services) {
        class MapService {
            constructor() {
                this.getStyles = () => {
                    return $.get("/api/landmarks");
                };
            }
        }
        Services.MapService = MapService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=mapService.js.map