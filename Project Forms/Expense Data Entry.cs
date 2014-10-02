using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Project_Forms
{
    public partial class Expense_Data_Entry : Form
    {
        int transid = 0;
       
        public Expense_Data_Entry(string username)
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;

            label8.Hide();
            label2.Hide();
            textBox1.Hide();

            label7.Text = username;

            DateTime dateTime = DateTime.UtcNow.Date;
            label4.Text = DateTime.Now.ToString("MM/dd/yyyy");

            string[] types = new string[] { "Mileage", "Insurance (not health)", "Rent (other)", "Advertising", "Insurance (health)", "Advertising", "Insurance (health)", "Repairs and maintenance", "Automobile", "Interest (mortgage)", "Supplies", "Commissions & Fees", "Interest (other)", "Taxes and licenses", "Contract labor", "Legal & professional fees", "Travel", "Depletion", "Office Expenses", "Travel (meals & entertainment)", "Employee benefits", "Pension & profit sharing plans", "Utilities", "Rent (vehicles & equipment)", "Wages" };
            var source = new AutoCompleteStringCollection();
            source.AddRange(types);
            comboBox1.Items.AddRange(types);
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            
            //comboBox1.AutoCompleteCustomSource = source;
            //comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            //comboBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Error: You forgot to pick a category");
            }

            else if (textBox1.Text == "")
            {
                MessageBox.Show("Error: You forgot to enter an expense");
            }
            
            else
            {
                decimal expense = Convert.ToDecimal(textBox1.Text);
                DateTime date = Convert.ToDateTime(dateTimePicker1.Value.ToShortDateString());
                Control newdata = new Control();

                newdata.addatransaction(expense, comboBox1.Text, date, label7.Text);
                MessageBox.Show("The record has been inserted");
                this.Close();

            }
        }

        private void textBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {

            //KeysConverter kc = new KeysConverter();
            //string KeyString = kc.ConvertToString(e.KeyData);
            //int i = KeyString.Length - 1;
            //char KeyChar = KeyString[i];

            //Regex rx = new Regex(@"[0-9]");
            //Match rxm = rx.Match(textBox1.Text);
            
            //if (rxm.Success)
            //{
            //    e.Handled = true;
            //}
            //else
            //    e.Handled = false;
               
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void expenseReportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            Expense_Reports call = new Expense_Reports();
            
            this.Close();
            call.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        string KeyString="";
        string input = "";

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            input = KeyString;
            KeyString += e.KeyChar.ToString();

            if (comboBox1.Text != "Mileage")
            {
                Regex rx = new Regex(@"^(((\d{0,20}))((\.?)(\d{1,2})?))$");
                Match rxm = rx.Match(KeyString);
                if (!rxm.Success)
                {
                    KeyString = input;
                    e.Handled = true;
                }
                else
                {

                    e.Handled = false;
                }
            }
            else
            {
                Regex rx = new Regex(@"^(((\d{0,20}))((\.?)(\d{0,14})?))$");
                Match rxm = rx.Match(KeyString);
                if (!rxm.Success)
                {
                    KeyString = input;
                    e.Handled = true;
                }
                else
                {

                    e.Handled = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Show();
            label2.Show();
            textBox1.Text = "";
            KeyString = "";
            if(comboBox1.Text == "Mileage")
            {
                label8.Text = "miles";
                label8.Show();
                
            }
            else
            {
                label8.Text = "$";
                label8.Show();
            }
        }

       
        

       
      
    }
}
