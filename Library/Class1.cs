using System;
namespace SpaceSim
{
    public class SpaceObject
    {
        public String name { get; set; }
        public (double, double) position{ get; set; }
        public double objectRadius { get; set; }
        public double rotationalPeriod { get; set; }
        public double orbitalRadius { get; set; }
        public double orbitalPeriod { get; set; }
        public SpaceObject parent { get; set; }
        public SpaceObject(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
        {
           // this.position = this.posision();
            this.name = name;
            this.objectRadius = objectRadius;
            this.rotationalPeriod = rotationalPeriod;
            this.orbitalRadius = orbitalRadius;
            this.orbitalPeriod = orbitalPeriod;
            this.parent = parent;
        }
        public virtual void Draw()
        {
            Console.WriteLine(name);
        }
        public (double, double) calcPosition (double time)
        {
            // Formelen er hentet fra nettet. Mye testing pågang her.
                double x = 0;
                double y = 0;

            if (orbitalRadius != 0)
            {
                double rad = 2 * Math.PI * (time / orbitalPeriod);

                x = orbitalRadius * Math.Cos(rad);
                y = orbitalRadius * Math.Sin(rad);
            }
            else
            {
                x = 0;
                y = 0;
            }
            x *= 0.000001;
            y *= 0.000001;

                (double, double) pos = (x, y);
            return pos;
        }
    }



    public class Star : SpaceObject
    {
        
        public Star(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) {
            this.position = (0,0); // Standard star position since "everything" orbits it
        }
        public override void Draw()
        {
            Console.Write("Star : ");
            base.Draw();
        }
    }



    public class Planet : SpaceObject
    {
        public Planet(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) {  }
        public override void Draw()
        {
            Console.Write("Planet: ");
            base.Draw();
        }
    }



    public class Moon : Planet
    {
        public Moon(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) {  }
        public override void Draw()
        {
            Console.Write("Moon : ");
            base.Draw();
        }
    }



    public class DwarfPlanet : Planet
    {
        public DwarfPlanet(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) { }
        public override void Draw()
        {
            Console.Write("Dwarf planet: ");
            base.Draw();
        }
    }



    public class Comet : SpaceObject
    {
        public Comet(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) { }
        public override void Draw()
        {
            Console.Write("Comet: ");
            base.Draw();
        }
    }



    public class Asteroid : SpaceObject
    {
        public Asteroid(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) { }
        public override void Draw()
        {
            Console.Write("Asteroid: ");
            base.Draw();
        }
    }



    public class AsteroidBelt : SpaceObject
    {
        public AsteroidBelt(String name, double objectRadius, double rotationalPeriod, double orbitalRadius, double orbitalPeriod, SpaceObject parent)
            : base(name, objectRadius, rotationalPeriod, orbitalRadius, orbitalPeriod, parent) {  }
        public override void Draw()
        {
            Console.Write("Asteroid belt: ");
            base.Draw();
        }
    }
}
