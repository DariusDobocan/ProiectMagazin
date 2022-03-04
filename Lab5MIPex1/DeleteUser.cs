using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab5MIPex1
{
    public partial class DeleteUser : Form
    {
        public DeleteUser()
        {
            InitializeComponent();

            LoadData();
        }
        private void LoadData()
        {
            using (UtilizatorDbContext mdb = new UtilizatorDbContext())
            {
                var res = from u in mdb.Utilizatori
                          select new
                          {
                              u.Id,
                              u.Username
                          };
                dataGridView1.DataSource = res.ToList();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Utilizator u = new Utilizator();


            u.Id = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            u.Username = dataGridView1.Rows[e.RowIndex].Cells["Username"].Value.ToString();

            using (UtilizatorDbContext mdb = new UtilizatorDbContext())
            {
                var res = mdb.Utilizatori.SingleOrDefault(p => p.Id == u.Id);

                if(res != null)
                {
                    mdb.Utilizatori.Remove(res);
                    mdb.SaveChanges();
                    LoadData();
                }
            }
        }
    }
}
