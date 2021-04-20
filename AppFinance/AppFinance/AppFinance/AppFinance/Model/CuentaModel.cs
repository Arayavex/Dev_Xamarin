using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinance.Model
{
    public class CuentaModel
    {
        public string _id { get; set; }
        public string nombre { get; set; }
        public int balance { get; set; }
        public string user { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
