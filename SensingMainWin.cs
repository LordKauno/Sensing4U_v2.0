using Sensing4U_v2._0;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
/* 
 * Author: Caio Guilherme Ferreira da Silva
 * Date: October 22, 2025
 * Description: This code defines a Windows Forms application for managing sensor data.
 * Version: 2.0
 */
namespace Sensing4U_v2._0
{
    public partial class Sensing4USensorData : Form
    {
        private string[] fileList;
        private int currentFileIndex = -1;
        private string currentDirectory = "C:\\Sensing4U\\DataStorage\\";
        private bool sorted = false;

        public Sensing4USensorData()
        {
            InitializeComponent();
            InitializeGridView();
            InitializeShortcuts();
        }

        public void InitializeGridView()
        {
            dataGridViewSensor.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSensor.MultiSelect = true;
            dataGridViewSensor.AllowUserToAddRows = false;
            dataGridViewSensor.ReadOnly = true;
            dataGridViewSensor.Columns.Add("SensorLabel", "Sensor Label");
            dataGridViewSensor.Columns.Add("SensorValue", "Sensor Value");
        }

        private void InitializeShortcuts()
        {
            newToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.N;
            loadToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.O;
            saveToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.S;
        }
        /// <summary>
        /// Handles the click event for the "Add Data" button, adding a new row to the DataGridView.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Add Data" button.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
           
