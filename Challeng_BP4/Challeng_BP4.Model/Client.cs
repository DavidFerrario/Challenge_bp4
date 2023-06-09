using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Challeng_BP4.Model
{
    public class Client
    {

        public int ID { get; set; }
       
        public string name { get; set; }

        public string lastName { get; set; }

        public DateTime birthdate { get; set; }

        public string cuit { get; set; }

        public string adress { get; set; }

        public string cell_phone { get; set; }

        public string email { get; set; }


    }
}
