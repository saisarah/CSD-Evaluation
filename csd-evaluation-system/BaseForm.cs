using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csd_evaluation_system
{
    public class BaseForm : Form
    {
        public BaseForm()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Font = new System.Drawing.Font("Segoe UI", 16);
        }
    }
}
