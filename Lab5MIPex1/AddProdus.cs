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
    public partial class AddProdus : Form
    {
        public AddProdus()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtDenumire.Text) || String.IsNullOrEmpty(txtDescriere.Text) || String.IsNullOrEmpty(maskedTextBox1.Text))
                MessageBox.Show("Nu ati completat toate rubricile", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using (MagazinDbContext mdb = new MagazinDbContext())
                {
                    Produs p = new Produs();
                    p.Denumire = this.txtDenumire.Text;
                    p.Descriere = this.txtDescriere.Text;
                    p.DataExpirare = this.dtpExpirare.Value;
                    p.Cantitate = int.Parse(this.maskedTextBox1.Text);

                    p.DataIntrare = DateTime.Now;

                    mdb.Produse.Add(p);
                    mdb.SaveChanges();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
