using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AxWMPLib;
namespace MediaPlayerMD
{
    class ClassMedia
    {
        private AxWindowsMediaPlayer mediaPlayer;
        public ClassMedia()
        {
            this.mediaPlayer = new AxWindowsMediaPlayer();
            this.mediaPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaPlayer.Enabled = true;
            this.mediaPlayer.Location = new System.Drawing.Point(0, 0);
            //this.mediaPlayer.OcxState = ((AxHost.State)(resources.GetObject("mediaPlayer.OcxState")));
            this.mediaPlayer.TabIndex = 0;
        }
        public AxWindowsMediaPlayer getMediaPlayer()
        {
            return mediaPlayer;
        }
    }
}
