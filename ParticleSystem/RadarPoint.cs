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
        public int radius = 100;
        public int Count = 0;

        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;

            double r = Math.Sqrt(gX * gX + gY * gY);
            if (r + particle.Radius < radius / 2)
            {
                Count += 1;
            }
        } 

        public override void Render(Graphics g)
        {
            g.DrawEllipse(
                   new Pen(Color.LightGreen),
                   X - radius / 2,
                   Y - radius / 2,
                   radius,
                   radius
               );

            var stringFormat = new StringFormat(); 
            stringFormat.Alignment = StringAlignment.Center; 
            stringFormat.LineAlignment = StringAlignment.Center; 

            g.DrawString(
            $"{Count}\n\n",
            new Font("Verdana", 14), 
            new SolidBrush(Color.LightGreen),
            X, 
            Y,
            stringFormat
        );
        }
    }
}
