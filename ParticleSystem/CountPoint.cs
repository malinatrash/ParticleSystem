using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public class CountPoint : IImpactPoint
    {
        public int Radius = 100;
        public int Count = 0;
        public override void ImpactParticle(Particle particle)
        {
            float gX = X - particle.X;
            float gY = Y - particle.Y;
            double r = Math.Sqrt(gX * gX + gY * gY); 
            var currentPacticle = (particle as ParticleColorful);
            if (r + particle.Radius < Radius / 2)
            {
                currentPacticle.Radius = 0;
                currentPacticle.Life = 0; 
                Count += 1; 
            }
        }
        public override void Render(Graphics g)
        {
            var b = new SolidBrush(Color.OrangeRed);
            g.FillEllipse(b, X - Radius / 2, Y - Radius / 2, Radius, Radius);

            Pen pen = new Pen(Color.White);
            pen.Width = 4;
            Font font = new Font("Verdana", 15, FontStyle.Bold);
            g.DrawEllipse(
                   pen,
                   X - Radius / 2,
                   Y - Radius / 2,
                  Radius,
                  Radius
               );
            var stringFormat = new StringFormat(); 
            stringFormat.Alignment = StringAlignment.Center; 
            stringFormat.LineAlignment = StringAlignment.Center; 
            g.DrawString(
                 $"{Count}",
                 font,
                 new SolidBrush(Color.White),
                 X, Y, stringFormat);
        }
    }
}
