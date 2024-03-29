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

        [HttpPost]
        public ActionResult AjaxSortTask(string task) {
            var task_ids = HttpUtility.ParseQueryString(task);
            var task_list = task_ids[0].Split(",".ToCharArray());

            var context = new TodoEntities();

            for (int i = 0; i < task_list.Length; i++) {
                int id = Int32.Parse(task_list[i]);
                var item = context.Tasks.Find(id);
                item.seq = i;
            }
            context.SaveChanges();

            return Json(null);
        }

        [HttpPost]
        public ActionResult AjaxEditTask(int id, string title) {
            var context = new TodoEntities();
            var task = context.Tasks.Find(id);
            if (task == null) {
                return HttpNotFound();
            }

            task.title = title;
            task.modified = DateTime.Now;

            context.SaveChanges();

            return Json(null);
        }

        [HttpPost]
        public ActionResult AjaxAddTask(string title) {
            var context = new TodoEntities();

            var max_seq = context.Tasks.Max(t => t.seq);

            var task = new Task();
            task.seq = max_seq + 1;
            task.type = Task.TYPE_NOTYET;
            task.title = title;
            task.created = DateTime.Now;
            task.modified = task.created;

            context.Tasks.Add(task);
            context.SaveChanges();

            return Json(task.id);
        }
    }
}