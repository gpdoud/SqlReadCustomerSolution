using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlReadCustomer {

	public class Customer {

		public int Id { get; set; }
		public string Name { get; set; }
		public string City { get; set; }
		public string State { get; set; }
		public bool IsCorpAcct { get; set; }
		public int CreditLimit { get; set; }
		public bool Active { get; set; }

	}
}
