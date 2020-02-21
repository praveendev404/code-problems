using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    class VarDynamicObject
    {
        static void Main1(string[] args)
        {
            VarDynamicObject varDynamicObject = new VarDynamicObject();
            varDynamicObject.ObjectMethod();
            varDynamicObject.DynamicMethod();
            varDynamicObject.VarMethod();
        }
        void ObjectMethod()
        {
            object a = "Some Text";
            string text = a.ToString();

            // call a string method
            text = text.ToUpper();

            object i = 10; // declared as object but instance of int
            int intValue = (int)i; //declare as an int ... typed
        }
        void DynamicMethod()
        {
            dynamic a = new ClassTest();
            a.Age = 18;
            a.Name = "Jon";
            a.Product = new Product();

             a.Product.Name = a.Name; // read a string
             a.Product.Age = a.Age; // read an int
            string name = a.Product.Name; // read a property
        }
        void VarMethod()
        {
            var a = 10; // int
            var b = 10d; // double
            var c = "text"; // string
            a = 2;
            var p = new Product(); // Product type

        }
    }

    class ClassTest
    {
        public Product Product { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }

    }
    class Product
    {
        public int Age { get; set; }
        public string Name { get; set; }

    }
}
