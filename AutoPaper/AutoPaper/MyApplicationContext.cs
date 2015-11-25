using System;
using System.Windows.Forms;

namespace AutoPaper
{
    internal class MyApplicationContext : ApplicationContext
    {
        private System.ComponentModel.IContainer container;
        private ContextMenuStrip contextMenu;
        private ToolStripMenuItem toggleMenu;
        private ToolStripMenuItem saveMenu;
        private ToolStripMenuItem changeMenu;
        private ToolStripMenuItem exitMenuItem;
        private ToolStripMenuItem configMenu;
        private NotifyIcon notifyIcon;

        private static System.Timers.Timer changeTimer;

        public MyApplicationContext()
        {
            container = new System.ComponentModel.Container();

            notifyIcon = new NotifyIcon(container);
            notifyIcon.Icon = new System.Drawing.Icon("autopaper.ico");
            notifyIcon.Text = $"{Conf.name} v{Conf.version}";
            notifyIcon.Visible = true;

            contextMenu = new ContextMenuStrip();
            notifyIcon.ContextMenuStrip = contextMenu;

            toggleMenu = new ToolStripMenuItem();
            toggleMenu.Text = "Stop";
            toggleMenu.Click += toggleMenu_Click;
            contextMenu.Items.Add(toggleMenu);

            contextMenu.Items.Add(new ToolStripSeparator());
            
            saveMenu = new ToolStripMenuItem();
            saveMenu.Text = "Save";
            saveMenu.Click += saveMenu_Click;
            contextMenu.Items.Add(saveMenu);

            changeMenu = new ToolStripMenuItem();
            changeMenu.Text = "Change";
            changeMenu.Click += changeMenu_Click;
            contextMenu.Items.Add(changeMenu);

            contextMenu.Items.Add(new ToolStripSeparator());

            configMenu = new ToolStripMenuItem();
            configMenu.Text = "Config";
            configMenu.Click += configMenu_Click;
            contextMenu.Items.Add(configMenu);

            contextMenu.Items.Add(new ToolStripSeparator());

            exitMenuItem = new ToolStripMenuItem();
            exitMenuItem.Text = "Exit";
            exitMenuItem.Click += exitMenu_Click;
            contextMenu.Items.Add(exitMenuItem);

            InitializeWorker();
        }

        public static void InitializeWorker()
        {
            InitializeWorker((long)Conf.GetConf("delay"));
        }

        public static void InitializeWorker(long delay)
        {
            if (changeTimer != null)
            {
                changeTimer.Enabled = false;
                changeTimer = null;
            }
            Console.WriteLine($"Starting timer: {delay}");
            changeTimer = new System.Timers.Timer(delay);
            changeTimer.Elapsed += Wallpaper.ChangeWallpaper;
            changeTimer.AutoReset = false;
            changeTimer.Enabled = true;
        }

        private void toggleMenu_Click(object sender, EventArgs e)
        {
            if (changeTimer == null)
            {
                toggleMenu.Text = "Stop";
                InitializeWorker();
            }
            else
            {
                toggleMenu.Text = "Start";
                changeTimer.Enabled = false;
                changeTimer = null;
            }
        }

        private void saveMenu_Click(object sender, EventArgs e)
        {
            Wallpaper.SaveTo();
        }

        private void changeMenu_Click(object sender, EventArgs e)
        {
            Wallpaper.ChangeWallpaper();
        }

        private void configMenu_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.Show();
        }

        private void exitMenu_Click(object sender, EventArgs e)
        {
            base.ExitThreadCore();
        }
    }
}