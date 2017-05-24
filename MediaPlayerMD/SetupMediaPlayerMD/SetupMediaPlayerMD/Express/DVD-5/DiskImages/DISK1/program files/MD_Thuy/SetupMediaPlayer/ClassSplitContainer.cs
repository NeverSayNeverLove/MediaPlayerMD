using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WMPLib;
using System.Drawing;
namespace MediaPlayerMD
{
    class ClassSplitContainer
    {
        private SplitContainer splitContainer1;
        private ClassMedia mediaPlayer;
        private ClassListView listView1;
        private IWMPPlaylist playlist;
        public ClassSplitContainer(IWMPPlaylist playlist)
        {
            this.playlist = playlist;
            this.splitContainer1 = new SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            //
            // splitContainer1
            // 
            this.splitContainer1.Dock = DockStyle.Fill;
            this.splitContainer1.Location = new Point(0, 24);
            this.splitContainer1.Size = new Size(584, 337);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            //init component
            mediaPlayer = new ClassMedia();
            listView1 = new ClassListView();
            this.listView1.getListView().DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1.getListView());
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.mediaPlayer.getMediaPlayer());
        }
        public SplitContainer getSplitContainer()
        {
            return splitContainer1;
        }
        public ClassMedia getMedia()
        {
            return mediaPlayer;
        }
        public ClassListView getList()
        {
            return listView1;
        }
        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            int index = this.listView1.getListView().FocusedItem.Index;


            IWMPPlaylist playlist = this.getMedia().getMediaPlayer().playlistCollection.newPlaylist("myplaylist");
            IWMPMedia media;

            for (int i = 0; i < this.listView1.getListView().Items.Count; i++)
            {
                int j = 1;
                media = this.getMedia().getMediaPlayer().newMedia(this.listView1.getListView().Items[i].SubItems[j].Text);
                playlist.appendItem(media);
                this.getMedia().getMediaPlayer().currentPlaylist = playlist;
            }
            this.getMedia().getMediaPlayer().Ctlcontrols.play();
            for (int i = 0; i < index; i++)
            {
                this.getMedia().getMediaPlayer().Ctlcontrols.next();
            }
        }
    }
}
