using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace RandomClips
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rand = new Random();
            int fCount = System.IO.Directory.GetFiles("./Clips", "*", System.IO.SearchOption.TopDirectoryOnly).Length;
            int [] playlist = new int[fCount];
            string[] fileListPath = new string[fCount];
            for (int i = 0; i<fCount;i++)
            {
                int x = rand.Next(1, fCount);
                if (playlist.Contains(x))
                {
                }
                else
                {
                    playlist[i] = x;
                    //MessageBox.Show("" + x);
                }
            }
            int fileIndex = 0;
                foreach (string fileName in Directory.GetFiles("./Clips", "*", System.IO.SearchOption.TopDirectoryOnly))
                {
                fileListPath[fileIndex] = fileName;
                fileIndex++;
                
                }
            string[] playpaths = new string[fCount];
            var pClips = axWindowsMediaPlayer1.playlistCollection.newPlaylist("Cips");
            for (int i = 0; i < fCount; i++)
            {
               playpaths[i] = fileListPath[playlist[i]];
               var mediaItem = axWindowsMediaPlayer1.newMedia(playpaths[i]);
               pClips.appendItem(mediaItem);
            }

            axWindowsMediaPlayer1.currentPlaylist = pClips;
            axWindowsMediaPlayer1.uiMode = "none";
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            axWindowsMediaPlayer1.close();
        }
    }
}
