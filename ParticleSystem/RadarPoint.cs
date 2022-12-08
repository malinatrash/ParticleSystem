using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class RadarPoint : IImpactPoint
    {
        List<Particle> radarParticles = new List<Particle>();
        public int radius = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            var currentParticle = (particle as ParticleColorful);
            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < radius / 2)
            {
                radarParticles.Add(currentParticle);
                if (Color == Color.OrangeRed) 
                {
                    currentParticle.FromColor = Color.MediumSpringGreen;
                    currentParticle.ToColor = Color.MediumSpringGreen;
                }
            }
            if (r + particle.Radius > radius / 2) 
            {
                radarParticles.Remove(currentParticle); 
                if (Color == Color.OrangeRed) 
                {
                    currentParticle.FromColor = Color.OrangeRed;
                    currentParticle.ToColor = Color.Yellow;
                }
            }
        } 

        public void ChangeSize(int value)
        {
            radius += value;
        }

        public override void Render(Graphics g)
        {
            Pen pen = new Pen(Color.DeepSkyBlue);
            pen.Width = 4;
            Font font = new Font("Verdana", 14, FontStyle.Bold);
            g.DrawEllipse(
                   pen,
                   X - radius / 2,
                   Y - radius / 2,
                   radius,
                   radius
               );


            var stringFormat = new StringFormat(); 
            stringFormat.Alignment = StringAlignment.Center; 
            stringFormat.LineAlignment = StringAlignment.Center; 

            g.DrawString(
            $"{radarParticles.Count}\n\n",
            font, 
            new SolidBrush(Color.White),
            X, 
            Y,
            stringFormat
        );
        }
    }
}
