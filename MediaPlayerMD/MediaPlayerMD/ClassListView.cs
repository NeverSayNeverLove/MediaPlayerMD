using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MediaPlayerMD
{
    class ClassListView
    {
        private ListView listView1;
        private ColumnHeader colTitle;
        private ColumnHeader colLocation;
        public ClassListView()
        {
            this.colTitle = new ColumnHeader();
            this.colLocation = new ColumnHeader();
            this.listView1 = new ListView();
            this.listView1.Columns.AddRange(new ColumnHeader[] {
            this.colTitle,
            this.colLocation});
            this.listView1.BackColor = System.Drawing.Color.AliceBlue;
            this.listView1.ForeColor = System.Drawing.Color.DarkCyan;
            this.listView1.Dock = DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = View.Details;
            //
            // colTitle
            // 
            this.colTitle.Text = "Title";
            this.colTitle.Width = 100;
            // 
            // colLocation
            // 
            this.colLocation.Text = "Location";
        }
        public ListView getListView()
        {
            return listView1;
        }
    }
}
