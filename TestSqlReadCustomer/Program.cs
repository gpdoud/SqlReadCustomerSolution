using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlReadCustomer;

namespace TestSqlReadCustomer {
	class Program {
		static void Main(string[] args) {

			CustomerController cust = new CustomerController();

			Customer c = new Customer();

			c.Id = 9;
			c.Name = "SuperMaxXXX";
			c.City = "Mason";
			c.State = "OH";
			c.IsCorpAcct = true;
			c.CreditLimit = 1000000;
			c.Active = true;

			if(!cust.Update(c)) {
				Console.WriteLine("update failed!");
			}

			List<Customer> customers = cust.List();
			foreach (Customer customer in customers) {
				Console.WriteLine($"{customer.Id} | {customer.Name} " 
					+ $"| {customer.City} | {customer.State} | {customer.CreditLimit}"); 
			}

			Console.ReadKey();
		}
	}
}
