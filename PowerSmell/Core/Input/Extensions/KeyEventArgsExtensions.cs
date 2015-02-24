using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PowerSmell.Core.Input.Extensions
{
    public static class KeyEventArgsExtensions
    {
        public static string ToProperCaseString(this Key key)
        {
            string keyString = key.ToString();
            var capsLock = Keyboard.GetKeyStates(Key.CapsLock) == KeyStates.Toggled;
            var shift = Keyboard.Modifiers == ModifierKeys.Shift;
            if (!capsLock && !shift)
                keyString = keyString.ToLowerInvariant();
            return keyString;
        }
    }
}
