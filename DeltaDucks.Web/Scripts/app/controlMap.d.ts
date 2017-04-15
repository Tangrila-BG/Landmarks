declare namespace App.GoogleMap {
    class ControlMap {
        controlDiv: any;
        map: any;
        constructor();
        resizeControl: (controlDiv: any, map: any) => void;
    }
}
