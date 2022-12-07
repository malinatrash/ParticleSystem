using System.Runtime.Serialization.Formatters.Binary;


namespace ParticleSystem
{
    public partial class View : Form
    {
        Emitter emitter;
        List<Emitter> emitters = new List<Emitter>();

        GravityPoint gravityPoint; 
        RadarPoint radarPoint;

        private GifImage gifImage;
        private readonly string niggaBackground = "niggaDance.gif";
        private readonly string nagievBackground = "nagiev.gif";
        private readonly string chickaBackground = "FujiwaraChicka.gif";
        private readonly string tortureDanceBackground = "tortureDance.gif";
        private readonly string hayaBackground = "haya.gif";
        private readonly string musicPath = "back.mp3.m4a";
        private readonly string dancingMusic = "dancin.mp3";
        private readonly string hayaMusic = "haya.mp3.m4a";
        private readonly string theWorldMusic = "theWorld.mp3";
        private readonly string tortureDanceMusic = "torture.m4a.mp3.m4a";

        private WMPLib.WindowsMediaPlayer music = new WMPLib.WindowsMediaPlayer();
        public View()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            picDisplay.MouseWheel += picDisplay_MouseWheel;

            emitter = new TopEmitter
            {
                Width = picDisplay.Width,
                GravitationY = 0.25f
            };

            this.emitter = new Emitter 
            { 
                Direction = 0,
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10, 
                ColorFrom = Color.Gold, 
                ColorTo = Color.FromArgb(0, Color.Red),
                ParticlesPerTick = 10,
                X = picDisplay.Width / 2,
                Y = picDisplay.Height / 2,
            };
            emitters.Add(this.emitter);

            SetupBackgroudList();

            SetMusic(null);




            gravityPoint = new GravityPoint
            {
                X = picDisplay.Width / 2 + 100,
                Y = picDisplay.Height / 2,
            };
            radarPoint = new RadarPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            emitter.impactPoints.Add(gravityPoint);
            emitter.impactPoints.Add(radarPoint);


        }

        private void SetupBackgroudList()
        {
            backgroudList.Items.Add("1 + 1");
            backgroudList.Items.Add("Torture dance");
            backgroudList.Items.Add("Нагиев");
            backgroudList.Items.Add("Чика");
            backgroudList.Items.Add("HEYYEYAAEYAAAEYAEYAA");
            
            backgroudList.SelectedIndex = 0;
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


        private void SetBackground(string? file, bool isReversed)
        {
            picDisplay.BackgroundImage = Image.FromFile(niggaBackground);
            picDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            if (file == null)
            {
                if (File.Exists(niggaBackground+".gi"))
                {
                    gifImage = new GifImage(LoadFromFile(niggaBackground), niggaBackground);
                    gifImage.ReverseAtEnd = isReversed;
                } else
                {
                    gifImage = new GifImage(niggaBackground);
                    gifImage.ReverseAtEnd = isReversed;
                    SaveToFile(niggaBackground);
                }
            } else
            {
                if (File.Exists(file + ".gi"))
                {
                    gifImage = new GifImage(LoadFromFile(file), file);
                    gifImage.ReverseAtEnd = isReversed;
                }
                else
                {
                    gifImage = new GifImage(file);
                    gifImage.ReverseAtEnd = isReversed;
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

            
        }

        private new void MouseMove(object sender, MouseEventArgs e)
        {
            foreach (var emitter in emitters)
            {
                emitter.MousePositionX = e.X;
                emitter.MousePositionY = e.Y;
            }

            radarPoint.X = e.X;
            radarPoint.Y = e.Y;
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
                SetBackground(dialog.FileName, false);
            }
        }

        private void BackgroudListSelectedIndexChanged(object sender, EventArgs e)
        {
            if (backgroudList.SelectedIndex == 0)
            {
                SetBackground(niggaBackground, true);
                SetMusic(musicPath);
                timer.Interval = 25;
            }
            if (backgroudList.SelectedIndex == 1)
            {
                SetBackground(tortureDanceBackground, false);
                SetMusic(tortureDanceMusic);
                timer.Interval = 94;
            }
            else if (backgroudList.SelectedIndex == 2)
            {
                SetBackground(nagievBackground, false);
                SetMusic(musicPath);
                timer.Interval = 17;
            }
            else if (backgroudList.SelectedIndex == 3)
            {
                SetBackground(chickaBackground, false);
                SetMusic(dancingMusic);
                timer.Interval = 30;
            }
            else if (backgroudList.SelectedIndex == 4)
            {
                SetBackground(hayaBackground, false);
                SetMusic(hayaMusic);
                timer.Interval = 94;
            }

        }

        private void trackBarDirectionChange(object sender, EventArgs e)
        {
            emitter.Direction = trackBarDirection.Value;
            directionLabel.Text = $"Направление : {trackBarDirection.Value}°";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBarPower_Scroll(object sender, EventArgs e)
        {
            gravityPoint.Power = trackBarPower.Value;
            powerLabel.Text = $"Сила гравитации : {trackBarPower.Value}";
            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            timer.Interval = trackBarTimer.Value;
            if (timer.Interval == 1)
            {
                WMPLib.WindowsMediaPlayer musicNew = new WMPLib.WindowsMediaPlayer();
                music.controls.pause();
                musicNew.URL = theWorldMusic;
                musicNew.controls.play();
                timerInterval.Text = $"Частота обновления : 0";
                timer.Stop();
                //Stop(4000);
                music.controls.play();
            } else
            {
                timer.Start();
            }
               
            timerInterval.Text = $"Частота обновления : {timer.Interval}";
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            radarPoint.radius += 1;
        }

        async void Stop(int time)
        {
            await Task.Delay(time).WaitAsync( new System.TimeSpan(time));
        }
    }
}