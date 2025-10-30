using System;
using System.Windows.Forms;

namespace Sensing4U_v2._0
{
    public partial class AddDataForm : Form
    {
        public string SensorLabel { get; private set; }
        public double SensorValue { get; private set; }

        public AddDataForm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            // Validate the user input
            if (string.IsNullOrWhiteSpace(txtLabel.Text) ||
                !double.TryParse(txtValue.Text, out double value))
            {
                MessageBox.Show("Please enter a valid label and numeric value.",
                                "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SensorLabel = txtLabel.Text.Trim();
            SensorValue = value;
            DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
