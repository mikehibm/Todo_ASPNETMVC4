using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TodoMVC.Models {

    public class Task {
        public const string TYPE_NOTYET = "notyet";
        public const string TYPE_DONE = "done";
        public const string TYPE_DELETED = "deleted";

        [Key]
        public int id { get; set; }

        public int seq { get; set; }

        [StringLength(10)]
        public string type { get; set; }        //'notyet', 'done', 'deleted'

        [StringLength(200)]
        public string title { get; set; }

        public DateTime created { get; set; }

        public DateTime modified { get; set; }
    }
}