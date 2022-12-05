using GES;
using Microsoft.VisualBasic.Devices;
using System.Media;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using VisioForge.Libs.TagLib.Id3v2;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;


namespace ParticleSystem
{
    public partial class View : Form
    {
        Emitter emitter = new();
        private GifImage gifImage;
        //private readonly string filePath = "C:\\niggaDance.gif";
        private readonly string filePath = "C:\\niggaDance.gif";
        private readonly string musicPath = "C:\\back.mp3.m4a";
        private WMPLib.WindowsMediaPlayer music = new WMPLib.WindowsMediaPlayer();
        public View()
        {
            InitializeComponent();

            SetMusic(null);
            SetBackground(null);

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

        private void SaveToFile(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream($"{path}.gi", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, gifImage.GetFrameList());

                Console.WriteLine("Объект сериализован");
            }
        }

        private List<Image> LoadFromFile(string path)
        {
            List<Image> list;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream($"{path}.gi", FileMode.OpenOrCreate))
            {
                
                list = (List<Image>)formatter.Deserialize(fs);
            }
            return list;
        }


        private void SetBackground(string? file)
        {
            picDisplay.BackgroundImage = Image.FromFile(filePath);
            picDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            if (file == null)
            {
                if (File.Exists(filePath+".gi"))
                {
                    gifImage = new GifImage(LoadFromFile(filePath), filePath);
                    gifImage.ReverseAtEnd = true;
                } else
                {
                    gifImage = new GifImage(filePath);
                    gifImage.ReverseAtEnd = true;
                    SaveToFile(filePath);
                }
            } else
            {
                if (File.Exists(file + ".gi"))
                {
                    gifImage = new GifImage(LoadFromFile(file), file);
                    gifImage.ReverseAtEnd = true;
                }
                else
                {
                    gifImage = new GifImage(file);
                    gifImage.ReverseAtEnd = true;
                    SaveToFile(file);
                }
            }
           
        }

        private void SetMusic(string? file)
        {
            if (file == null)
            {
                music.URL = musicPath;
                music.controls.play();
            } else
            {
                music.controls.stop();
                music.URL = file;
                music.controls.play();
                
            }
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

            if (!music.enabled)
            {
                music.controls.play();
            }
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
                SetMusic(dialog.FileName);
            }
        }

        private void ChooseGifButtonPressed(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new();
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                SetBackground(dialog.FileName);
            }
        }
    }
}