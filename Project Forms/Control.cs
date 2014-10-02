using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace Project_Forms
{
    class Control
    {
        public string ReturnValue1 { get; set; } 
        public void createxmlfile()
        {
            Data xmlcreation  = new Data();
            if (xmlcreation.xmlcheck() == false)
            {
                xmlcreation.xmlcreate();
            }            
        }

        public void addatransaction(decimal expenditure, string category, DateTime date, string name)
        {

            Data newtransaction = new Data();
            newtransaction.add_transaction(expenditure, category, date,name);
            newtransaction.add_history(date, name);
            
        }
        
        public void add_history(string name, DateTime date)
        {
            Data newtransaction = new Data();
            newtransaction.login_history(name, date);
        }
    
    
    }




}
