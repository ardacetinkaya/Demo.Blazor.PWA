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
        public double Eur { get; set; }

        public double Usd { get; set; }
        public double Try { get; set; }
    }
}