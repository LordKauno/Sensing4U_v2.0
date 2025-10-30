namespace Sensing4U_v2._0
{
    partial class AddDataForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblSensor = new Label();
            lblValue = new Label();
            txtLabel = new TextBox();
            txtValue = new TextBox();
            btnOK = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // lblSensor
            // 
            lblSensor.AutoSize = true;
            lblSensor.Location = new Point(173, 77);
            lblSensor.Name = "lblSensor";
            lblSensor.Size = new Size(120, 25);
            lblSensor.TabIndex = 0;
            lblSensor.Text = "Sensor name ";
            // 
            // lblValue
            // 
            lblValue.AutoSize = true;
            lblValue.Location = new Point(173, 169);
            lblValue.Name = "lblValue";
            lblValue.Size = new Size(132, 25);
            lblValue.TabIndex = 1;
            lblValue.Text = "Insert the value";
            // 
            // txtLabel
            // 
            txtLabel.Location = new Point(173, 105);
            txtLabel.Name = "txtLabel";
            txtLabel.Size = new Size(230, 31);
            txtLabel.TabIndex = 2;
            // 
            // txtValue
            // 
            txtValue.Location = new Point(173, 197);
            txtValue.Name = "txtValue";
            txtValue.Size = new Size(230, 31);
            txtValue.TabIndex = 3;
            // 
            // btnOK
            // 
            btnOK.Location = new Point(173, 253);
            btnOK.Name = "btnOK";
            btnOK.Size = new Size(112, 34);
            btnOK.TabIndex = 4;
            btnOK.Text = "Add";
            btnOK.UseVisualStyleBackColor = true;
            btnOK.Click += btnOK_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(291, 253);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 5;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;


            // 
            // AddDataForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 450);
            Controls.Add(btnCancel);
            Controls.Add(btnOK);
            Controls.Add(txtValue);
            Controls.Add(txtLabel);
            Controls.Add(lblValue);
            Controls.Add(lblSensor);
            Name = "AddDataForm";
            Text = "AddDataForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSensor;
        private Label lblValue;
        private TextBox txtLabel;
        private TextBox txtValue;
        private Button btnOK;
        private Button btnCancel;
    }
}