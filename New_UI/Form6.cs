using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace New_UI
{
    public partial class frmMngInv : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("chairDB");
        static IMongoCollection<dbclass> collection = db.GetCollection<dbclass>("posDB");
        public void Read()
        {
            List<dbclass> list = collection.AsQueryable().ToList<dbclass>();
            dataGridView1.DataSource = list;
            label6.Text = (dataGridView1.Rows[0].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
        }
        public frmMngInv()
        {
            InitializeComponent();
            Read();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            label6.Text = (dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            dbclass s = new dbclass(int.Parse(textBox1.Text), textBox2.Text, Double.Parse(textBox3.Text), int.Parse(textBox4.Text));
            collection.InsertOne(s);
            Read();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            var updateDef = Builders<dbclass>.Update.Set("prodID", int.Parse(textBox1.Text)).Set("prodName", textBox2.Text).Set("prodVal", Double.Parse(textBox3.Text)).Set("prodStock", int.Parse(textBox4.Text));
            collection.UpdateOne(s => s.Id == ObjectId.Parse(label6.Text), updateDef);
            Read();

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(label6.Text));
            Read();
        }
    }
}
