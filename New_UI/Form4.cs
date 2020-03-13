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
    public partial class frmNewTrans : Form
    {
        static MongoClient client = new MongoClient();
        static IMongoDatabase db = client.GetDatabase("chairDB");
        static IMongoCollection<dbclass> collection = db.GetCollection<dbclass>("posDB");
        public void Read()
        {
            List<dbclass> list = collection.AsQueryable().ToList<dbclass>();
            dataGridView1.DataSource = list;
        }
        public frmNewTrans()
        {
            InitializeComponent();
            Read();
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
