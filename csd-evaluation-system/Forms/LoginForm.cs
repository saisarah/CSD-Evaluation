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
            userBindingSource.Add(new User() { username = "Lenard" });
            userBindingSource.Add(new User() { username = "Sarah" });
            userBindingSource.Add(new User() { username = "Grace" });
        }
    }
}
