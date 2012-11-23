using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Models;

namespace TodoMVC.Controllers {

    public class TasksController : Controller {

        //
        // GET: /Tasks/

        public ActionResult Index() {
            var context = new TodoEntities();
            var list = context.Tasks
                        .Where(t => t.type != "deleted")
                        .OrderBy(t => t.seq)
                        .ToList();

            return View(list);
        }
    }
}