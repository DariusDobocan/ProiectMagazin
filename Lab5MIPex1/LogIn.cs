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
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPsw.Text == "")
                MessageBox.Show("Nu ati introdus Utilizator sau Parola", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);

            using (UtilizatorDbContext mdb = new UtilizatorDbContext())
            {
                var res = mdb.Utilizatori.SingleOrDefault(u => u.Username == txtUser.Text
                     && u.Parola == txtPsw.Text);
                if (res != null)
                {
                    UserShopping form = new UserShopping(res);
                    form.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Utilizator sau Parola gresita", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
