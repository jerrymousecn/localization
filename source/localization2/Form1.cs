using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace localization2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void SetResourceCulture()
        {
            // Set the form title text  
            this.Text = ResourceCulture.GetString("Form1");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set the default language  
            //ResourceCulture.SetCurrentCulture("en-US");
            ResourceCulture.SetCurrentCulture("zh-CN");

            this.SetResourceCulture(); 
        }
    }
}
