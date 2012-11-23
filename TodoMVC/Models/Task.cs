﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoMVC.Models {

    public class Task {

        [Key]
        public int id { get; set; }

        public int seq { get; set; }

        public string type { get; set; }        //'notyet', 'done', 'deleted'

        public string title { get; set; }

        public DateTime created { get; set; }

        public DateTime modified { get; set; }
    }
}