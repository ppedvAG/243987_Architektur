namespace PizzaAPI_Client
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var client = new swaggerClient("https://localhost:7291", new HttpClient());

            dataGridView1.DataSource = (await client.PizzaAllAsync()).ToList();
        }
    }
}
