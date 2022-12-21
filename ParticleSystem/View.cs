using System.Runtime.Serialization.Formatters.Binary;


namespace ParticleSystem
{
    public partial class View : Form
    {
        private static readonly string resoures = "C:/ParticleSystem/ParticleSystem/Resourses/";

        private static Random random = new Random();

        Emitter emitter;
        List<Emitter> emitters = new List<Emitter>();
        List<GravityPoint> gravityPoints = new();
        private RadarPoint radarPoint;

        private int selectedBackground = new Random().Next(0, 4);

        private GifImage gifImage;
        private readonly string niggaBackground = resoures + "niggaDance.gif";
        private readonly string mazikBackground = resoures + "mazik.gif";
        private readonly string chickaBackground = resoures + "FujiwaraChicka.gif";
        private readonly string tortureDanceBackground = resoures + "tortureDance.gif";
        private readonly string theWorldBackground = resoures + "theWorld.jpeg";
        private readonly string hayaBackground = resoures + "haya.gif";
        private readonly string musicPath = resoures + "back.mp3.m4a";
        private readonly string dancingMusic = resoures + "dancin.mp3";
        private readonly string hayaMusic = resoures + "haya.mp3.m4a";
        private readonly string mazikMusic = resoures + "mazik.mp3.m4a";
        private readonly string theWorldMusic = resoures + "theWorld.mp3";
        private readonly string tortureDanceMusic = resoures + "torture.m4a.mp3.m4a";

        private WMPLib.WindowsMediaPlayer music = new WMPLib.WindowsMediaPlayer();
        public View()
        {
            InitializeComponent();
            picDisplay.Image = new Bitmap(picDisplay.Width, picDisplay.Height);

            radarPoint = new RadarPoint
            {
                X = picDisplay.Width / 2 - 100,
                Y = picDisplay.Height / 2,
            };

            Emitter.impactPoints.Add(radarPoint);

            picDisplay.MouseWheel += picDisplay_MouseWheel;

            SetupBackgroudList();
            timerInterval.Text = $"Частота обновления : {timer.Interval}";

        }

        private Color GetRandomColor()
        {
            return Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        private int GetRandom()
        {
            return random.Next(0, 359);
        } 

        private Emitter AddEmitter(int x, int y)
        {
            emitter = new Emitter
            {
                Direction = GetRandom(),
                Spreading = 10,
                SpeedMin = 10,
                SpeedMax = 10,
                ColorFrom = GetRandomColor(),
                ColorTo = GetRandomColor(),
                ParticlesPerTick = 10,
                X = x,
                Y = y,
            };
            return emitter;
        }

        private void SetupBackgroudList()
        {
            backgroudList.Items.Add("1 + 1");
            backgroudList.Items.Add("Torture dance");
            backgroudList.Items.Add("Майонез");
            backgroudList.Items.Add("Чика");
            backgroudList.Items.Add("HEYYEYAAEYAAAEYAEYAA");

            backgroudList.SelectedIndex = selectedBackground;
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

        private List<System.Drawing.Image> LoadFromFile(string path)
        {
            List<System.Drawing.Image> list;
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream($"{path}.gi", FileMode.OpenOrCreate))
            {

                list = (List<System.Drawing.Image>)formatter.Deserialize(fs);
            }
            return list;
        }


        private void SetBackground(string? file, bool isReversed)
        {
            picDisplay.BackgroundImage = System.Drawing.Image.FromFile(niggaBackground);
            picDisplay.SizeMode = PictureBoxSizeMode.StretchImage;
            if (file == null)
            {
                if (File.Exists(niggaBackground + ".gi"))
                {
                    gifImage = new GifImage(LoadFromFile(niggaBackground), niggaBackground);
                    gifImage.ReverseAtEnd = isReversed;
                }
                else
                {
                    gifImage = new GifImage(niggaBackground);
                    gifImage.ReverseAtEnd = isReversed;
                    SaveToFile(niggaBackground);
                }
            }
            else
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
            }
            else
            {
                music.controls.stop();
                music.URL = file;
                music.controls.play();

            }
        }

