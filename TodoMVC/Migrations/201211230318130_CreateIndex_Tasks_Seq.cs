namespace TodoMVC.Migrations {

    using System;
    using System.Data.Entity.Migrations;

    public partial class CreateIndex_Tasks_Seq : DbMigration {

        public override void Up() {
            CreateIndex("Tasks", "seq", false, "IX_Tasks_seq");
        }

        public override void Down() {
            DropIndex("Tasks", "IX_Tasks_seq");
        }
    }
}