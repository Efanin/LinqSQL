using System.Data.SqlClient;
using System.Linq;

namespace WinFormsApp19
{
    public partial class Form1 : Form
    {
        private List<Details> details;
        private SqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            details = new();
            connection = new("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\user\\source\\repos\\WinFormsApp19\\WinFormsApp19\\Database1.mdf;Integrated Security=True");
            connection.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlCommand command = new(
                "select * from Details",
                connection
                );
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()){
                details.Add(
                    new Details(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["detail"]),
                        Convert.ToInt32(reader["price"])
                        )
                    );
            }
            reader.Close();

            var command1 =  from k in details
                            where k.price == (from t in details
                                                select t).Max(t => t.price)
                            select k;
                            ;
            /*
             * select detail
             * from detail
             * where detail.id < 10
             */
            
            details = command1.ToList();

            string text = "";
            foreach(var item in details )
                listView1.Items.Add($"{item.id} {item.detail} {item.price}\n");
            listView1.Items.Clear();
            listView1.Items.Add((from t in details
                                 select t).Sum(t => t.price).ToString());
        }
    }
    public class Details(int id, string detail, int price)
    {
        public int id { get; set; } = id;
        public string detail { get; set; } = detail;
        public int price { get; set; } = price;
    }
}
