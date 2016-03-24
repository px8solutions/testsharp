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
                .WithColumn("ordinal").AsInt32().NotNullable()
                .WithColumn("layout_url").AsString().Nullable()
                .WithColumn("type_id").AsInt32().NotNullable().ForeignKey("question_types", "id")
                .WithColumn("category_id").AsInt32().NotNullable().ForeignKey("question_categories", "id")
                .WithColumn("parent_id").AsInt32().Nullable().ForeignKey("questions", "id");

            Create.Table("question_categories")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();

            Create.Table("question_types")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();

            Create.Table("responses")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("content").AsString().NotNullable()
                .WithColumn("correct").AsBoolean().NotNullable()
                .WithColumn("ordinal").AsInt32().NotNullable()
                .WithColumn("question_id").AsInt32().NotNullable().ForeignKey("questions", "id");

            /*
            CreateTable("fields")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("x").AsInt16().NotNullable()
                .WithColumn("y").AsInt16().
            */


        }

        public override void Down()
        {
            throw new NotImplementedException();
        }
    }
}
