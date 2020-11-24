using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(PlaceMyBetOficial.Startup))]

namespace PlaceMyBetOficial
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            CultureInfo culInfo = new System.Globalization.CultureInfo("es-ES");
            culInfo.NumberFormat.NumberDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            culInfo.NumberFormat.PercentDecimalSeparator = ".";
            culInfo.NumberFormat.CurrencyDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = culInfo;

            ConfigureAuth(app);
        }
    }
}
