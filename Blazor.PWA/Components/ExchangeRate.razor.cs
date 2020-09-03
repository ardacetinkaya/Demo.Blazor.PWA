namespace Blazor.PWA.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http.Json;
    using Blazor.PWA.Components.Models;

    public partial class ExchangeRate : ComponentBase, System.IDisposable
    {
        [Parameter]
        public RenderFragment Online { get; set; }

        [Parameter]
        public RenderFragment Offline { get; set; }

        public decimal? EUR { get; set; }
        public decimal? USD { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                ExchangeRateDTO eur = await Http.GetFromJsonAsync<ExchangeRateDTO>("latest?base=EUR&symbols=TRY");
                ExchangeRateDTO usd = await Http.GetFromJsonAsync<ExchangeRateDTO>("latest?base=USD&symbols=TRY");

                EUR = eur?.Rates?.Try;
                USD = usd?.Rates?.Try;

            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"ERROR - {ex.Message}");
            }

        }

        public void Dispose()
        {

        }

    }
}