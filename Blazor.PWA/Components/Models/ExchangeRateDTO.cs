namespace Blazor.PWA.Components.Models
{
    using System;

    public partial class ExchangeRateDTO
    {
        public Rates Rates { get; set; }

        public string Base { get; set; }

        public DateTimeOffset Date { get; set; }
    }

    public partial class Rates
    {
        public decimal Eur { get; set; }

        public decimal Usd { get; set; }
        public decimal Try { get; set; }
    }
}