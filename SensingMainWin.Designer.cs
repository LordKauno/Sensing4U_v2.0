using System;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;
using System.Data;
namespace Sensing4U_v2._0
{
    partial class Sensing4USensorData
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtBoxUpper = new TextBox();
            txtBoxLower = new TextBox();
            txtBoxAvg = new TextBox();
            labelUp = new Label();
            labelMin = new Label();
            labelAvg = new Label();
            labelUpdate = new Label();
            txtUpdate = new TextBox();
            btnAvg = new Button();
            btnUpdate = new Button();
            btnMaxMin = new Button();
            btnSort = new Button();
            dataGridViewSensor = new DataGridView();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            loadToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem = new ToolStripMenuItem();
            tutorialToolStripMenuItem = new ToolStripMenuItem();
            lblTitle = new Label();
            btnRemove = new Button();
            btnAdd = new Button();
            btnPreviousFile = new Button();
            btnNextFile = new Button();
            lblSearch = new Label();
            txtBoxSearch = new TextBox();
            btnSearch = new Button();
            comboBoxListOfFile = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSensor).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // txtBoxUpper
            // 
            txtBoxUpper.Anchor = AnchorStyles.None;
            txtBoxUpper.Location = new Point(1143, 180);
            txtBoxUpper.Name = "txtBoxUpper";
            txtBoxUpper.Size = new Size(179, 31);
            txtBoxUpper.TabIndex = 1;
            // 
            // txtBoxLower
            // 
            txtBoxLower.Anchor = AnchorStyles.None;
            txtBoxLower.Location = new Point(926, 180);
            txtBoxLower.Name = "txtBoxLower";
            txtBoxLower.Size = new Size(179, 31);
            txtBoxLower.TabIndex = 2;
            // 
            // txtBoxAvg
            // 
            txtBoxAvg.Anchor = AnchorStyles.None;
            txtBoxAvg.Location = new Point(926, 287);
            txtBoxAvg.Name = "txtBoxAvg";
            txtBoxAvg.Size = new Size(179, 31);
            txtBoxAvg.TabIndex = 3;
            // 
            // labelUp
            // 
            labelUp.Anchor = AnchorStyles.None;
            labelUp.AutoSize = true;
            labelUp.Location = new Point(1143, 138);
            labelUp.Name = "labelUp";
            labelUp.Size = new Size(92, 25);
            labelUp.TabIndex = 4;
            labelUp.Text = "Limit max.";
            // 
            // labelMin
            // 
            labelMin.Anchor = AnchorStyles.None;
            labelMin.AutoSize = true;
            labelMin.Location = new Point(929, 138);
            labelMin.Name = "labelMin";
            labelMin.Size = new Size(89, 25);
            labelMin.TabIndex = 5;
            labelMin.Text = "Limit min.";
            // 
            // labelAvg
            // 
            labelAvg.Anchor = AnchorStyles.None;
            labelAvg.AutoSize = true;
            labelAvg.Location = new Point(929, 245);
            labelAvg.Name = "labelAvg";
            labelAvg.Size = new Size(179, 25);
            labelAvg.TabIndex = 6;
            labelAvg.Text = "Calculate the average";
            // 
            // labelUpdate
            // 
            labelUpdate.Anchor = AnchorStyles.None;
            labelUpdate.AutoSize = true;
            labelUpdate.Location = new Point(929, 348);
            labelUpdate.Name = "labelUpdate";
            labelUpdate.Size = new Size(144, 25);
            labelUpdate.TabIndex = 7;
            labelUpdate.Text = "Update the data:";
            // 
            // txtUpdate
            // 
            txtUpdate.Anchor = AnchorStyles.None;
            txtUpdate.Location = new Point(926, 390);
            txtUpdate.Name = "txtUpdate";
            txtUpdate.Size = new Size(179, 31);
            txtUpdate.TabIndex = 8;
            // 
            // btnAvg
            // 
            btnAvg.Anchor = AnchorStyles.None;
            btnAvg.Location = new Point(1143, 285);
            btnAvg.Name = "btnAvg";
            btnAvg.Size = new Size(112, 34);
            btnAvg.TabIndex = 9;
            btnAvg.Text = "Calculate";
            btnAvg.UseVisualStyleBackColor = true;
            btnAvg.Click += btnAvg_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Anchor = AnchorStyles.None;
            btnUpdate.Location = new Point(1143, 388);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(112, 34);
            btnUpdate.TabIndex = 10;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnMaxMin
            // 
            btnMaxMin.Anchor = AnchorStyles.None;
            btnMaxMin.BackColor = SystemColors.ControlLight;
            btnMaxMin.Location = new Point(1143, 217);
            btnMaxMin.Name = "btnMaxMin";
            btnMaxMin.Size = new Size(112, 34);
            btnMaxMin.TabIndex = 11;
            btnMaxMin.Text = "Filter Data";
            btnMaxMin.UseVisualStyleBackColor = false;
            btnMaxMin.Click += btnMaxMin_Click;
            // 
            // btnSort
            // 
            btnSort.Anchor = AnchorStyles.None;
            btnSort.Location = new Point(929, 638);
            btnSort.Name = "btnSort";
            btnSort.Size = new Size(112, 34);
            btnSort.TabIndex = 12;
            btnSort.Text = "Sort Data";
            btnSort.UseVisualStyleBackColor = true;
            btnSort.Click += btnSort_Click;
            // 
            // dataGridViewSensor
            // 
            dataGridViewSensor.AllowUserToOrderColumns = true;
            dataGridViewSensor.Anchor = AnchorStyles.None;
            dataGridViewSensor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSensor.Location = new Point(184, 138);
            dataGridViewSensor.Name = "dataGridViewSensor";
            dataGridViewSensor.RowHeadersWidth = 62;
            dataGridViewSensor.Size = new Size(736, 567);
            dataGridViewSensor.TabIndex = 13;
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1454, 33);
            menuStrip1.TabIndex = 14;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, loadToolStripMenuItem, saveToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(54, 29);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(153, 34);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // loadToolStripMenuItem
            // 
            loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            loadToolStripMenuItem.Size = new Size(153, 34);
            loadToolStripMenuItem.Text = "Load";
            loadToolStripMenuItem.Click += loadToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(153, 34);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { aboutToolStripMenuItem, tutorialToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(65, 29);
            helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            aboutToolStripMenuItem.Size = new Size(270, 34);
            aboutToolStripMenuItem.Text = "About";
            aboutToolStripMenuItem.Click += aboutToolStripMenuItem_Click;
            // 
            // tutorialToolStripMenuItem
            // 
            tutorialToolStripMenuItem.Name = "tutorialToolStripMenuItem";
            tutorialToolStripMenuItem.Size = new Size(270, 34);
            tutorialToolStripMenuItem.Text = "Tutorial";
            tutorialToolStripMenuItem.Click += tutorialToolStripMenuItem_Click;
            // 
            // lblTitle
            // 
            lblTitle.Anchor = AnchorStyles.None;
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(12, 33);
            lblTitle.Name = "lblTitle";
            lblTitle.RightToLeft = RightToLeft.Yes;
            lblTitle.Size = new Size(252, 65);
            lblTitle.TabIndex = 15;
            lblTitle.Text = "Sensing4U";
            // 
            // btnRemove
            // 
            btnRemove.Anchor = AnchorStyles.None;
            btnRemove.Location = new Point(1047, 598);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(112, 34);
            btnRemove.TabIndex = 16;
            btnRemove.Text = "Remove";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.None;
            btnAdd.Location = new Point(929, 598);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add Data";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnPreviousFile
            // 
            btnPreviousFile.Anchor = AnchorStyles.None;
            btnPreviousFile.Location = new Point(187, 711);
            btnPreviousFile.Name = "btnPreviousFile";
            btnPreviousFile.Size = new Size(112, 34);
            btnPreviousFile.TabIndex = 18;
            btnPreviousFile.Text = "Previous";
            btnPreviousFile.UseVisualStyleBackColor = true;
            btnPreviousFile.Click += btnPreviousFile_Click;
            // 
            // btnNextFile
            // 
            btnNextFile.Anchor = AnchorStyles.None;
            btnNextFile.Location = new Point(811, 711);
            btnNextFile.Name = "btnNextFile";
            btnNextFile.Size = new Size(112, 34);
            btnNextFile.TabIndex = 19;
            btnNextFile.Text = "Next File";
            btnNextFile.UseVisualStyleBackColor = true;
            btnNextFile.Click += btnNextFile_Click;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.None;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(929, 443);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(104, 25);
            lblSearch.TabIndex = 20;
            lblSearch.Text = "Search data";
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.Anchor = AnchorStyles.None;
            txtBoxSearch.Location = new Point(926, 484);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.Size = new Size(179, 31);
            txtBoxSearch.TabIndex = 21;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.None;
            btnSearch.Location = new Point(1143, 481);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(112, 34);
            btnSearch.TabIndex = 22;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // comboBoxListOfFile
            // 
            comboBoxListOfFile.Anchor = AnchorStyles.None;
            comboBoxListOfFile.FormattingEnabled = true;
            comboBoxListOfFile.Location = new Point(184, 99);
            comboBoxListOfFile.Name = "comboBoxListOfFile";
            comboBoxListOfFile.Size = new Size(201, 33);
            comboBoxListOfFile.TabIndex = 23;
            comboBoxListOfFile.DropDown += ComboBoxListOfFile_DropDown;
            comboBoxListOfFile.SelectedIndexChanged += ComboBoxListOfFile_SelectedIndexChanged;
            // 
            // Sensing4USensorData
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = SystemColors.ControlLight;
            ClientSize = new Size(1454, 862);
            Controls.Add(comboBoxListOfFile);
            Controls.Add(btnSearch);
            Controls.Add(txtBoxSearch);
            Controls.Add(lblSearch);
            Controls.Add(btnNextFile);
            Controls.Add(btnPreviousFile);
            Controls.Add(btnAdd);
            Controls.Add(btnRemove);
            Controls.Add(lblTitle);
            Controls.Add(dataGridViewSensor);
            Controls.Add(btnSort);
            Controls.Add(btnMaxMin);
            Controls.Add(btnUpdate);
            Controls.Add(btnAvg);
            Controls.Add(txtUpdate);
            Controls.Add(labelUpdate);
            Controls.Add(labelAvg);
            Controls.Add(labelMin);
            Controls.Add(labelUp);
            Controls.Add(txtBoxAvg);
            Controls.Add(txtBoxLower);
            Controls.Add(txtBoxUpper);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            MinimizeBox = false;
            Name = "Sensing4USensorData";
            Text = "Sensing4U Sensor Manager";
            ((System.ComponentModel.ISupportInitialize)dataGridViewSensor).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtBoxUpper;
        private TextBox txtBoxLower;
        private TextBox txtBoxAvg;
        private Label labelUp;
        private Label labelMin;
        private Label labelAvg;
        private Label labelUpdate;
        private TextBox txtUpdate;
        private Button btnAvg;
        private Button btnUpdate;
        private Button btnMaxMin;
        private Button btnSort;
        private DataGridView dataGridViewSensor;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem loadToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private Label lblTitle;
        private Button btnRemove;
        private Button btnAdd;
        private ToolStripMenuItem aboutToolStripMenuItem;
        private ToolStripMenuItem tutorialToolStripMenuItem;
        private Button btnPreviousFile;
        private Button btnNextFile;
        private Label lblSearch;
        private TextBox txtBoxSearch;
        private Button btnSearch;
        private ComboBox comboBoxListOfFile;
    }
}