using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public class Customer
    {
        public Customer(int id, string name)
        {
            ID = id;
            Name = name;
        }

        private int m_id;

        public int ID
        {
            get { return m_id; }
            set { m_id = value; }
        }

        private string m_name;

        public string Name
        {
            get { return m_name; }
            set { m_name = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<int> myInts = new List<int>();

            myInts.Add(1);
            myInts.Add(2);
            myInts.Add(3);

            for (int i = 0; i < myInts.Count; i++)
            {
                Console.WriteLine("MyInts: {0}", myInts[i]);
            }

            Dictionary<int, Customer> customers = new Dictionary<int, Customer>();

            Customer cust1 = new Customer(1, "Cust 1");
            Customer cust2 = new Customer(2, "Cust 2");
            Customer cust3 = new Customer(3, "Cust 3");

            customers.Add(cust1.ID, cust1);
            customers.Add(cust2.ID, cust2);
            customers.Add(cust3.ID, cust3);

            foreach (KeyValuePair<int, Customer> custKeyVal in customers)
            {
                Console.WriteLine(
                    "Customer ID: {0}, Name: {1}",
                    custKeyVal.Key,
                    custKeyVal.Value.Name);
            }
            Hashtable h = new Hashtable();
            h.Add("A","Praveen");
            foreach (DictionaryEntry de  in h)
            {
                string s=de.Key.ToString();
                string name = de.Value.ToString();
            }
           
            Console.ReadKey();
        }
    }
}
