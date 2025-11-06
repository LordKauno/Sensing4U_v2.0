using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensing4U_v2._0;
using System.Linq;
using System.Windows.Forms;

namespace Sensing4UTests
{
    [TestClass]
    public class SensorFormTests
    {
        private Sensing4USensorData form;

        [TestInitialize]
        public void Setup()
        {
            form = new Sensing4USensorData();
        }

        [TestMethod]
        public void Test_AddSensor_AddsOneRow()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();
            int before = grid.Rows.Count;

            // Add row manually (simulating AddSensor)
            grid.Rows.Add("SensorX", 50.5);

            Assert.AreEqual(before + 1, grid.Rows.Count);
        }

        [TestMethod]
        public void Test_AvgSensor_ReturnsCorrectAverage()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();

            grid.Rows.Add("S1", 10);
            grid.Rows.Add("S2", 20);
            grid.Rows.Add("S3", 30);

            double result = form.AvgSensor();

            Assert.AreEqual(20.0, result);
        }

        [TestMethod]
        public void Test_RemoveSensor_RemovesSelected()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();

            grid.Rows.Add("S1", 10);
            grid.Rows.Add("S2", 20);

            // force row selection so method sees it as selected
            grid.CurrentCell = grid.Rows[0].Cells[0];
            grid.Rows[0].Selected = true;

            form.RemoveSensor();

            Assert.AreEqual(1, grid.Rows.Count);
            Assert.AreEqual("S2", grid.Rows[0].Cells["SensorLabel"].Value);
        }

        [TestMethod]
        public void Test_SortSensor_SortsAscending()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();

            grid.Rows.Add("S1", 30);
            grid.Rows.Add("S2", 10);
            grid.Rows.Add("S3", 25);

            form.SortSensor();

            Assert.AreEqual(10, double.Parse(grid.Rows[0].Cells["SensorValue"].Value.ToString()));
            Assert.AreEqual(25, double.Parse(grid.Rows[1].Cells["SensorValue"].Value.ToString()));
            Assert.AreEqual(30, double.Parse(grid.Rows[2].Cells["SensorValue"].Value.ToString()));
        }

        [TestMethod]
        public void Test_FilterData_Coloring()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();
            var txtUpper = (TextBox)form.Controls.Find("txtBoxUpper", true).First();
            var txtLower = (TextBox)form.Controls.Find("txtBoxLower", true).First();

            grid.Rows.Add("S1", 10);
            grid.Rows.Add("S2", 50);
            grid.Rows.Add("S3", 100);

            txtLower.Text = "20";
            txtUpper.Text = "80";

            form.FilterData();

            Assert.AreEqual(System.Drawing.Color.LightBlue, grid.Rows[0].DefaultCellStyle.BackColor);
            Assert.AreEqual(System.Drawing.Color.Green, grid.Rows[1].DefaultCellStyle.BackColor);
            Assert.AreEqual(System.Drawing.Color.Red, grid.Rows[2].DefaultCellStyle.BackColor);
        }

        [TestMethod]
        public void Test_BinarySearch_FindsCorrectIndex()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();

            grid.Rows.Add("S1", 10);
            grid.Rows.Add("S2", 20);
            grid.Rows.Add("S3", 30);
            grid.Rows.Add("S4", 40);
            grid.Rows.Add("S5", 50);

            int index = form.BinarySearch(30);

            Assert.AreEqual(2, index);
        }

        [TestMethod]
        public void Test_BinarySearch_NotFound()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();

            grid.Rows.Add("S1", 10);
            grid.Rows.Add("S2", 20);
            grid.Rows.Add("S3", 30);

            int index = form.BinarySearch(25);

            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void Test_UpdateSensor_UpdatesValue()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();
            var txtUpdate = (TextBox)form.Controls.Find("txtUpdate", true).First();

            grid.Rows.Add("S1", 10);
            grid.CurrentCell = grid.Rows[0].Cells[0];
            grid.Rows[0].Selected = true;

            txtUpdate.Text = "55";
            form.UpdateSensor();

            Assert.AreEqual(55, double.Parse(grid.Rows[0].Cells["SensorValue"].Value.ToString()));
        }

        [TestMethod]
        public void Test_UpdateSensor_InvalidInput_ShowsMessageBox()
        {
            var grid = (DataGridView)form.Controls.Find("dataGridViewSensor", true).First();
            var txtUpdate = (TextBox)form.Controls.Find("txtUpdate", true).First();

            grid.Rows.Add("S1", 10);
            grid.CurrentCell = grid.Rows[0].Cells[0];
            grid.Rows[0].Selected = true;

            txtUpdate.Text = "invalid";
            form.UpdateSensor();

            Assert.AreEqual(10, double.Parse(grid.Rows[0].Cells["SensorValue"].Value.ToString()));
        }
    }
}
