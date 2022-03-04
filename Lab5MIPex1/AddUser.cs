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
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(txtNume.Text) || String.IsNullOrEmpty(txtPrenume.Text) || String.IsNullOrEmpty(txtUser.Text) || String.IsNullOrEmpty(txtParola.Text))
                MessageBox.Show("Nu ati completat toate rubricile", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                using (UtilizatorDbContext mdb = new UtilizatorDbContext())
                {
                    Utilizator u = new Utilizator();
                    u.Nume = this.txtNume.Text;
                    u.Prenume = this.txtPrenume.Text;
                    u.Username = this.txtUser.Text;
                    u.Parola = this.txtParola.Text;


                    mdb.Utilizatori.Add(u);
                    mdb.SaveChanges();
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult=DialogResult.Cancel;
        }


        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked == true)
            {
                txtParola.UseSystemPasswordChar = false;
            }
            else
            {
                txtParola.UseSystemPasswordChar = true;
            }
        }
    }
}
