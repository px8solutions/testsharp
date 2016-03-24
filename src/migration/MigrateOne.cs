using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentMigrator;

namespace migration
{
    [Migration(1)]
    public class MigrateOne : Migration
    {
        public override void Up()
        {
            Create.Table("questions")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("content").AsString().NotNullable()
                .WithColumn("ordinal").AsInt32().NotNullable();
                //.
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
