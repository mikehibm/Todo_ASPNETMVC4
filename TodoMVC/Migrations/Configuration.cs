using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using TodoMVC.Models;

namespace TodoMVC.Migrations {

    internal sealed class Configuration : DbMigrationsConfiguration<TodoMVC.Models.TodoEntities> {

        public Configuration() {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(TodoMVC.Models.TodoEntities context) {
            context.Tasks.AddOrUpdate(
                    t => t.seq,
                    new Task { seq = 1, type = "notyet", title = "Test 1", created = DateTime.Now, modified = DateTime.Now },
                    new Task { seq = 2, type = "notyet", title = "Test 2222", created = DateTime.Now, modified = DateTime.Now },
                    new Task { seq = 3, type = "notyet", title = "Test 3333333333", created = DateTime.Now, modified = DateTime.Now }
                );
        }
    }
}