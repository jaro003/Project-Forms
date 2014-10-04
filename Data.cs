using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
namespace Project_Forms
{
    public class Transaction
    {
        public DateTime Date { get; set; }
        public string Category { get; set; }
        public decimal Expense { get; set; }
        //public string Cust_name { get; set; }
        //public int cust_id { get; set; }
        //public string priority { get; set; }
    }

   class Data
    {
        //decimal ex = 0;
        int idnum = 0;
        Transaction trans = new Transaction();
        public List<Transaction> expenseReport = new List<Transaction>();//List of expenses requested by user

        public void xmlcreate()
        {

            XDocument Database =
       new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),
          new XComment("This database will store transactions under <Transaction> label"),
          new XComment("This transaction history     will be stored under History_Username"),
          new XElement("App_Records",
             new XElement("All_Transactions"),
             new XElement("Change_History", new XElement("DefaultID", 1)), new XElement("Login_History")));

            Database.Save(@"check.xml");
        }



        public bool xmlcheck()
        {
            if (File.Exists(@"check.xml"))
                return true;
            else 
                return false;
        }

        public void add_transaction(decimal expenditure, string category, DateTime date, string name)
        {
             int id = 1;
            XDocument get_id = XDocument.Load("check.xml");
            var ids = from id1 in get_id.Descendants("Change_History")
                      select new
                      {
                          id = id1.Element("DefaultID").Value
                      };
            foreach (var id1 in ids)
            { id = Convert.ToInt32(id1.id); }

            idnum = id;
           

            var doc = XDocument.Load("check.xml");
           doc.Element("App_Records").Element("All_Transactions").Add(new XElement("Transaction",
                                    new XElement("Added_by", name),
                                     new XAttribute("Id", id),
                                     new XElement("Date", date),
                                     new XElement("Category", category),
                                     new XElement("Expenditure",expenditure)));
           id++;
           doc.Element("App_Records").Element("Change_History").Element("DefaultID").SetValue(id);
            doc.Save(@"check.xml");
            
        }

        public void add_history(DateTime date, string user)
        {
            
            var doc = XDocument.Load("check.xml");
            doc.Element("App_Records").Element("Change_History").Add(new XElement("Record", new XAttribute("ChangeID", idnum), 
                                     new XElement("Transaction_Date", date), new XElement("Adding_user", user)));
            doc.Save(@"check.xml");
        }
        
        public void login_history(string username, DateTime date)
        {
             var doc = XDocument.Load(@"check.xml");
           doc.Element("App_Records").Element("Login_History").Add(new XElement("Log", new XAttribute("username", username), new XElement("last_login", date)));
           doc.Save(@"check.xml");
        }
//Michelle Jaro------------------------------------------------------------------------------------------------------------------------------------------------------
        public void loadExpenses(DateTime start, DateTime end, string category)
        {
            //Identify all the data that matches the parameters
            XDocument xmlDoc = XDocument.Load(@"check.xml");
            if (category == "All Cateogires")//Transactions for all categories in specified time frame
            {
                var all = from exp in xmlDoc.Descendants("Transaction")
                          where ((DateTime)exp.Element("Date") >= start || (DateTime)exp.Element("Date") <= end)
                          select new
                          {
                              date = (DateTime)exp.Element("Date"),
                              category = exp.Element("Category").Value,
                              expense = exp.Element("Expenditure").Value
                          };
                foreach (var exp in all)
                {
                    trans.Date = exp.date;
                    trans.Category = exp.category;
                    trans.Expense = Convert.ToDecimal(exp.expense);
                    expenseReport.Add(trans);
                }
            }
            else//Transactions with one specific category in specified time frame
            {
                var one = from e in xmlDoc.Descendants("Transaction")
                          where ((e.Element("Category").Value == category) && (((DateTime)e.Element("Date") >= start) || (DateTime)e.Element("Date") <= end))
                          select new
                          {
                              date = (DateTime)e.Element("Date"),
                              category = e.Element("Category").Value,
                              expense = e.Element("Expenditure").Value
                          };

                foreach (var e in one)
                {
                    trans.Date = e.date;
                    trans.Category = e.category;
                    trans.Expense = Convert.ToDecimal(e.expense);
                    expenseReport.Add(trans);
                }
            }

            //string toDisplay = string.Join(Environment.NewLine, expenseReport);
            //MessageBox.Show(toDisplay);
        }   
    }
} 
//------------------------------------------------------------------------------------------------------------------------------------------------------------------------        
