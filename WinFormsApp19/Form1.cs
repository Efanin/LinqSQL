using System.Data.SqlClient;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

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
            while (reader.Read()) {
                details.Add(
                    new Details(
                        Convert.ToInt32(reader["id"]),
                        Convert.ToString(reader["detail"]),
                        Convert.ToInt32(reader["price"])
                )
                    );
            }
            reader.Close();
            
            details = details.Select(k => new Details(
                k.id,
                k.detail = k.detail + (new string[2] { " no", " yes" })[new Random().Next(2)],
                k.price
                )).ToList();
            string text = "";
            foreach(var item in details )
                listView1.Items.Add($"{item.id} {item.detail} {item.price}\n");
        }

    }
    public class Details(int id, string detail, int price)
    {
        public int id { get; set; } = id;
        public string detail { get; set; } = detail;
        public int price { get; set; } = price;
    }
}
