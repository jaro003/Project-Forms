using System;
using System.IO;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Text;

namespace Project_Forms
{
    class Data
    {
        public void xmlcreate()
        {

            XDocument contactsDoc =
       new XDocument(
          new XDeclaration("1.0", "utf-8", "yes"),
          new XComment("LINQ to XML Contacts XML Example"),
          new XProcessingInstruction("MyApp", "123-44-4444"),
          new XElement("contacts",
             new XElement("contact",
                new XElement("name", "Patrick Hines"),
                new XElement("phone", "206-555-0144"),
                new XElement("address",
                   new XElement("street1", "123 Main St"),
                   new XElement("city", "Mercer Island"),
                   new XElement("state", "WA"),
                   new XElement("postal", "68042")
                )
             )
          )
       );
        }



        public bool xmlcheck()
        {
            if(File.Exists(@"check.xml"));
            return true;    
        }
    }
}  
        
