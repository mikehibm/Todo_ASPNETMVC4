﻿using System;
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
                        .Where(t => t.type != Task.TYPE_DELETED)
                        .OrderBy(t => t.seq)
                        .ToList();

            return View(list);
        }

        [HttpPost]
        public ActionResult AjaxDeleteTask(int id) {
            var context = new TodoEntities();
            var task = context.Tasks.Find(id);
            if (task == null) {
                return HttpNotFound();
            }

            task.type = Task.TYPE_DELETED;
            task.modified = DateTime.Now;

            context.SaveChanges();

            return Json(null);
        }

        [HttpPost]
        public ActionResult AjaxCheckTask(int id) {
            var context = new TodoEntities();
            var task = context.Tasks.Find(id);
            if (task == null) {
                return HttpNotFound();
            }

            if (task.type == Task.TYPE_DONE) {
                task.type = Task.TYPE_NOTYET;
            }
            else {
                task.type = Task.TYPE_DONE;
            }
            task.modified = DateTime.Now;

            context.SaveChanges();

            return Json(null);
        }
    }
}