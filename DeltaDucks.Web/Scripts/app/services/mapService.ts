namespace App.Services {
    export class MapService {
        getOptions = (): JQueryPromise<any> => {
            return $.get(`/api/maps/`);
        }
    }
}