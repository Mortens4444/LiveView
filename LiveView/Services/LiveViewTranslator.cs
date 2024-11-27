using LanguageService;
using Mtf.MessageBoxes;

namespace LiveView.Services
{
    public static class LiveViewTranslator
    {
        public static void Translate()
        {
            BaseBox.OK = Lng.Elem("OK");
            BaseBox.Cancel = Lng.Elem("Cancel");
            BaseBox.No = Lng.Elem("No");
            BaseBox.Yes = Lng.Elem("Yes");
            BaseBox.CopyToClipboard = Lng.Elem("Copy to clipboard");
            BaseBox.DisableAutomaticMessageClosing = Lng.Elem("Disable automatic message closing");
            BaseBox.EnableAutomaticMessageClosing = Lng.Elem("Enable automatic message closing");
            BaseBox.Copy = Lng.Elem("Copy");
            BaseBox.PleaseWait = Lng.Elem("Please wait...");
        }
    }
}
