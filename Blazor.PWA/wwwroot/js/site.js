window.Network = {
    Initialize: function (interop) {
        window.addEventListener('online', handler);
        window.addEventListener('offline', handler);

        function handler() {
            interop.invokeMethodAsync("Network.StatusChanged", navigator.onLine);
        }

        if (!navigator.onLine) {
            handler();
        }
    }
};