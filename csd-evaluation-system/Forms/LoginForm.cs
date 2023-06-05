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
using csd_evaluation_system.Forms.AdminForms;

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

            this.Hide();
            new AdminForm(users.First(), this).Show();
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

                this.Hide();
                new AdminForm(user, this).Show();
            }
            catch (NotFoundException ex) { 
                alert("Login Failed", "Wrong username");
                Console.WriteLine(ex.ToString());
            }
            catch (Exception ex) { 
                alert("An error occured", ex.Message);
                Console.WriteLine(ex.ToString());
            }
        }


        private bool validate()
        {
            return true;
        }
    }
}
