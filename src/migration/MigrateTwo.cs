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

            Insert.IntoTable("question_categories").Row(new { id = 0, name = "Use HTML Syntax (25%)" });

        //CaseStudy
            Insert.IntoTable("questions").Row(new { id = 7, content = "Do a case study, press b to fire.", ordinal = 0, type_id = 0, category_id = 0 });

            Insert.IntoTable("questions").Row(new { id = 8, content = "pick one", ordinal = 1, type_id = 0, category_id = 0, parent_id = 7 });
            Insert.IntoTable("responses").Row(new { id = 16, content = "yellow", correct = false, ordinal = 1, question_id = 8 });
            Insert.IntoTable("responses").Row(new { id = 17, content = "double blue", correct = true, ordinal = 2, question_id = 8 });

            Insert.IntoTable("questions").Row(new { id = 9, content = "pick one also", ordinal = 1, type_id = 0, category_id = 0, parent_id = 7 });
            Insert.IntoTable("responses").Row(new { id = 18, content = "GOTO(77);", correct = true, ordinal = 1, question_id = 9 });
            Insert.IntoTable("responses").Row(new { id = 19, content = "Tuesday", correct = true, ordinal = 2, question_id = 9 });

         // MultipleChoiceSingle 
            Insert.IntoTable("questions").Row(new { id = 1, content = "what is an HTML?", ordinal = 1, /* image_url = "http://localhost/im/1.png" */ type_id = 1, category_id = 0, /*parent_id = null*/ });
            Insert.IntoTable("responses").Row(new { id = 1, content="Hypertext Marxism Language", correct = false, ordinal = 1, question_id = 1 });
            Insert.IntoTable("responses").Row(new { id = 2, content = "Hypertext Markup Language", correct = true, ordinal = 2, question_id = 1 });

         // MultipleChoiceMultiple
            Insert.IntoTable("questions").Row(new { id = 2, content = "How do you CSS?", ordinal = 1,  type_id = 2, category_id = 0});
            Insert.IntoTable("responses").Row(new { id = 3, content = "@(#table1)", correct = true, ordinal = 1, question_id = 2 });
            Insert.IntoTable("responses").Row(new { id = 4, content = "';DROP TABLE CSS;", correct = true, ordinal = 2, question_id = 2 });
            Insert.IntoTable("responses").Row(new { id = 5, content = "ACK", correct = false, ordinal = 1, question_id = 2 });



         // DragAndDrop
            Insert.IntoTable("questions").Row(new { id = 3, content = "You have a script, where do the javascript functions go?", ordinal = 1,  image_url = "http://localhost/im/1.png",  type_id = 3, category_id = 0, /*parent_id = null*/ });
            Insert.IntoTable("responses").Row(new { id = 6, content = "function()", correct = true, ordinal = 1, question_id = 3 });
            Insert.IntoTable("responses").Row(new { id = 7, content = "sql()", correct = true, ordinal = 2, question_id = 3 });
            Insert.IntoTable("responses").Row(new { id = 8, content = "writeLine()", correct = true, ordinal = 3, question_id = 3 });

            Insert.IntoTable("fields").Row(new { id = 1, x = 21, y = 32, w = 30, h = 10, response_id = 6, field_type_id = 0 });
            Insert.IntoTable("fields").Row(new { id = 2, x = 31, y = 12, w = 30, h = 10, response_id = 7, field_type_id = 0 });
            Insert.IntoTable("fields").Row(new { id = 3, x = 41, y = 22, w = 30, h = 10, response_id = 8, field_type_id = 0 });


         // ChooseOptions
            Insert.IntoTable("questions").Row(new { id = 4, content = "Select the correct values for the following code segment", ordinal = 1, image_url = "http://localhost/im/2.png", type_id = 4, category_id = 0 });
            Insert.IntoTable("responses").Row(new { id = 9, content = "true", correct = true, ordinal = 1, question_id = 3 });

         // CreateSingleList
            Insert.IntoTable("questions").Row(new { id = 5, content = "you doing an HTML. order it.", ordinal = 1, type_id = 5, category_id = 0 });
            Insert.IntoTable("responses").Row(new { id = 10, content = "a book", correct = true, ordinal = 0, question_id = 5 });
            Insert.IntoTable("responses").Row(new { id = 11, content = "jQuery.exe", correct = true, ordinal = 1, question_id = 5 });
            Insert.IntoTable("responses").Row(new { id = 12, content = "FAT32", correct = true, ordinal = 2, question_id = 5 });

         // CreateDoubleList
            Insert.IntoTable("questions").Row(new { id = 6, content = "if you have 5 jQueries, put the correct ones in order", ordinal = 1, type_id = 6, category_id=0 });
            Insert.IntoTable("responses").Row(new { id = 13, content = "7 times", correct = true, ordinal = 0, question_id = 6 });
            Insert.IntoTable("responses").Row(new { id = 14, content = "no", correct = false, ordinal = 1, question_id = 6 });
            Insert.IntoTable("responses").Row(new { id = 15, content = "NTFS", correct = true, ordinal = 2, question_id = 6 });

            // Create Dropdown
            Insert.IntoTable("dropdown_values").Row(new { id = 0, content = "fix the jqueries", field_id = 2 }); 

        }

        public override void Down()
        {
            // Delete.Table("little_joe"); //what was this for???
        }


    }
}
