using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using testsharp.lib;

namespace demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Question[] wow = Question.List();
            foreach (Question question in wow)
            {
                Console.WriteLine(question.Id + " - " + question.Content);
            }
            


            QuestionCategories c = QuestionCategories.Load(1);
            c.Name = "bar!";
            c.Update();

            //Category c = new Category();
            //c.Name = "Foo";
            //c.Insert();

            Console.WriteLine(c.Id + " " + c.Name);

            //DropdownValueTest();
            FieldTest();
            ListTest();
        }

        static void DropdownValueTest()
        {
            DropdownValue dv = DropdownValue.Load(2);
            dv.id = 1;
            dv.content = "Kroger Brand Seltzer Water";
            dv.fieldId = 2;
            dv.Insert();

            Console.WriteLine("Inserted to dropdown_values, " + dv.fieldId + ", " + dv.content);
        }

        // tests the list method in questions, returns content where id is 1.
        static void ListTest()
        {
            Question[] array = Question.List();
            Console.WriteLine(array[0]);

            Console.WriteLine(QuestionCategories.GetMax());
            QuestionCategories[] catarray = QuestionCategories.List();
            Console.WriteLine(catarray.ToString());
        }

        static void FieldTest()
        {
            Field field = Field.Load(0);
            Console.WriteLine(field.FieldType);
        }

        static void foo()
        {
            //foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
            {
                Assembly assem = Assembly.Load("migration");
                Console.WriteLine(assem.FullName);
                foreach (Type type in assem.GetTypes())
                {
                    Console.Write(type.ToString());
                    if (type.IsSubclassOf(typeof(migration.destinParent)))
                    {
                        Console.Write(" is a Destin!");
                        migration.destinParent d = (migration.destinParent)Activator.CreateInstance(type);
                        Console.WriteLine(d.Up());
                        Console.WriteLine(d.Down());
                    }
                    Console.WriteLine();
                }
            }

        }

    }
}
