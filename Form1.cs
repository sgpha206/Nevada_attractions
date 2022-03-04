using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace NevadaAttractions
{
    public partial class Form1 : Form
    {
        ComboBox myBox = new ComboBox();

        string workingDirectory = Environment.CurrentDirectory;
        string projectDirectory = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
        public Form1()
        {
            InitializeComponent();
        }

        private void table1BindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.table1BindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.touristspotsDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'touristspotsDataSet.Table1' table. You can move, or remove it, as needed.
            this.table1TableAdapter.Fill(this.touristspotsDataSet.Table1);
            textBox1.Text = projectDirectory;

            string hlink = locationTextBox1.Text;
            hlink = hlink.Remove(0, 1);
            locationTextBox1.Text = hlink;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            var ps = new ProcessStartInfo(locationTextBox1.Text)
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
            //Process.Start($"{locationTextBox.Text}");
        }

        private void pictureTextBox_TextChanged(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = projectDirectory + "\\" + pictureTextBox.Text;
            if (System.IO.File.Exists(pictureTextBox.Text))
                pictureBox1.Load(pictureTextBox.Text);
            else
                pictureBox1.Image = null;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureTextBox.Text = openFileDialog1.FileName;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void filterbutton_Click(object sender, EventArgs e)
        {
            try
            {
                // Query database  
                var contactDetails =
                   from t in touristspotsDataSet.Table1
                   where t.Price < 100
                   orderby t.Price
                   select t;
                //  touristspotsDataSet.Table1DataSource = contactDetails.AsDataView();
                table1BindingSource.DataSource = contactDetails.AsDataView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    // Query database  
                    var contactDetails =
                       from t in touristspotsDataSet.Table1
                       where t.Price < 1
                       orderby t.Price
                       select t;
                    //  touristspotsDataSet.Table1DataSource = contactDetails.AsDataView();
                    table1BindingSource.DataSource = contactDetails.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


            try
            {
                if (comboBox1.SelectedIndex == 1)
                {
                    // Query database  
                    var contactDetails =
                       from t in touristspotsDataSet.Table1
                       where t.Price < 10
                       orderby t.Price
                       select t;
                    //  touristspotsDataSet.Table1DataSource = contactDetails.AsDataView();
                    table1BindingSource.DataSource = contactDetails.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (comboBox1.SelectedIndex == 2)
                {
                    // Query database  
                    var contactDetails =
                       from t in touristspotsDataSet.Table1
                       where t.Price < 30
                       where t.Price > 10
                       orderby t.Price
                       select t;
                    //  touristspotsDataSet.Table1DataSource = contactDetails.AsDataView();
                    table1BindingSource.DataSource = contactDetails.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (comboBox1.SelectedIndex == 3)
                {
                    // Query database  
                    var contactDetails =
                       from t in touristspotsDataSet.Table1
                       where t.Price < 100
                       where t.Price > 30
                       orderby t.Price
                       select t;
                    //  touristspotsDataSet.Table1DataSource = contactDetails.AsDataView();
                    table1BindingSource.DataSource = contactDetails.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                if (comboBox1.SelectedIndex == 4)
                {
                    // Query database  
                    var contactDetails =
                       from t in touristspotsDataSet.Table1
                       where t.Price > 99
                       orderby t.Price
                       select t;
                    //  touristspotsDataSet.Table1DataSource = contactDetails.AsDataView();
                    table1BindingSource.DataSource = contactDetails.AsDataView();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        


        private void locationTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void iDTextBox_TextChanged(object sender, EventArgs e)
        {
            string link = locationTextBox1.Text;
            link = link.Remove(0, 1);
            locationTextBox1.Text = link;
        }

        private void priceTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
