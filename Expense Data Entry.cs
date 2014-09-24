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
        }

        private void Expense_Data_Entry_Load(object sender, EventArgs e)
        {

        }
        //REQ-1: The End-user can enter expense amounts
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //Michelle Jaro
            //REQ-4: Expenses shall be dollars and cents for all categories except mileage
            //REQ-5: Expenses shall be a decimal number for mileage
            decimal d;
            if(decimal.TryParse(Expenditure.Text, out d))
            {
                MessageBox.Show(Expenditure.Text);
            }
            else
            {
                MessageBox.Show("Please enter a valid number.");
                return;
            }
        }
        //REQ-2: Each expense shall be associated with one category
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
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