        private void DoTick(object sender, EventArgs e)
        {
            picDisplay.BackgroundImage = gifImage.GetNextFrame();
            emitters.ForEach(emitter => emitter.UpdateState());
            //emitter.UpdateState();

            using (var g = Graphics.FromImage(picDisplay.Image))
            {
                g.Clear(System.Drawing.Color.FromArgb(0, 0, 0, 0));
                emitters.ForEach(emitter => emitter.Render(g));
            }
            picDisplay.Invalidate();
        }

        private new void MouseMove(object sender, MouseEventArgs e)
        {
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
                timerInterval.Text = $"Частота обновления : {timer.Interval}";
                selectedBackground = 0;
            }
            if (backgroudList.SelectedIndex == 1)
            {
                SetBackground(tortureDanceBackground, false);
                SetMusic(tortureDanceMusic);
                timer.Interval = 94;
                timerInterval.Text = $"Частота обновления : {timer.Interval}";
                selectedBackground = 1;
            }
            else if (backgroudList.SelectedIndex == 2)
            {
                SetBackground(mazikBackground, false);
                SetMusic(mazikMusic);
                timer.Interval = 17;
                timerInterval.Text = $"Частота обновления : {timer.Interval}";
                selectedBackground = 2;
            }
            else if (backgroudList.SelectedIndex == 3)
            {
                SetBackground(chickaBackground, false);
                SetMusic(dancingMusic);
                timer.Interval = 30;
                timerInterval.Text = $"Частота обновления : {timer.Interval}";
                selectedBackground = 3;
            }
            else if (backgroudList.SelectedIndex == 4)
            {
                SetBackground(hayaBackground, false);
                SetMusic(hayaMusic);
                timer.Interval = 94;
                timerInterval.Text = $"Частота обновления : {timer.Interval}";
                selectedBackground = 4;
            }

        }

        private void trackBarDirectionChange(object sender, EventArgs e)
        {
            emitters.ForEach(emitter => emitter.Direction += trackBarDirection.Value);
            directionLabel.Text = $"Направление : {trackBarDirection.Value}°";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void trackBarPower_Scroll(object sender, EventArgs e)
        {
            foreach (GravityPoint gravityPoint in gravityPoints)
            {
                gravityPoint.Power = trackBarPower.Value;
            }

            powerLabel.Text = $"Сила гравитации : {trackBarPower.Value}";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            debugLabel.Text = "";
            backgroudList.SelectedIndex = selectedBackground;
            if (selectedBackground == 1 || selectedBackground == 4)
            {
                timer.Interval = 94;
            }

            music.controls.play();
            timer.Interval = trackBarTimer.Value;
            if (timer.Interval == 1)
            {
                timer.Stop();
                WMPLib.WindowsMediaPlayer musicNew = new WMPLib.WindowsMediaPlayer();
                music.controls.pause();
                picDisplay.BackgroundImage = System.Drawing.Image.FromFile(theWorldBackground);
                musicNew.URL = theWorldMusic;
                musicNew.controls.play();
                timerInterval.Text = $"Частота обновления : 0";

            }
            else
            {
                timer.Start();
            }

            timerInterval.Text = $"Частота обновления : {timer.Interval}";
        }

        private void picDisplay_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                radarPoint.ChangeSize(-2);
            }
            else if (e.Delta < 0)
            {
                radarPoint.ChangeSize(2);
            }
        }


        private void trackBarParticlesPerTick_Scroll(object sender, EventArgs e)
        {
            emitters.ForEach(emitter => emitter.ParticlesPerTick = trackBarParticlesPerTick.Value);
            particlesPerTickLabel.Text = $"Частиц за тик : {trackBarParticlesPerTick.Value}";
        }

        private void trackBarSpread_Scroll(object sender, EventArgs e)
        {
            emitters.ForEach(emitter => emitter.Spreading = trackBarSpread.Value);
            spreadLabel.Text = $"Коэффицент распределения : {trackBarSpread.Value}";
        }

        private void MouseClick(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    {
                        Emitter.impactPoints.Add(new CountPoint
                        {
                            X = e.X,
                            Y = e.Y
                        });
                    }
                    break;
                case MouseButtons.Middle:
                    {
                        Emitter.impactPoints.Add(new GravityPoint
                        {
                            X = e.X,
                            Y = e.Y,
                            Power = trackBarPower.Value
                        });
                    }
                    break;
                case MouseButtons.Right:
                    {
                        emitters.Add(AddEmitter(e.X, e.Y));
                    }
                    break;
            }
        }
    }
}