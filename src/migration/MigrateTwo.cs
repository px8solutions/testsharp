using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace migration
{
    [Migration(2)]
    public class MigrateTwo : Migration
    {
        public override void Down()
        {
            Delete.Table("little_joe");
        }

        public override void Up()
        {
            Create.Table("little_joe")
                .WithColumn("id").AsInt32().PrimaryKey();
        }
    }
}
