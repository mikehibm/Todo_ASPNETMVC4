using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TodoMVC.Models {

    public class TodoEntities : DbContext {

        public TodoEntities()
            : base("DefaultConnection") {
        }
    }
}