using Microsoft.Owin;
using Owin;
using System.Globalization;
using System.Threading;
using System;

[assembly: OwinStartupAttribute(typeof(PackageDelivery.GUI.Startup))]
namespace PackageDelivery.GUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        public static void Main()
        {
            CultureInfo culture = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            culture.DateTimeFormat.ShortDatePattern = "dd-MMM-yyyy";
            culture.DateTimeFormat.LongTimePattern = "";
            Thread.CurrentThread.CurrentCulture = culture;
            Console.WriteLine(DateTime.Now);
        }
    }
}
