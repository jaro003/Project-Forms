using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_Forms
{
    public class Administrator
    {
        public string admin_username;
        public string authentication = "High";
    }
   
    public class Employee
    {
        public string emp_username;
        public string authentication = "Medium";
    }
   
    /*public class Transaction
    {
        public DateTime date;
        public double expense;
        public string cust_name;
        public int cust_id;
        public string priority;
        public string category;
    }*/
    
    public class data
    {
        public void add(List<String> array, string name)
        {
            array.Add(name);
        }
    }
}


