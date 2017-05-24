using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
namespace MediaPlayerMD
{
    public class Form1 : Form
    {
        private IContainer components = null;

        private ClassMenuTrip menuStrip1;
        private ClassSplitContainer splitContainer1;
        private IWMPPlaylist playlist;
        Stream myStream = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(Form1));
            splitContainer1 = new ClassSplitContainer(playlist);
            menuStrip1 = new ClassMenuTrip(splitContainer1.getList().getListView(), splitContainer1.getMedia().getMediaPlayer(), playlist, myStream);

            ((ISupportInitialize)(this.splitContainer1.getSplitContainer())).BeginInit();
            ((ISupportInitialize)(this.splitContainer1.getMedia().getMediaPlayer())).BeginInit();
            this.SuspendLayout();
            #region ClassMenuStrip
            this.menuStrip1.bt_Exit.Click += new System.EventHandler(this.bt_Exit_Click);
            #endregion

            #region MainForm
            // Form1

            this.Controls.Add(this.splitContainer1.getSplitContainer());
            this.Controls.Add(menuStrip1.getMenuStrip());

            this.Icon = new Icon("MusicalNotes.ico");
            this.MainMenuStrip = this.menuStrip1.getMenuStrip();
            this.Name = "Form1";
            this.Text = "Media Player MD";
            this.WindowState = FormWindowState.Maximized;
            #endregion
            ((ISupportInitialize)(this.splitContainer1.getSplitContainer())).EndInit();
            ((ISupportInitialize)(this.splitContainer1.getMedia().getMediaPlayer())).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
            //make new playlist;
            playlist = splitContainer1.getMedia().getMediaPlayer().playlistCollection.newPlaylist("myplaylist");
        }

        #region MenuStripItem Event
        private void bt_Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

    }
}
