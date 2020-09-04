window.Network = {
    Initialize: function (interop) {

        function handler() {
            interop.invokeMethodAsync("Network.StatusChanged", navigator.onLine);
        }

        window.addEventListener('online', handler);
        window.addEventListener('offline', handler);

        if (!navigator.onLine) {
            handler();
        }
    }
};