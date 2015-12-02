using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoPaper
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            
            delayTextBox.Text = Utils.SecondsToMinutes((long)Conf.GetConf("delay")).ToString();
            
            policyAComboBox.Items.AddRange(Conf.possiblePoliciesA.ToArray());
            Utils.SelectComboBoxItemByText(policyAComboBox, (string)Conf.GetConf("policyA"));

            policyBComboBox.Items.AddRange(Conf.possiblePoliciesB.ToArray());
            Utils.SelectComboBoxItemByText(policyBComboBox, (string)Conf.GetConf("policyB"));

            filterTextBox.Text = (string)Conf.GetConf("filter");

            styleComboBox.Items.AddRange(Conf.possibleStyles.ToArray());
            Utils.SelectComboBoxItemByText(styleComboBox, (string)Conf.GetConf("style"));

            subredditTextBox.Text = (string)Conf.GetConf("subreddit");
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            bool checks = true;
            int delay;
            checks = int.TryParse(delayTextBox.Text, out delay);
            checks = checks && Conf.SetConf("delay", Utils.MinutesToSeconds(delay));
            checks = checks && Conf.SetConf("policyA", policyAComboBox.Text);
            checks = checks && Conf.SetConf("policyB", policyBComboBox.Text);
            checks = checks && Conf.SetConf("filter", filterTextBox.Text);
            checks = checks && Conf.SetConf("style", styleComboBox.Text);
            checks = checks && Conf.SetConf("subreddit", subredditTextBox.Text);
            if (checks)
            {
                Conf.Save();
                Close();
            } else
                MessageBox.Show("Wrong settings.", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
