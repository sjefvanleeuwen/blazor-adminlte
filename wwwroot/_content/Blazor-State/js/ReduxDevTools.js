import { blazorState } from './BlazorState.js';
import { ReduxExtensionName, DevToolsName } from './Constants.js';
export class ReduxDevTools {
    IsEnabled;
    DevTools;
    Extension;
    Config;
    BlazorState;
    constructor() {
        this.BlazorState = blazorState;
        this.Config = {
            name: 'Blazor State',
            features: {
                pause: false,
                lock: false,
                persist: false,
                export: false,
                import: false,
                jump: false,
                skip: false,
                reorder: false,
                dispatch: false,
                test: false
            }
        };
        this.Extension = this.GetExtension();
        this.DevTools = this.GetDevTools();
        this.IsEnabled = this.DevTools ? true : false;
        this.Init();
    }
    Init() {
        if (this.IsEnabled) {
            this.DevTools.subscribe(this.MessageHandler);
            window[DevToolsName] = this.DevTools;
        }
    }
    GetExtension() {
        const extension = window[ReduxExtensionName];
        if (!extension) {
            console.log('Redux DevTools are not installed.');
        }
        return extension;
    }
    GetDevTools() {
        const devTools = this.Extension && this.Extension.connect(this.Config);
        if (!devTools) {
            console.log('Unable to connect to Redux DevTools.');
        }
        return devTools;
    }
    MapRequestType(message) {
        var dispatchRequests = {
            'COMMIT': undefined,
            'IMPORT_STATE': undefined,
            'JUMP_TO_ACTION': 'BlazorState.Pipeline.ReduxDevTools.JumpToStateRequest',
            'JUMP_TO_STATE': 'BlazorState.Pipeline.ReduxDevTools.JumpToStateRequest',
            'LOCK_CHANGES': undefined,
            'PAUSE_RECORDING': undefined,
            'PERFORM_ACTION': undefined,
            'RESET': undefined,
            'REORDER_ACTION': undefined,
            'ROLLBACK': undefined,
            'SET_ACTIONS_ACTIVE': undefined,
            'SWEEP': undefined,
            'TOGGLE_ACTION': undefined,
        };
        var blazorRequestType;
        switch (message.type) {
            case 'START':
                blazorRequestType = 'BlazorState.Pipeline.ReduxDevTools.StartRequest';
                break;
            case 'STOP':
                break;
            case 'DISPATCH':
                blazorRequestType = dispatchRequests[message.payload.type];
                break;
        }
        blazorRequestType &&
            console.log(`Redux Dev tools type: ${message.type} maps to ${blazorRequestType}`);
        return blazorRequestType;
    }
    MessageHandler = (message) => {
        console.log('ReduxDevTools.MessageHandler');
        console.log(message);
        var jsonRequest;
        const requestType = this.MapRequestType(message);
        if (requestType) {
            jsonRequest = {
                RequestType: requestType,
                Payload: message
            };
            this.BlazorState.DispatchRequest(requestType, message);
        }
        else
            console.log(`messages of this type are currently not supported`);
    };
    ReduxDevToolsDispatch(action, state) {
        if (action === 'init') {
            return window[DevToolsName].init(state);
        }
        else {
            return window[DevToolsName].send(action, state);
        }
    }
}
//# sourceMappingURL=ReduxDevTools.js.map