using System;
using System.Collections.Generic;
using System.Globalization;

namespace Database.Models
{
    public class WindowProperties
    {
        public WindowProperties() { }

        public WindowProperties(IList<string> args)
        {
            if (args == null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            if (args.Count != 11)
            {
                throw new ArgumentException($"Args array length sould be 11, but it is {args.Count}. Check the encryption...");
            }

            LocationX = Convert.ToInt32(args[4], CultureInfo.InvariantCulture);
            LocationY = Convert.ToInt32(args[5], CultureInfo.InvariantCulture);
            Width = Convert.ToInt32(args[6], CultureInfo.InvariantCulture);
            Height = Convert.ToInt32(args[7], CultureInfo.InvariantCulture);
            LiveView = Convert.ToBoolean(args[8], CultureInfo.InvariantCulture);
            Fullscreen = Convert.ToBoolean(args[10], CultureInfo.InvariantCulture);
        }

        public int LocationX { get; set; }

        public int LocationY { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool LiveView { get; set; }

        public bool Fullscreen { get; set; }
    }
}
