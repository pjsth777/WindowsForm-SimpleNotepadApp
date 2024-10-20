using System;
using System.IO;
using System.Windows.Forms;

namespace SimpleNotepadApp
{
    public partial class Form1 : Form
    {
        string currentFilePath = "";

        // -------------------------------------------------------------------------

        public Form1()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------------------------

        private void InitializeComponent()
        {
            // -------------------------------------------------------------------------

            this.menuStrip1 = new MenuStrip();
            this.fileToolStripMenuItem = new ToolStripMenuItem();
            this.newToolStripMenuItem = new ToolStripMenuItem();
            this.openToolStripMenuItem = new ToolStripMenuItem();
            this.saveToolStripMenuItem = new ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new ToolStripMenuItem();
            this.exitToolStripMenuItem = new ToolStripMenuItem();
            this.editToolStripMenuItem = new ToolStripMenuItem();
            this.cutToolStripMenuItem = new ToolStripMenuItem();
            this.copyToolStripMenuItem = new ToolStripMenuItem();
            this.pasteToolStripMenuItem = new ToolStripMenuItem();
            this.textBox = new TextBox();

            // -------------------------------------------------------------------------

            this.SuspendLayout();

            // -------------------------------------------------------------------------

            //
            // menuStrip1
            //
            this.menuStrip1.Items.AddRange(new ToolStripItem[]
            {
                this.fileToolStripMenuItem,
                this.editToolStripMenuItem
            });
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";

            // -------------------------------------------------------------------------

            //
            // fileToolStripMenuItem
            //
            this.fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.newToolStripMenuItem,
                this.openToolStripMenuItem,
                this.saveToolStripMenuItem,
                this.saveAsToolStripMenuItem,
                this.exitToolStripMenuItem
            });
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";

            // -------------------------------------------------------------------------

            // New
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new EventHandler(this.NewFile);

            // -------------------------------------------------------------------------

            // Open 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new EventHandler(this.OpenFile);

            // -------------------------------------------------------------------------

            // Save
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new EventHandler(this.SaveFile);

            // -------------------------------------------------------------------------

            // Save As
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new EventHandler(this.SaveFileAs);

            // -------------------------------------------------------------------------

            // Exit
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new EventHandler(this.ExitApp);

            // -------------------------------------------------------------------------

            //
            // editToolStripMenuItem
            //
            this.editToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[]
            {
                this.cutToolStripMenuItem,
                this.copyToolStripMenuItem,
                this.pasteToolStripMenuItem
            });
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";

            // -------------------------------------------------------------------------

            // Cut
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new EventHandler(this.CutText);

            // -------------------------------------------------------------------------

            // Copy
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new EventHandler(this.CopyText);

            // -------------------------------------------------------------------------

            // Paste 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new EventHandler(this.PasteText);

            // -------------------------------------------------------------------------

            // 
            // textBox
            //
            this.textBox.Dock = DockStyle.Fill;
            this.textBox.Multiline = true;
            this.textBox.Location = new System.Drawing.Point(0, 24);
            this.textBox.Size = new System.Drawing.Size(800, 426);
            this.textBox.TabIndex = 1;

            // -------------------------------------------------------------------------

            //
            // Form1
            //
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBox);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Simple Notepad";

            // -------------------------------------------------------------------------

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // -------------------------------------------------------------------------

        // File Menu Actions
        private void NewFile(object sender, EventArgs e)
        {
            textBox.Clear();
            currentFilePath = "";
        }

        // -------------------------------------------------------------------------

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = openFileDialog.FileName;
                textBox.Text = File.ReadAllText(currentFilePath);
            }
        }

        // -------------------------------------------------------------------------

        private void SaveFile(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                SaveFileAs(sender, e);
            }
            else
            {
                File.WriteAllText(currentFilePath, textBox.Text);
            }
        }

        // -------------------------------------------------------------------------

        private void SaveFileAs(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                currentFilePath = saveFileDialog.FileName;
                File.WriteAllText(currentFilePath, textBox.Text);
            }
        }

        // -------------------------------------------------------------------------

        private void ExitApp(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // -------------------------------------------------------------------------

        private void CutText(object sender, EventArgs e)
        {
            textBox.Cut();
        }

        // -------------------------------------------------------------------------

        private void CopyText(object sender, EventArgs e)
        {
            textBox.Copy();
        }

        // -------------------------------------------------------------------------

        private void PasteText(object sender, EventArgs e)
        {
            textBox.Paste();
        }

        // -------------------------------------------------------------------------

        // Components
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem saveAsToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem cutToolStripMenuItem;
        private ToolStripMenuItem copyToolStripMenuItem;
        private ToolStripMenuItem pasteToolStripMenuItem;
        private TextBox textBox;

        // -------------------------------------------------------------------------

    }
}