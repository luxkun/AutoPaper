using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace AutoPaper
{
    internal class Utils
    {
        internal static int MinutesToSeconds(int v)
        {
            return v * 60 * 1000;
        }

        internal static int SecondsToMinutes(int v)
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