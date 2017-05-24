using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using AxWMPLib;
using WMPLib;
namespace MediaPlayerMD
{
    class ClassMenuTrip
    {
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fILEToolStripMenuItem;
        public ToolStripMenuItem bt_Open;
        public ToolStripMenuItem bt_Add;
        public ToolStripMenuItem bt_Exit;
        private ToolStripMenuItem hELPToolStripMenuItem;
        private ToolStripMenuItem bt_ViewHelp;
        private ToolStripMenuItem bt_About;

        private OpenFileDialog openFileDialog1;
        private ListView listView1;
        private AxWindowsMediaPlayer mediaPlayer;
        private IWMPPlaylist playlist;
        private Stream myStream;
        private IWMPMedia media;
        public ClassMenuTrip(ListView listView1, AxWindowsMediaPlayer mediaPlayer, IWMPPlaylist playlist, Stream myStream)
        {
            this.listView1 = listView1;
            this.mediaPlayer = mediaPlayer;
            this.playlist = playlist;
            this.myStream = myStream;

            this.menuStrip1 = new MenuStrip();
            this.fILEToolStripMenuItem = new ToolStripMenuItem();
            this.hELPToolStripMenuItem = new ToolStripMenuItem();
            this.bt_ViewHelp = new ToolStripMenuItem();
            this.bt_About = new ToolStripMenuItem();
            this.bt_Open = new ToolStripMenuItem();
            this.bt_Add = new ToolStripMenuItem();
            this.bt_Exit = new ToolStripMenuItem();
            //
            // openFileDialog1
            // 
            this.openFileDialog1 = new OpenFileDialog();
            this.openFileDialog1.Multiselect = true;

            this.menuStrip1.Items.AddRange(new ToolStripItem[] {
            this.fILEToolStripMenuItem,
            this.hELPToolStripMenuItem});
            this.menuStrip1.Location = new Point(0, 0);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            // 
            // fILEToolStripMenuItem
            // 
            this.fILEToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.bt_Open,
            this.bt_Add,
            this.bt_Exit});

            this.fILEToolStripMenuItem.Text = "FILE";

            this.hELPToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] {
            this.bt_ViewHelp,
            this.bt_About});

            this.hELPToolStripMenuItem.Text = "HELP";

            this.bt_ViewHelp.Text = "View Help";
            this.bt_ViewHelp.Click += new System.EventHandler(this.bt_ViewHelp_Click);

            this.bt_About.Text = "About";
            this.bt_About.Click += new System.EventHandler(this.bt_About_Click);

            this.bt_Open.Text = "Open";
            this.bt_Open.Click += new System.EventHandler(this.bt_Open_Click);

            this.bt_Add.Text = "Add Playlist";
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);

            this.bt_Exit.Text = "Exit";

        }

        

        private void bt_ViewHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("Dang Nhu Thuy\nSDT: 0987040854\nMail: 20144373@student.hust.edu.vn"));
        }

        private void bt_About_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Format("MediaPlayerMD Version 1.0\nDang Nhu Thuy - 20144373"));
        }
        private void bt_Open_Click(object sender, EventArgs e)
        {

            this.openFileDialog1.Filter = "MP3 Audio File (*.mp3)|*.mp3| Windows Media File (*.wma)|*.wma|WAV Audio File  (*.wav)|*.wav|All FILES (*.*)|*.*";

            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                listView1.Items.Clear();
                try
                {
                    if ((myStream = this.openFileDialog1.OpenFile()) != null)
                    {
                        //sau khi het mot bai se chuyen den bai tiep theo
                        using (myStream)
                        {
                            string[] fileNameAndPath = this.openFileDialog1.FileNames;
                            string[] filename = this.openFileDialog1.SafeFileNames;

                            for (int i = 0; i < this.openFileDialog1.SafeFileNames.Count(); i++)
                            {
                                string[] TitleAndLocation = new string[2];
                                TitleAndLocation[0] = filename[i];
                                TitleAndLocation[1] = fileNameAndPath[i];
                                ListViewItem lvi = new ListViewItem(TitleAndLocation);
                                listView1.Items.Add(lvi);
                            }
                        }
                    }
                    playlist = mediaPlayer.playlistCollection.newPlaylist("myplaylist");
                    

                    for (int i = 0; i < listView1.Items.Count; i++)
                    {

                        int j = 1;
                        media = mediaPlayer.newMedia(listView1.Items[i].SubItems[j].Text);
                        playlist.appendItem(media);
                        j++;
                        mediaPlayer.currentPlaylist = playlist;
                        mediaPlayer.Ctlcontrols.play();

                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Error: could not open file(s) from disk");
                }
            }
        }
        private void bt_Add_Click(object sender, EventArgs e)
        {
            int numberofsongs = listView1.Items.Count;
            if (numberofsongs == 0)
                MessageBox.Show("Error: could not add file(s) from disk\nPlease Open file(s)");
            else
            {
                openFileDialog1.Filter = "MP3 Audio File (*.mp3)|*.mp3| Windows Media File (*.wma)|*.wma|WAV Audio File  (*.wav)|*.wav|All FILES (*.*)|*.*";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        if ((myStream = openFileDialog1.OpenFile()) != null)
                        {
                            //sau khi het mot bai se chuyen den bai tiep theo
                            using (myStream)
                            {
                                string[] fileNameAndPath = openFileDialog1.FileNames;
                                string[] filename = openFileDialog1.SafeFileNames;

                                for (int i = 0; i < openFileDialog1.SafeFileNames.Count(); i++)
                                {
                                    string[] TitleAndLocation = new string[2];
                                    TitleAndLocation[0] = filename[i];
                                    TitleAndLocation[1] = fileNameAndPath[i];
                                    ListViewItem lvi = new ListViewItem(TitleAndLocation);
                                    listView1.Items.Add(lvi);
                                }
                                for (int i = numberofsongs; i < listView1.Items.Count; i++)
                                {
                                    media = mediaPlayer.newMedia(listView1.Items[i].SubItems[1].Text);
                                    playlist.appendItem(media);
                                    mediaPlayer.currentPlaylist = playlist;
                                    mediaPlayer.Ctlcontrols.play();
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error: could not add file(s)");
                    }
                }
            }
        }

        public MenuStrip getMenuStrip()
        {
            return menuStrip1;
        }
        public OpenFileDialog getOpenFileDialog()
        {
            return openFileDialog1;
        }
    }
}

