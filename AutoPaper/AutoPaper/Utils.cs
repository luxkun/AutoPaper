using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace AutoPaper
{
    internal class Utils
    {
        internal static long MinutesToSeconds(long v)
        {
            return v * 60 * 1000;
        }

        internal static long SecondsToMinutes(long v)
        {
            return v / (60 * 1000);
        }

        internal static bool SelectComboBoxItemByText(ComboBox comboBox, string text)
        {
            for (int i = 0; i < comboBox.Items.Count; i++)
            {
                if (comboBox.GetItemText(comboBox.Items[i]) == text)
                {
                    comboBox.SelectedIndex = i;
                    return true;
                }
            }
            return false;
        }
    }
}