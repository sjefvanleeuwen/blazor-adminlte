import { JsonRequestHandlerMethodName } from './Constants.js';
export class BlazorState {
    jsonRequestHandler;
    reduxDevTools;
    async DispatchRequest(requestTypeFullName, request) {
        const requestAsJson = JSON.stringify(request);
        console.log(`Dispatching request of Type ${requestTypeFullName}: ${requestAsJson}`);
        await this.jsonRequestHandler.invokeMethodAsync(JsonRequestHandlerMethodName, requestTypeFullName, requestAsJson);
    }
}
export const blazorState = new BlazorState();
//# sourceMappingURL=BlazorState.js.map