using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class GravityPoint : IImpactPoint
    {
        public int Power = 100;

        public override void ImpactParticle(Particle particle)
        {
            float gX;
            float gY;
            float r2;
            if (Power < 0)
            {
                gX = X - particle.X;
                gY = Y - particle.Y;
                r2 = (float)Math.Max(100, gX * gX + gY * gY);

                particle.SpeedX -= gX * Math.Abs(Power) / r2;
                particle.SpeedY -= gY * Math.Abs(Power) / r2;

                return;
            }

             gX = X - particle.X;
             gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY); 
            if (r + particle.Radius < Power / 2) 
            {
                
                 r2 = (float)Math.Max(100, gX * gX + gY * gY);
                particle.SpeedX += gX * Power / r2;
                particle.SpeedY += gY * Power / r2;
            }
        }

        public override void Render(Graphics g)
        {
            
            Pen pen = new Pen(Color.DeepSkyBlue);
            pen.Width = 4;
            if (Power < 0)
            {
                pen.Color = Color.Black;
            } else
            {
                pen.Color = Color.White;    
            }
            g.DrawEllipse(
               pen,
               X + Math.Abs(Power) / 2,
               Y + Math.Abs(Power) / 2,
               - Math.Abs(Power),
               - Math.Abs(Power)
           );
        }
    }
}
