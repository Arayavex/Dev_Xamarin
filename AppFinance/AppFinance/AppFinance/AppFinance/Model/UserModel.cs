using System;
using System.Collections.Generic;
using System.Text;

namespace AppFinance.Model
{
    public class UserModel
    {

        public string _id { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }

    }
}
