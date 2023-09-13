namespace FileBrowser
{
    public partial class Form1 : Form
    {
        private Form2 form2;
        public Form1()
        {
            InitializeComponent();
        }

        private void PopulateTreeView()
        {
            TreeNode root = new TreeNode("Компьютер");
            root.Tag = @"C:\";
            treeView1.Nodes.Add(root);
            foreach (string s in Directory.GetLogicalDrives())
            {
                TreeNode item = new TreeNode(s);
                item.Tag = s;
                root.Nodes.Add(item);
            }
        }

        private void treeView1_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            e.Node.Nodes.Clear();

            if (e.Node.Tag.ToString() == @"C:\") 
            {
                foreach (string s in Directory.GetLogicalDrives()) 
                {
                    TreeNode item = new TreeNode(s);
                    item.Tag = s;
                    e.Node.Nodes.Add(item);
                }
            }
            else 
            {
                string[] dirs = Directory.GetDirectories(e.Node.Tag.ToString());

                foreach (string dir in dirs)
                {
                    TreeNode node = new TreeNode(Path.GetFileName(dir));
                    node.Tag = dir;
                    e.Node.Nodes.Add(node);
                }
            }
        }


        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (form2 == null || form2.IsDisposed)
            {
                form2 = new Form2();
            }

            form2.listView1.Items.Clear();

            string path = e.Node.Tag.ToString();

            string[] dirs = Directory.GetDirectories(path);
            string[] files = Directory.GetFiles(path);

            foreach (string dir in dirs)
            {
                ListViewItem item = new ListViewItem(Path.GetFileName(dir), 0);
                form2.listView1.Items.Add(item);
            }
            form2.Show();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            PopulateTreeView();
        }
    }
}

