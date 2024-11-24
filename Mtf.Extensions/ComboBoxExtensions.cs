//using System;
//using System.Windows.Forms;

//namespace Mtf.Extensions
//{
//    public static class ComboBoxExtensions
//    {
//        public static void SelectFirst(this ComboBox comboBox)
//        {
//            Utils.SelectFirst(comboBox);
//        }

//        /// <summary>
//        /// Get all items from an enumeration
//        /// </summary>
//        /// <param name="comboBox">The combobox</param>
//        /// <param name="enumType">typeof(enum), enum::typeid</param>
//        public static void GetItems(this ComboBox comboBox, Type enumType)
//        {
//            Utils.GetItems(comboBox, enumType);
//        }

//        public static void SelectFirstOrSetDisabled(this ComboBox comboBox)
//        {
//            Utils.SelectFirstOrSetDisabled(comboBox);
//        }

//        public static void GetCOMPorts(this ComboBox comboBox)
//        {
//            var portNames = SerialPort.GetPortNames();
//            for (var i = 0; i < portNames.Length; i++)
//            {
//                comboBox.Items.Add(portNames[i]);
//            }

//            Utils.SelectFirstOrSetDisabled(comboBox);
//        }

//        public static int IndexOf(this ComboBox comboBox, object obj)
//        {
//            return comboBox?.Items.IndexOf(obj) ?? throw new ArgumentNullException(nameof(comboBox));
//        }
//    }
//}
