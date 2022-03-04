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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            LoadData();
        }

        private void LoadData()
        {
            using(MagazinDbContext mdb = new MagazinDbContext())
            {
                var res = from p in mdb.Produse
                          select new
                          {
                              p.Id,
                              p.Denumire,
                              p.Cantitate
                          };
                dgvProduse.DataSource = res.ToList();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void adaugareProduseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddProdus addForm = new AddProdus();

            if(addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using(MagazinDbContext mdb = new MagazinDbContext())
            {
                var res = from p in mdb.Produse
                          where p.Denumire.Contains(this.txtSearch.Text)
                          select new
                          {
                              p.Id,
                              p.Denumire,
                              p.Cantitate
                          };
                dgvProduse.DataSource=res.ToList();
            }
        }

        private void dgvProduse_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Produs p = new Produs();


            p.Id = int.Parse(dgvProduse.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            p.Denumire = dgvProduse.Rows[e.RowIndex].Cells["Denumire"].Value.ToString();
            p.Cantitate=int.Parse(dgvProduse.Rows[e.RowIndex].Cells["Cantitate"].Value.ToString());

            SaleProdus saleForm = new SaleProdus(p);

            if (saleForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void adaugareUtilizatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void adaugareToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddUser addForm = new AddUser();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void stergereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteUser addForm = new DeleteUser();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void logInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LogIn addForm = new LogIn();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void istoricVanzariToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VizualizareIstoric addForm = new VizualizareIstoric();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
