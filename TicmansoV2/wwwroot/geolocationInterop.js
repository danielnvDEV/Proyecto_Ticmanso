export function getCurrentPosition(dotNetObjectRef, options) {
    navigator.geolocation.getCurrentPosition(
        (position) => {
            dotNetObjectRef.invokeMethodAsync('OnSuccess', position);
        },
        (error) => {
            dotNetObjectRef.invokeMethodAsync('OnError', error.message);
        },
        options
    );
}