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
        public override void Up()
        {
            //   Create.Table("little_joe")
            //       .WithColumn("id").AsInt32().PrimaryKey(); //what was this for???

         // MultipleChoiceSingle 

            Insert.IntoTable("question_categories").Row(new { id = 0, name = "Use HTML Syntax (25%)" });

            Insert.IntoTable("questions").Row(new { id = 1, content = "what is an HTML?", ordinal = 1, /* image_url = "http://localhost/im/1.png" */ type_id = 1, category_id = 0, /*parent_id = null*/ });

            Insert.IntoTable("responses").Row(new { id = 1, content="Hypertext Marxism Language", correct = false, ordinal = 1, question_id = 1 });

            Insert.IntoTable("responses").Row(new { id = 2, content = "Hypertext Markup Language", correct = true, ordinal = 2, question_id = 1 });

            //Insert.IntoTable("fields").Row(new { id = 1, response_id = 1, field_type_id = 2 }); //not needed for MultipleChoiceSingle, MultipleChoiceMultiple

         // end of MultipleChoiceSingle


         // MultipleChoiceMultiple

            Insert.IntoTable("questions").Row(new { id = 2, content = "How do you CSS?", ordinal = 1,  type_id = 2, category_id = 0});

            Insert.IntoTable("responses").Row(new { id = 3, content = "@(#table1)", correct = true, ordinal = 1, question_id = 2 });

            Insert.IntoTable("responses").Row(new { id = 4, content = "';DROP TABLE CSS;", correct = true, ordinal = 2, question_id = 2 });

            Insert.IntoTable("responses").Row(new { id = 5, content = "ACK", correct = false, ordinal = 1, question_id = 2 });

            // end of MultipleChoiceMultiple


         // DragAndDrop
            Insert.IntoTable("questions").Row(new { id = 3, content = "You have a script, where do the javascript functions go?", ordinal = 1,  image_url = "http://localhost/im/1.png",  type_id = 3, category_id = 0, /*parent_id = null*/ });
            Insert.IntoTable("responses").Row(new { id = 6, content = "function()", correct = true, ordinal = 1, question_id = 3 });
            Insert.IntoTable("responses").Row(new { id = 7, content = "sql()", correct = true, ordinal = 2, question_id = 3 });
            Insert.IntoTable("responses").Row(new { id = 8, content = "writeLine()", correct = true, ordinal = 3, question_id = 3 });

            Insert.IntoTable("fields").Row(new { id = 1, x = 21, y = 32, w = 30, h = 10, response_id = 6, field_type_id = 0 });
            Insert.IntoTable("fields").Row(new { id = 2, x = 31, y = 12, w = 30, h = 10, response_id = 7, field_type_id = 0 });
            Insert.IntoTable("fields").Row(new { id = 3, x = 41, y = 22, w = 30, h = 10, response_id = 8, field_type_id = 0 });
         // end of DragAndDrop


         //ChooseOptions
            Insert.IntoTable("questions").Row(new { id = 4, content = "Select the correct values for the following code segment", ordinal = 1, image_url = "http://localhost/im/2.png", type_id = 4, category_id = 0 });

            Insert.IntoTable("responses").Row(new { id = 9, content = "true", correct = true, ordinal = 1, question_id = 3 });

        }

        public override void Down()
        {
            // Delete.Table("little_joe"); //what was this for???
        }


    }
}
