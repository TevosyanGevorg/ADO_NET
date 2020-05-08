﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Linq.Mapping;

namespace ADO_NET_15
{
    [Table(Name ="Users")]
    public class User
    {
        [Column(IsPrimaryKey=true,IsDbGenerated =true)]
        public int Id { get; set; }
        [Column(Name ="Name")]
        public string FirsName { get; set; }
        [Column]
        public int Age { get; set; }
    }
}
