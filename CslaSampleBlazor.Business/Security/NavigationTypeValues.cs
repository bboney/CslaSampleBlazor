using System.ComponentModel;

namespace CslaSampleBlazor.Business.Security
{
    /// <summary>
    /// Navigation Types identify different Client Navigation Types.
    /// </summary>
    public enum NavigationTypeValues : int
    {
        [Description("Web Browser Full Client Navigation Type")]
        WebBrowserFullClientNavigationType = 1,
        [Description("Web Browser Mobile Client Navigation Type")]
        WebBrowserMobileClientNavigationType = 2,
        [Description("Wpf Client Navigation Type")]
        WpfClientNavigationType = 3,
        [Description("Wpf Shop Floor Client Navigation Type")]
        WpfShopFloorClientNavigationType = 4,
        [Description("Web Browser Full Client Report Navigation Type")]
        WebBrowserFullClientReportNavigationType = 5,
        [Description("Xamarin Client Navigation Type")]
        XamarinClientNavigationType = 6,
        [Description("Blazor Navigation Type")]
        BlazorNavigationType = 7
    }
}
