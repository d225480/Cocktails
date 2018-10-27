using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace App5
{
    class cocktails
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string description { get; set; }
        public string alcohol { get; set; }

    }
}
