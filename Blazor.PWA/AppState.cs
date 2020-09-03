namespace Blazor.PWA
{
    using System;

    public class AppState
    {
        public string CurrentState { get; private set; } = "Active";

        public event Action OnChange;

        public void SetState(string state)
        {
            CurrentState = state;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }

}