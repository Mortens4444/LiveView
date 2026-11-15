using Mtf.LanguageService;
using Mtf.MessageBoxes;

namespace LiveView.Services
{
    public static class LiveViewTranslator
    {
        public static void Translate()
        {
            BaseBox.Abort = Lng.Elem("Abort");
            BaseBox.Retry = Lng.Elem("Retry");
            BaseBox.OK = Lng.Elem("OK");
            BaseBox.Cancel = Lng.Elem("Cancel");
            BaseBox.No = Lng.Elem("No");
            BaseBox.Yes = Lng.Elem("Yes");
            BaseBox.CopyToClipboard = Lng.Elem("Copy to clipboard");
            BaseBox.DisableAutomaticMessageClosing = Lng.Elem("Disable automatic message closing");
            BaseBox.EnableAutomaticMessageClosing = Lng.Elem("Enable automatic message closing");
            BaseBox.Copy = Lng.Elem("Copy");
            BaseBox.PleaseWait = Lng.Elem("Please wait...");

            Globals.Uptime = Lng.Elem("Uptime");
            Globals.SystemUptime = Lng.Elem("System uptime");
            Globals.Day = Lng.Elem("day");
            Globals.Days = Lng.Elem("days");
        }
    }
}
