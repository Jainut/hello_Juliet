using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace crudB
{
    public partial class Form3 : Form
    {
        Form1 form1;
        HttpClient client = new HttpClient();
        public Form3(Form1 f1)
        {

            InitializeComponent();
            form1 = f1;
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            form1.Show();
            this.Close();
        }

        private async Task<List<User>> GetUser()
        {
            var response = await client.GetAsync($"{Config.URL}/listar");
            string json = await response.Content.ReadAsStringAsync();
            var users = JsonSerializer.Deserialize<List<User>>(json);
            return users;      
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var users = await GetUser();

            dataGridView1.DataSource = users;
        }
    }
}
