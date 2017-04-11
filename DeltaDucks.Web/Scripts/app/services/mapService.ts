namespace App.Services {
    export class MapService {
        getStyles = (): JQueryPromise<any> => {
            return $.get("/api/landmarks");
        }
    }
}