var App;
(function (App) {
    var Services;
    (function (Services) {
        class MapService {
            constructor() {
                this.getOptions = () => {
                    return $.get(`/api/maps/`);
                };
            }
        }
        Services.MapService = MapService;
    })(Services = App.Services || (App.Services = {}));
})(App || (App = {}));
//# sourceMappingURL=mapService.js.map