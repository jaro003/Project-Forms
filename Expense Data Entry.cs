using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;//Michelle Jaro

namespace Project_Forms
{
    public partial class Expense_Data_Entry : Form
    {
        
        public Expense_Data_Entry()
        {
            InitializeComponent();

            DateTime dateTime = DateTime.UtcNow.Date;
            label4.Text = DateTime.Now.ToString("MM/dd/yyyy");

            string[] types = new string[] { "Mileage", "Insurance (not health)", "Rent (other)", "Advertising", "Insurance (health)", "Advertising", "Insurance (health)", "Repairs and maintenance", "Automobile", "Interest (mortgage)", "Supplies", "Commissions & Fees", "Interest (other)", "Taxes and licenses", "Contract labor", "Legal & professional fees", "Travel", "Depletion", "Office Expenses", "Travel (meals & entertainment)", "Employee benefits", "Pension & profit sharing plans", "Utilities", "Rent (vehicles & equipment)", "Wages" };
            var source = new AutoCompleteStringCollection();
            source.AddRange(types);
            comboBox1.Items.AddRange(types);
            comboBox1.AutoCompleteCustomSource = source;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void Expense_Data_Entry_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Michelle Jaro
            //REQ-4: Expenses shall be dollars and cents for all categories except mileage
            //REQ-5: Expenses shall be a decimal number for mileage
            decimal d;
            if (decimal.TryParse(Expenditure.Text, out d))
            {
                MessageBox.Show(Expenditure.Text);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }
        }

        //Michelle Jaro
        //Adding data to XML file
        /*XDocument doc = new XDocument();
        XElement xml = new XElement("Expense",
            new XElement("Expenditure", expenditure),
            new XElement("Category", category),
            new XElement("Date", date));
        doc.Add(xml);
        doc.Save(path);*/
    }
}
