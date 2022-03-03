using AutoUpdaterDotNET;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using System.Runtime.InteropServices;

namespace BlazorWinForms1
{
    public partial class Form1 : Form
    {
        BlazorWebView blazor;
        bool MouseDown = false;
        Point startPoint = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;

        }
        private void AutoUpdater_ApplicationExitEvent()
        {
            Text = @"Closing application...";
            Thread.Sleep(5000);
            Application.Exit();
        }
        private const int cGrip = 16;
        private const int cCaption =  32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {  // Trap WM_NCHITTEST
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;  // HTCAPTION
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17; // HTBOTTOMRIGHT
                    return;
                }
            }
            base.WndProc(ref m);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rc = new Rectangle(this.ClientSize.Width - cGrip, this.ClientSize.Height - cGrip, cGrip, cGrip);
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor, rc);
            rc = new Rectangle(0, 0, this.ClientSize.Width, cCaption);
            e.Graphics.FillRectangle(Brushes.DarkBlue, rc);
        }
        //  public EventHandler OnPanelClick { get; set; }= new EventHandler(object, new EventArgs());
        public delegate void MyEventHandler(object source, EventArgs e);
        public event MyEventHandler OnMaximum;
        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            OnMaximum?.Invoke(this, e);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AutoUpdater.Start("https://raw.githubusercontent.com/Hamoo17/BlazorWinForms1/main/BlazorWinForms1/UpdateInfo.xml");
            AutoUpdater.InstallationPath = Application.StartupPath;
            blazor = new BlazorWebView()
            {
                Dock = DockStyle.Fill,
                HostPage = "wwwroot/index.html",
                Services = Startup.Services,
            };
            blazor.RootComponents.Add<App>("#app");

            Controls.Add(blazor);
            blazor.BringToFront();
        }
        public void Close()
        {
            System.Environment.Exit(1);
            Application.Exit();
        }
        //private void panel1_MouseDown(object sender, MouseEventArgs e)
        //{
        //    MouseDown = true;
        //    startPoint = new Point(e.X, e.Y);
        //}

        //private void panel1_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (MouseDown)
        //    {
        //        //int x = Cursor.Position.X - panel1.Size.Width /2;
        //        //int y = Cursor.Position.Y - panel1.Size.Height /2;
        //        //this.SetDesktopLocation(x, y);
        //        Point p = PointToScreen(e.Location);
        //        Location = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
        //    }

        //}

        //private void panel1_MouseUp(object sender, MouseEventArgs e)
        //{
        //    MouseDown = false;
        //}

        //private void panel1_DoubleClick(object sender, EventArgs e)
        //{
        //    if (WindowState == FormWindowState.Normal)
        //    {
        //        WindowState = FormWindowState.Maximized;
        //    }
        //    else
        //    {
        //        WindowState = FormWindowState.Normal;
                
        //    }
        //}
    }
}