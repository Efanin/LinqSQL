using System.Data.SqlClient;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsApp19
{
    public partial class Form1 : Form
    {
        private List<Details> details;
        private List<Customers> customers;
        private List<Sellers> sellers;
        private List<Sales> sales;
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            details = new();
            customers = new();
            sellers = new();
            sales = new();
            connection = new("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\WinFormsApp19\\WinFormsApp19\\Database1.mdf;Integrated Security=True");
            connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            readerDetails();
            readerCustomers();
            readerSellers();
            readerSales();

            var command1 = from s in sales
                          join c in customers
                          on s.customer equals c.id
                          join d in details
                          on s.detail equals d.id
                          join se in sellers
                          on s.seller equals se.id
                          select s
                          ;
            sales = command1.ToList();
            var command2 = from s in sales
                           join c in customers
                           on s.customer equals c.id
                           join d in details
                           on s.detail equals d.id
                           join se in sellers
                           on s.seller equals se.id
                           select c
                         ;
            customers = command2.ToList();
            var command3 = from s in sales
                           join c in customers
                           on s.customer equals c.id
                           join d in details
                           on s.detail equals d.id
                           join se in sellers
                           on s.seller equals se.id
                           select d
                         ;
            details = command3.ToList();
            var command4 = from s in sales
                           join c in customers
                           on s.customer equals c.id
                           join d in details
                           on s.detail equals d.id
                           join se in sellers
                           on s.seller equals se.id
                           select se
                         ;
            sellers = command4.ToList();
            string text = "";
            for(int i = 0; i < sales.Count; i++)
                listView1.Items.Add($"{sales[i].id} " +
                                    $"{customers[i].customer} " +
                                    $"{details[i].detail} " +
                                    $"{details[i].price} " +
                                    $"{sales[i].count} " +
                                    $"{sales[i].date} " +
                                    $"{sellers[i].seller}\n");
            
        }
        private void readerDetails()
        {
            SqlCommand command = new(
                "select * from Details",
                connection
                );
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                details.Add(
                    new Details(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["detail"]),
                        Convert.ToInt32(reader["price"])
                    )
                );
            }
            reader.Close();
        }
        private void readerCustomers()
        {
            SqlCommand command = new(
                "select * from Customers",
                connection
                );
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                customers.Add(
                    new Customers(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["customer"])
                    )
                );
            }
            reader.Close();
        }
        private void readerSellers()
        {
            SqlCommand command = new(
                "select * from Sellers",
                connection
                );
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sellers.Add(
                    new Sellers(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["seller"]),
                        Convert.ToInt32(reader["bonus"])
                    )
                );
            }
            reader.Close();
        }
        private void readerSales()
        {
            SqlCommand command = new(
                "select * from Sales",
                connection
                );
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                sales.Add(
                    new Sales(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToInt32(reader["customer"]),
                        Convert.ToInt32(reader["detail"]),
                        Convert.ToInt32(reader["count"]),
                        Convert.ToString(reader["date"]),
                        Convert.ToInt32(reader["seller"])
                    )
                );
            }
            reader.Close();
        }
    }
    public class Details(int id, string detail, int price)
    {
        public int id { get; set; } = id;
        public string detail { get; set; } = detail;
        public int price { get; set; } = price;
    }
    public class Customers(int id, string customer)
    {
        public int id { get; set; } = id;
        public string customer { get; set; } = customer;
    }
    public class Sellers(int id, string seller, int bonus)
    {
        public int id { get; set; } = id;
        public string seller { get; set; } = seller;
        public int bonus { get; set; } = bonus;
    }
    public class Sales(int id, int customer,int detail,int count, string date, int seller)
    {
        public int id { get; set; } = id;
        public int customer { get; set; } = customer;
        public int detail { get; set; } = detail;
        public int count { get; set; } = count;
        public string date { get; set; } = date;
        public int seller { get; set; } = seller;
    }
     
}
