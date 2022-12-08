﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    public abstract class IImpactPoint
    {
        public float X;
        public float Y;
        public Color Color = Color.OrangeRed; 

        public abstract void ImpactParticle(Particle particle);
        public virtual void Render(Graphics g)
        {
            g.FillEllipse(
                    new SolidBrush(Color.Red),
                    X - 5,
                    Y - 5,
                    10,
                    10
                );
        }
    }
}
