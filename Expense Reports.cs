using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Forms
{
    public partial class Expense_Reports : Form
    {
        public Expense_Reports(string name)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            label4.Text = name;
            label5.Text = DateTime.Now.ToString("MM/dd/yyyy");

            //Category drop down list
            string[] types = new string[] { "All Categories", "Mileage", "Insurance (not health)", "Rent (other)", "Advertising", "Insurance (health)", "Advertising", "Insurance (health)", "Repairs and maintenance", "Automobile", "Interest (mortgage)", "Supplies", "Commissions & Fees", "Interest (other)", "Taxes and licenses", "Contract labor", "Legal & professional fees", "Travel", "Depletion", "Office Expenses", "Travel (meals & entertainment)", "Employee benefits", "Pension & profit sharing plans", "Utilities", "Rent (vehicles & equipment)", "Wages" };
            var source = new AutoCompleteStringCollection();
            source.AddRange(types);
            comboBox1.Items.AddRange(types);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //List<Transaction> transList;
            if(comboBox1.Text == "")
            {
                MessageBox.Show("Error: You forgot to pick a category");
            }
            else
            {
                DateTime startDate = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
                DateTime endDate = Convert.ToDateTime(dateTimePicker2.Value.ToShortDateString());
                Control loadData = new Control();
                //Data loadReport = new Data();

                loadData.loadExpenseReport(startDate, endDate, comboBox1.Text);//Use start date, end date, and category
                //dataGridView1.DataSource = loadData.expe;//Display in text field (date, expense, total expense)
                  
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
