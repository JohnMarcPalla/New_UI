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
    
    public partial class frmMngEmp : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("chairDB");
        static IMongoCollection<userDB> collection = db.GetCollection<userDB>("usersID");
        public void Read()
        {
            List<userDB> list = collection.AsQueryable().ToList<userDB>();
            dataGridView1.DataSource = list;
            dataGridView1.Columns["Id"].Visible = false;
            label7.Text = (dataGridView1.Rows[0].Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
        }
        public frmMngEmp()
        {
            InitializeComponent();
            Read();
        }
        #region click events
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            userDB s = new userDB(textBox1.Text, textBox2.Text,textBox3.Text, Double.Parse(textBox4.Text));
            collection.InsertOne(s);
            Read();
        }
        private void btnRemUser_Click(object sender, EventArgs e)
        {
            collection.DeleteOne(s => s.Id == ObjectId.Parse(label7.Text));
            Read();
        }
        private void btnUpdUser_Click(object sender, EventArgs e)
        {
            var updateDef = Builders<userDB>.Update.Set("Username", textBox1.Text).Set("Password", textBox2.Text).Set("EmployeeName", textBox3.Text).Set("EmployeeSalary", Double.Parse(textBox4.Text));
            collection.UpdateOne(s => s.Id == ObjectId.Parse(label6.Text), updateDef);
            Read();
        }
        #endregion
    }
}
