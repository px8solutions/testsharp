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
            Create.Table("question_categories")
                .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();

            Create.Table("question_types")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();

            Insert.IntoTable("question_types").Row(new { id = 0, name = "CaseStudy" });
            Insert.IntoTable("question_types").Row(new { id = 1, name = "MultipleChoiceSingle" });
            Insert.IntoTable("question_types").Row(new { id = 2, name = "MultipleChoiceMultiple" });
            Insert.IntoTable("question_types").Row(new { id = 3, name = "DragAndDrop" });
            Insert.IntoTable("question_types").Row(new { id = 4, name = "ChooseOptions" });
            Insert.IntoTable("question_types").Row(new { id = 5, name = "CreateSingleList" });
            Insert.IntoTable("question_types").Row(new { id = 6, name = "CreateDoubleList" });

            Create.Table("questions")
                .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("content").AsString().NotNullable()
                .WithColumn("ordinal").AsInt32().NotNullable()
                .WithColumn("image_url").AsString().Nullable()
                .WithColumn("type_id").AsInt32().NotNullable().ForeignKey("question_types", "id")
                .WithColumn("category_id").AsInt32().NotNullable().ForeignKey("question_categories", "id")
                .WithColumn("parent_id").AsInt32().Nullable().ForeignKey("questions", "id");

            Create.Table("responses")
                .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("content").AsString().NotNullable()
                .WithColumn("correct").AsBoolean().NotNullable()
                .WithColumn("ordinal").AsInt32().NotNullable()
                .WithColumn("question_id").AsInt32().NotNullable().ForeignKey("questions", "id");

            Create.Table("field_types")
                .WithColumn("id").AsInt32().NotNullable().PrimaryKey()
                .WithColumn("name").AsString().NotNullable();

            Insert.IntoTable("field_types").Row(new { id = 0, name = "TextBox" });
            Insert.IntoTable("field_types").Row(new { id = 1, name = "DropDown" });
            Insert.IntoTable("field_types").Row(new { id = 2, name = "Checkmark" });

            Create.Table("fields")
                .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("x").AsInt16().NotNullable() //not nullable appears to be implicit, also needs to be nullable for checkmark type.
                .WithColumn("y").AsInt16().NotNullable()
                .WithColumn("w").AsInt16().NotNullable()
                .WithColumn("h").AsInt16().NotNullable()
                .WithColumn("response_id").AsInt32().NotNullable().ForeignKey("responses", "id")
                .WithColumn("field_type_id").AsInt32().NotNullable().ForeignKey("field_types", "id");


            Create.Table("dropdown_values")
                .WithColumn("id").AsInt32().NotNullable().Identity().PrimaryKey()
                .WithColumn("content").AsString().NotNullable()
                .WithColumn("field_id").AsInt32().NotNullable().ForeignKey("fields", "id");
        }

        public override void Down()
        {
            Delete.Table("dropdown_values");
            Delete.Table("fields");
            Delete.Table("field_types");
            Delete.Table("responses");
            Delete.Table("questions");
            Delete.Table("question_types");
            Delete.Table("question_categories");
        }
    }
}
