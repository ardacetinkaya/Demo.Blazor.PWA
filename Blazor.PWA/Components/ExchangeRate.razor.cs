namespace Blazor.PWA.Components
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
    using System.Net.Http.Json;
    using Blazor.PWA.Components.Models;
    using Microsoft.AspNetCore.Components.Web;
    using System;

    public partial class ExchangeRate : System.IDisposable
    {
        public decimal? EUR { get; set; }
        public decimal? USD { get; set; }

        public DateTime LastUpdate { get; set; }
        protected override async Task OnInitializedAsync()
        {
            await GetRates();
            LastUpdate = DateTime.Now;

        }

        private async Task GetRates()
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
        private async Task RefreshRates(MouseEventArgs e)
        {
            await GetRates();
            LastUpdate = DateTime.Now;
            StateHasChanged();
        }

    }
}