            AddSensor();// Add new sensor data
            sorted = false;
            ClearView();
        }
        /// <summary>
        /// Handles the click event for the "Remove" button, removing the selected row from the DataGridView.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Remove" button.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void btnRemove_Click(object sender, EventArgs e)
        {
            RemoveSensor();
            sorted = false;
            ClearView();
        }
        /// <summary>
        /// Handles the click event for the "Sort" button, sorting the sensor data in ascending order based on their values.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Sort Data" button.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void btnSort_Click(object sender, EventArgs e)
        {
            hasDataOnGrid();
            SortSensor();
            ClearView();
        }
        /// <summary>
        /// Handles the click event for the "Update" button, updating the selected row in the DataGridView with a new value.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Update" button.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateSensor();
            sorted = false;
            ClearView();
        }
        /// <summary>
        /// Handles the click event for the "Average" button, calculating and displaying the average of sensor values.
        /// </summary>
        /// <param name="e"> The event data associated with the click event.</param>
        /// <param name="sender"> The source of the event, typically the "Average" button.</param>
        private void btnAvg_Click(object sender, EventArgs e)
        {
            // Calculate average
            hasDataOnGrid();
            double average = 0;
            AvgSensor();// Get average
            ClearView();
            txtBoxAvg.Text = $"{average:F2}";

        }

        private void btnMaxMin_Click(object sender, EventArgs e)
        {
            hasDataOnGrid();
            FilterData();
            ClearView();
            MessageBox.Show("Data filtered successfully.");
        }
        /// <summary>
        /// Toolstrip menu item click event handler to create a new, empty DataGridView and clear all associated UI elements.
        /// </summary>
        /// <param name="e"> The event data associated with the click event.</param>
        /// <param name="sender"> The source of the event, typically the "New" menu item.</param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridViewSensor.Rows.Clear();
            ClearView();
        }
        /// <summary>
        /// Toolstrip menu item click event handler to load sensor data from a file into the DataGridView.
        /// </summary>
        /// <param name="e"> The event data associated with the click event.</param>
        /// <param name="sender"> The source of the event, typically the "Load" menu item.</param>
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadFileFunction();
            ClearView();
        }
        /// <summary>
        /// Function to load sensor data from a specified file into the DataGridView.
        /// </summary>
        /// <param name="filePath"></param>

        /// <summary>
        /// Toolstrip menu item click event handler to save the current sensor data from the DataGridView to a file.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Save" menu item.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string fileName;
            if (currentFileIndex != -1 && fileList != null && currentFileIndex < fileList.Length)
            {
                fileName = fileList[currentFileIndex];
            }
            else
            {
                fileName = string.Empty;
            }
            SaveFileFunction(fileName);
            ClearView();
        }
        /// <summary>
        /// Handles the click event for the "Next File" button, advancing to the next file in the loaded file list.
        /// </summary>
        /// <param name="sender">The source of the event, typically the "Next File" button.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void btnNextFile_Click(object sender, EventArgs e)
        {
            NxtFileFunction();
            ClearView();
        }
        /// <summary>
        /// Handles the click event for the "Previous File" button, 
        /// navigating to the previous file in the loaded file list.
        /// </summary>
        /// <param name="sender">The source of the event, typically the "Previous File" button.</param>
        /// <param name="e">The event data associated with the click event.</param>
        private void btnPreviousFile_Click(object sender, EventArgs e)
        {
            PreviousFileFunction();
            ClearView();
        }
        /// <summary>
        /// Clears the content of all associated UI elements, resetting their text to an empty string.
        /// </summary>
        private void ClearView()
        {
            txtBoxAvg.Clear();
            txtBoxLower.Clear();
            txtBoxUpper.Clear();
            txtUpdate.Clear();
            txtBoxSearch.Clear();
            txtBoxAvg.Clear();
        }
        /// <summary>
        /// Handles the click event for the "Search" button, 
        /// performing a binary search for a specified value in the DataGridView.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Search" button.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            hasDataOnGrid();
            var searchData = txtBoxSearch.Text;
            BinarySearch(Convert.ToDouble(searchData));
            ClearView();
        }
        /// <summary>
        /// Handles the DropDown event of the ComboBox to populate it with the list of loaded files.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the ComboBox control.</param>
        /// <param name="e"> The event data associated with the DropDown event.</param>
        private void ComboBoxListOfFile_DropDown(object sender, EventArgs e)
        {
            if (fileList == null || fileList.Length == 0)
            {
                MessageBox.Show("No files loaded. Please load a file first.", "No Files",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            comboBoxListOfFile.Items.Clear();
            foreach (var file in fileList)
            {
                comboBoxListOfFile.Items.Add(Path.GetFileName(file));
            }
        }
        /// <summary>
        /// Handles the SelectedIndexChanged event of the ComboBox to load the selected file into the DataGridView.
        /// </summary>
        /// <param name="sender">The source of the event, typically the ComboBox control.</param>
        /// <param name="e">The event data associated with the SelectedIndexChanged event.</param>
        private void ComboBoxListOfFile_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fileList == null || fileList.Length == 0)
            {
                MessageBox.Show("No files loaded. Please load a file first.", "No Files",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string selectedFile = comboBoxListOfFile.SelectedItem.ToString();
            int selectedIndex = Array.IndexOf(fileList, Path.Combine(currentDirectory, selectedFile));
            if (selectedIndex != -1)
            {
                currentFileIndex = selectedIndex;
                LoadFile(fileList[currentFileIndex]);
                ClearView();
            }
        }
        /// <summary>
        /// Shows an "About" dialog with application information when the "About" menu item is clicked.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "About" menu item.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sensing4U Application\nVersion 1.0\nDeveloped by Caio Guilherme Ferreira da Silva", "About Sensing4U",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Shows a tutorial dialog with instructions on how 
        /// to use the application when the "Tutorial" menu item is clicked.
        /// </summary>
        /// <param name="sender"> The source of the event, typically the "Tutorial" menu item.</param>
        /// <param name="e"> The event data associated with the click event.</param>
        private void tutorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sensing4U Application Tutorial:\n\n" +
                            "1. Use 'Add Data' to input new sensor readings.\n" +
                            "2. Select a row and use 'Remove' to delete it.\n" +
                            "3. Use 'Sort Data' to sort readings by value.\n" +
                            "4. Select a row and enter a new value to update it.\n" +
                            "5. Calculate average using 'Average'.\n" +
                            "6. Set upper and lower limits for color coding. Red means the value is above and blue means value is below of paramenters\n" +
                            "7. Load and save data using the File menu.\n" +
                            "8. Navigate files with 'Next' and 'Previous' buttons.\n" +
                            "9. Search for specific values using the search feature.", "Sensing4U Tutorial",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        /// <summary>
        /// Function to add a new sensor data entry to the DataGridView by opening an input dialog.
        /// </summary>
        public void AddSensor()
        {
            // Open Add Data Form
            using (var addForm = new AddDataForm())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    string label = addForm.SensorLabel;
                    double value = addForm.SensorValue;
                    dataGridViewSensor.Rows.Add(label, value);
                }
            }
        }
        /// <summary>
        /// Function to remove the selected sensor data entry from the DataGridView.
        /// </summary>
        public void RemoveSensor()
        {
            // Check if a row is selected
            if (dataGridViewSensor.SelectedRows.Count > 0)
            {
                dataGridViewSensor.Rows.RemoveAt(dataGridViewSensor.SelectedRows[0].Index);
                MessageBox.Show("Selected row removed successfully.", "Remove Data");
            }// No row selected
            else
            {
                MessageBox.Show("Please select a row to remove.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Function to sort the sensor data in the DataGridView in ascending order based on their values.
        /// </summary>
        public void SortSensor()
        {
            // Extract data from DataGridView
            var sensorData = new List<(string Label, double Value)>();
            foreach (DataGridViewRow row in dataGridViewSensor.Rows)
            {
                if (row.Cells["SensorValue"].Value != null)
                {
                    sensorData.Add((row.Cells["SensorLabel"].Value.ToString(), Convert.ToDouble(row.Cells["SensorValue"].Value)));
                }
            }// Bubble Sort
            for (int i = 0; i < sensorData.Count - 1; i++)
            {
                for (int j = 0; j < sensorData.Count - i - 1; j++)
                {
                    if (sensorData[j].Value > sensorData[j + 1].Value)
                    {
                        var temp = sensorData[j];
                        sensorData[j] = sensorData[j + 1];
                        sensorData[j + 1] = temp;
                    }
                }
            }
            dataGridViewSensor.Rows.Clear();
            foreach (var data in sensorData)
            {
                dataGridViewSensor.Rows.Add(data.Label, data.Value);
            }
            sorted = true;
            MessageBox.Show("Data sorted in ascending order.", "Sort Data");
        }
        /// <summary>
        /// Function to update the selected sensor data entry in the DataGridView with a new value.
        /// </summary>
        public void UpdateSensor()
        {
            // Check if a row is selected
            if (dataGridViewSensor.SelectedRows.Count > 0)
            {
                var selectedRow = dataGridViewSensor.SelectedRows[0];
                var rowUpdate = txtUpdate.Text.ToString();
                // Validate input
                if (string.IsNullOrWhiteSpace(rowUpdate) || !double.TryParse(rowUpdate, out _))
                {
                    MessageBox.Show("Please enter a value to update.", "No Input",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                // Update value
                else
                {
                    selectedRow.Cells["SensorValue"].Value = txtUpdate.Text;
                    MessageBox.Show("Data has updated", "Update data");
                }
            }
            // No row selected
            else
            {
                MessageBox.Show("Please select a row to update.", "No Selection",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
        /// <summary>
        /// Function to calculate and return the average of all sensor values in the DataGridView.
        /// </summary>
        /// <returns> Average</returns>
        public double AvgSensor()
        {
            double sum = 0;
            int count = dataGridViewSensor.Rows.Count;
            foreach (DataGridViewRow row in dataGridViewSensor.Rows)
            {
                sum += Convert.ToDouble(row.Cells["SensorValue"].Value);
            }
            double average = sum / count;
            return average;
        }
        /// <summary>
        /// Function to filter sensor data based on user-defined upper and lower limits,
        /// </summary>
        public void FilterData()
        {
            // Validate input limits
            double max, min;
            // Try parsing input values
            if (!double.TryParse(txtBoxUpper.Text, out max) ||
                !double.TryParse(txtBoxLower.Text, out min))
            {
                MessageBox.Show("Please enter valid numeric values for max and min.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate logical relationship
            if (min >= max)
            {
                MessageBox.Show("Minimum value must be less than maximum value.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validate non-negative values
            else if (min < 0 || max < 0)
            {
                MessageBox.Show("Values must be non-negative.", "Input Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Apply color coding based on limits
            foreach (DataGridViewRow row in dataGridViewSensor.Rows)
            {
                double value = Convert.ToDouble(row.Cells["SensorValue"].Value);
                if (value >= max)
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                }
                else if (value <= min)
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                }
            }
            txtBoxUpper.Text = max.ToString();
            txtBoxLower.Text = min.ToString();
        }
        /// <summary>
        /// Function to load sensor data from a specified file into the DataGridView.
        /// </summary>
        /// <param name="filePath"> The path of the file to load data from.</param>
        public void LoadFile(string filePath)
        {
            // Clear existing data
            dataGridViewSensor.Rows.Clear();
            string extension = Path.GetExtension(filePath).ToLower();
            // Load BIN file
            if (extension == ".bin")
            {
                using (var reader = new BinaryReader(File.Open(filePath, FileMode.Open)))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        string label = reader.ReadString();
                        double value = reader.ReadDouble();
                        dataGridViewSensor.Rows.Add(label, value);
                    }
                }
            }
            // Load CSV file
            else if (extension == ".csv")
            {
                var lines = File.ReadAllLines(filePath);
                foreach (var line in lines)
                {
                    var parts = line.Split(',');
                    if (parts.Length == 2 && double.TryParse(parts[1], out double value))
                        dataGridViewSensor.Rows.Add(parts[0], value);
                }
            }
            comboBoxListOfFile.Text = Path.GetFileName(filePath);
            sorted = false;
        }
        /// <summary>
        /// Function to open a file dialog for loading sensor data files and load the selected file into the DataGridView.
        /// </summary>
        public void LoadFileFunction()
        {
            // Open File Dialog
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = currentDirectory,
                Filter = "Binary files (*.bin)|*.bin|CSV files (*.csv)|*.csv|All files (*.*)|*.*",
                Title = "Select a sensor data file"
            };
            // Show dialog and load file
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    currentDirectory = Path.GetDirectoryName(openFileDialog.FileName);
                    fileList = Directory.GetFiles(currentDirectory, "*.*")
                                        .Where(f => f.EndsWith(".csv") || f.EndsWith(".bin"))
                                        .ToArray();
                    currentFileIndex = Array.IndexOf(fileList, openFileDialog.FileName);
                    LoadFile(openFileDialog.FileName);
                    MessageBox.Show($"{openFileDialog.FileName} loaded successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading file: {ex.Message}", "Load Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
        /// <summary>
        /// Function to open a save file dialog and save the current sensor data from the DataGridView to a specified file.
        /// </summary>
        public void SaveFileFunction(string fileName)
        {
            // Check if there is data to save
            bool isEmpty = dataGridViewSensor.Rows.Count == 0;
            if (isEmpty)
            {
                MessageBox.Show("No data available to save.", "No Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Open Save File Dialog
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "Binary files (*.bin)|*.bin|CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                // Set initial directory
                if (string.IsNullOrEmpty(currentDirectory) || !Directory.Exists(currentDirectory))
                {
                    currentDirectory = "C:\\Sensing4U\\DataStorage\\";
                }
                saveFileDialog.InitialDirectory = currentDirectory;
                // Set default file name
                if (!string.IsNullOrEmpty(fileName))
                {
                    saveFileDialog.FileName = Path.GetFileName(fileName);
                }
                // Show dialog and save file
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        // Save as BIN
                        if (extension == ".bin")
                        {
                            // Write to binary file
                            using (var writer = new BinaryWriter(File.Open(saveFileDialog.FileName, FileMode.Create)))
                            {
                                foreach (DataGridViewRow row in dataGridViewSensor.Rows)
                                {
                                    writer.Write(row.Cells["SensorLabel"].Value.ToString());
                                    writer.Write(Convert.ToDouble(row.Cells["SensorValue"].Value));
                                }
                            }
                        }
                        // Save as CSV
                        else if (extension == ".csv")
                        {
                            // Write to CSV file
                            using (var writer = new StreamWriter(saveFileDialog.FileName))
                            {
                                foreach (DataGridViewRow row in dataGridViewSensor.Rows)
                                {
                                    writer.WriteLine($"{row.Cells["SensorLabel"].Value},{row.Cells["SensorValue"].Value}");
                                }
                            }
                        }
                        MessageBox.Show("File saved successfully.", "Save File");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving file: {ex.Message}", "Save Error",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
        /// <summary>
        /// Function to navigate to the next file in the loaded file list and load it into the DataGridView.
        /// </summary>
        public void NxtFileFunction()
        {
            // Check if file list is loaded
            if (fileList == null || fileList.Length == 0)
            {
                MessageBox.Show("No files loaded. Please load a file first.", "No Files",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            currentFileIndex = (currentFileIndex + 1) % fileList.Length;
            LoadFile(fileList[currentFileIndex]);
        }
        /// <summary>
        /// Function to navigate to the previous file in the loaded file list and load it into the DataGridView.
        /// </summary>
        public void PreviousFileFunction()
        {
            // Check if fileList is null or empty
            if (fileList == null || fileList.Length == 0)
            {
                MessageBox.Show("No files loaded. Please load a file first.", "No Files",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            currentFileIndex = (currentFileIndex - 1 + fileList.Length) % fileList.Length;
            LoadFile(fileList[currentFileIndex]);
        }
        /// <summary>
        /// Function to perform a binary search for a specified value in the DataGridView.
        /// </summary>
        /// <param name="targetValue"> The value to search for.</param>
        /// <returns> Index of found value or -1 if not found</returns>
        public int BinarySearch(double targetValue)
        {
            var sensorData = new List<(string Label, double Value)>();

            // Sort data if not sorted
            if (!sorted)
                SortSensor();
            double searchValue = targetValue;
            // Extract grid data
            foreach (DataGridViewRow row in dataGridViewSensor.Rows)
            {
                if (row.Cells["SensorValue"].Value != null)
                {
                    sensorData.Add((row.Cells["SensorLabel"].Value.ToString(),
                                    Convert.ToDouble(row.Cells["SensorValue"].Value)));
                }
            }
            int left = 0;
            int right = sensorData.Count - 1;
            int foundIndex = -1;
            // Binary Search
            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                if (sensorData[mid].Value == searchValue)
                {
                    foundIndex = mid;
                    break;
                }

                if (sensorData[mid].Value < searchValue)
                    left = mid + 1;
                else
                    right = mid - 1;
            }
            // No match found
            if (foundIndex == -1)
            {
                MessageBox.Show("Value not found in the data.", "Search Result");
                return -1;
            }
            // Highlight ALL rows with this value
            foreach (DataGridViewRow row in dataGridViewSensor.Rows)
            {
                double value = Convert.ToDouble(row.Cells["SensorValue"].Value);
                if (value == searchValue)
                    row.Cells["SensorValue"].Style.BackColor = Color.Yellow;
            }

            MessageBox.Show($"Value {searchValue} found (highlighted in yellow).", "Search Result");
            return foundIndex;
        }
        /// <summary>
        /// Checks if there is any data in the DataGridView and displays a message if it is empty.
        /// </summary>
        private void hasDataOnGrid()
        {
            if (dataGridViewSensor.Rows.Count == 0)
            {
                MessageBox.Show("No data available to operate this fuction.", "No Data",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }
    }
}
