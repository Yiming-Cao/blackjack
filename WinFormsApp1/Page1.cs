using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Page1 : UserControl
    {
        public Page1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 获取当前的父容器（假设它是 Form1）
            Form1 mainForm = this.FindForm() as Form1;

            if (mainForm != null)
            {
                // 创建 Page2 并替换当前控件
                Page2 page2 = new Page2();
                mainForm.Controls.Clear(); // 清空当前 Form1 里的控件
                mainForm.Controls.Add(page2); // 加载 Page2
                page2.Dock = DockStyle.Fill; // 让 Page2 充满整个窗口
            }
        }
    }
}
