namespace TodoMVC.Migrations {

    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateIndex_Tasks_type : DbMigration {

        public override void Up() {
            CreateIndex("Tasks", "type", false, "IX_Tasks_type");
        }

        public override void Down() {
            DropIndex("Tasks", "IX_Tasks_type");
        }
    }
}