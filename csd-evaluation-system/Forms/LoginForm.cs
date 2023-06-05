using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using csd_evaluation_system.Models;
using csd_evaluation_system.Models.Exceptions;

namespace csd_evaluation_system.Forms
{
    public partial class LoginForm : BaseForm
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            var users = User.All();
            this.guna2TextBoxUsername.AutoCompleteCustomSource.AddRange(
                users.Select(user => user.username).ToArray<string>()
            );
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (!validate()) return;
            try
            {
                var user = User.Find(guna2TextBoxUsername.Text);
                if (!user.password.Equals(guna2TextBoxPassword.Text))
                {
                    alert("Login Failed", "Wrong password!");
                    return;
                }
            }
            catch (NotFoundException ex) { alert("Login Failed", "Wrong username"); }
            catch (Exception ex) { alert("An error occured", ex.Message); }
        }


        private bool validate()
        {
            return true;
        }
    }
}
