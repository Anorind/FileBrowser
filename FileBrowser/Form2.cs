using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileBrowser
{

    public partial class Form2 : Form
    {
        private ContextMenuStrip? contextMenu;

        public Form2()
        {
            InitializeComponent();

            listView1.Dock = DockStyle.Fill;
            listView1.View = View.Details;
            listView1.Columns.Add("Им'я файла", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Дата зміни", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Тип", -2, HorizontalAlignment.Left);
            listView1.Columns.Add("Розмір", -2, HorizontalAlignment.Right);

            contextMenu = new ContextMenuStrip();
            contextMenu.Items.Add("Детально", null, (s, e) => listView1.View = View.Details);
            contextMenu.Items.Add("Список", null, (s, e) => listView1.View = View.List);
            contextMenu.Items.Add("Маленькі значки", null, (s, e) => listView1.View = View.SmallIcon);
            contextMenu.Items.Add("Великі значки", null, (s, e) => listView1.View = View.LargeIcon);

            listView1.ContextMenuStrip = contextMenu;
        }
        protected override void OnLoad(EventArgs e)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(@"C:\");
            foreach (var fileInfo in dirInfo.GetFiles())
            {
                ListViewItem item = new ListViewItem(new string[]
                {
            fileInfo.Name,
            fileInfo.LastWriteTime.ToString(),
            fileInfo.Extension,
            fileInfo.Length.ToString()
                });
                listView1.Items.Add(item);
            }
        }
    }
}
