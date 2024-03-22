using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSendKeys.Utils.KeyboardHook
{
    [Flags]
    public enum ModifierKeys
    {
        Alt = 1,
        Ctrl = 2,
        Shift = 4,
        Win = 8,
    }

    public static class ModifierKeysUtilities
    {
        public static ModifierKeys? GetModifierKeyFromCode(int keyCode)
        {
            switch (keyCode)
            {
                case 0xA0:
                case 0xA1:
                case 0x10:
                    return ModifierKeys.Shift;

                case 0xA2:
                case 0xA3:
                case 0x11:
                    return ModifierKeys.Ctrl;

                case 0x12:
                case 0xA4:
                case 0xA5:
                    return ModifierKeys.Alt;

                case 0x5B:
                case 0x5C:
                    return ModifierKeys.Win;

                default:
                    return null;
            }
        }
    }
}
