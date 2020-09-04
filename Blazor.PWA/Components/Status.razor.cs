namespace Blazor.PWA.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using Microsoft.JSInterop;

    public partial class Status
    {

        [Inject]
        protected NetworkStateInterop Interop { get; set; }
        
        public bool IsOnline { get; protected set; } = true;

        [Parameter]
        public RenderFragment Online { get; set; }

        [Parameter]
        public RenderFragment Offline { get; set; }


        protected override async Task OnInitializedAsync()
        {
            await Interop.InitializeAsync(OnStatusChanged);
        }

        private void OnStatusChanged(bool isOnline)
        {
            if (IsOnline != isOnline)
            {
                IsOnline = isOnline;
                StateHasChanged();
            }
        }
    }
}