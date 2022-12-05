using GES;
using Microsoft.VisualBasic.Devices;
using System.Media;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace ParticleSystem
{
    public partial class View : Form
    {
        Emitter emitter = new();
        private GifImage gifImage = null;
        private readonly string filePath = "C:\\niggaDance.gif";
        WMPLib.WindowsMediaPlayer music;
       // SoundPlayer music;
        public View()
        {
            InitializeComponent();

            //music = new SoundPlayer("C:\\back.wav");
            // music.Play();

            music = new WMPLib.WindowsMediaPlayer();

            music.URL = "C:\\back.mp3.m4a";
            music.controls.play();



            picDisplay.BackgroundImage = Image.FromFile("C:\\niggaDance.gif");

            picDisplay.SizeMode = PictureBoxSizeMode.StretchImage;


           gifImage = new GifImage(filePath);
           gifImage.ReverseAtEnd = true;

            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);
            

            emitter.gravityPoints.Add(new Point(
            picDisplay.Width / 2, picDisplay.Height / 2
            ));
      
            emitter.gravityPoints.Add(new Point(
              (int)(picDisplay.Width * 0.75), picDisplay.Height / 2
            ));

            emitter.gravityPoints.Add(new Point(
               (int)(picDisplay.Width * 0.25), picDisplay.Height / 2
            ));
        }

        private void DoTick(object sender, EventArgs e)
        {
          picDisplay.BackgroundImage = gifImage.GetNextFrame();

            emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(Color.FromArgb(0, 0, 0, 0));
                emitter.Render(g);
            }
            picDisplay.Invalidate();
        }

        private new void MouseMove(object sender, MouseEventArgs e)
        {
            emitter.MousePositionX = e.X;
            emitter.MousePositionY = e.Y;
        }

        private void ChooseMusicButtonPressed(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                music.controls.stop();
                music.URL = dialog.FileName;
                music.controls.play();
            }
        }
    }
}