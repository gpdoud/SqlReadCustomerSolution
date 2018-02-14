using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlReadCustomer {

	public class SqlCustomer {

		public List<Customer> List() {
			string connStr = @"server=DSI-WORKSTATION\SQLEXPRESS;database=SqlTutorial;Trusted_connection=true";
			SqlConnection conn = new SqlConnection(connStr);
			conn.Open();
			if(conn.State != System.Data.ConnectionState.Open) {
				Console.WriteLine("The connection didn't open.");
				return null;
			}
			string sql = "select * from customer";
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			if(!reader.HasRows) {
				Console.WriteLine("Result has no row.");
				return null;
			}
			List<Customer> customers = new List<Customer>();
			while(reader.Read()) {
				int id = reader.GetInt32(reader.GetOrdinal("Id"));
				string name = reader.GetString(reader.GetOrdinal("Name"));
				string city = reader.GetString(reader.GetOrdinal("City"));
				string state = reader.GetString(reader.GetOrdinal("State"));
				bool isCorpAcct = reader.GetBoolean(reader.GetOrdinal("IsCorpAcct"));
				int creditLimit = reader.GetInt32(reader.GetOrdinal("CreditLimit"));
				bool active = reader.GetBoolean(reader.GetOrdinal("Active"));

				Customer customer = new Customer();
				customer.Id = id;
				customer.Name = name;
				customer.City = city;
				customer.State = state;
				customer.IsCorpAcct = isCorpAcct;
				customer.CreditLimit = creditLimit;
				customer.Active = active;

				customers.Add(customer);
			}

			conn.Close();
			return customers;
		}
	}
}
