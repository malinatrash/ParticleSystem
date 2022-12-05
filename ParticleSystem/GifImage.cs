using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class GifImage
    {
        private Image gifImage;
        private FrameDimension dimension;
        private int frameCount;
        private int currentFrame = -1;
        private bool reverse;
        private int step = 1;
        private List<Image> frameList = new();
        private Boolean isEven = false;

        public GifImage(string path)
        {
            gifImage = Image.FromFile(path);
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            frameCount = gifImage.GetFrameCount(dimension);
            frameList = FrameList();
        }

        public GifImage(List<Image> list, string path)
        {
            gifImage = Image.FromFile(path);
            dimension = new FrameDimension(gifImage.FrameDimensionsList[0]);
            frameCount = gifImage.GetFrameCount(dimension);
            frameList = list;
        }

        private List<Image> FrameList()
        {
            List<Image> list = new List<Image>();
            for (int i = 0; i < frameCount; i++)
            {
                list.Add(GetFrame(i));
            }
            return list;
        }

        public List<Image> GetFrameList()
        {
            return frameList;
        }

        public bool ReverseAtEnd
        {
            get { return reverse; }
            set { reverse = value; }
        }

        private Image ReplaceFrame(int index)
        {
            Image frame = frameList[index];
            return frame;
        }

        public Image GetNextFrame()
        {
            //if (isEven)
            // {
            //     isEven = false;
            // } else
            // {
            //      currentFrame += step;
            //      isEven = true;
            //   }
            currentFrame += step;

            if (currentFrame >= frameCount || currentFrame < 0)
            {
                if (reverse)
                {
                    step *= -1;
                    currentFrame += step;
                }
                else
                {

                    currentFrame = 0;
                }
            }
           
                return ReplaceFrame(currentFrame);
            
            
            //return GetFrame(currentFrame);
        }

        public Image GetFrame(int index)
        {
            gifImage.SelectActiveFrame(dimension, index);
            return (Image)gifImage.Clone();
        }
    }
}
