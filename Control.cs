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
            string result;
            Data xmlcreation  = new Data();
            if (xmlcreation.xmlcheck() == true)
            {
                string there;
                there = "the file exists";
                result = there;
            }
            else
            {
                xmlcreation.xmlcreate();
                string creating = "Not there, So I am creating";
                result =  creating;
            }
            result = this.ReturnValue1;
    }


   }
}
