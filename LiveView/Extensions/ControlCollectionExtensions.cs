using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LiveView.Extensions
{
    public static class ControlCollectionExtensions
    {
        public static bool Any(this Control.ControlCollection controls, Func<Control, bool> predicate)
        {
            if (controls == null || predicate == null)
            {
                return false;
            }

            foreach (Control control in controls)
            {
                if (predicate(control))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool Any(this Control.ControlCollection controls)
        {
            return controls?.Count > 0;
        }

        public static IEnumerable<Control> Where(this Control.ControlCollection controls, Func<Control, bool> predicate)
        {
            foreach (Control control in controls)
            {
                if (predicate(control))
                {
                    yield return control;
                }
            }
        }
    }
}
