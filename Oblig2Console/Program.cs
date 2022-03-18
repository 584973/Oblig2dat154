using System;
using System.Collections.Generic;
using SpaceSim;
class Astronomy
{
    public static List<SpaceObject> solarSystem = new List<SpaceObject> { };
    public static void Main()
    {
        // using km and earth days

        Star sun = new Star("Sun",15000, 0 , 0, 0, null );

        Planet mercury = new Planet("Mercury", 4879/2, 59, 57909227, 87.97, sun );
        Planet venus = new Planet("Venus", 12104/2, 243, 108209475, 224.70, sun);
        Planet terra = new Planet("Terra", 12714/2, 1, 149598262, 365.26, sun );
        Planet uranus = new Planet("Uranus", 51118/2 , 17 / 24, 2870658186, 30687.15, sun);
        Planet saturn = new Planet("Saturn", 120536/2, 10.6/24, 1426666422, 10755.70, sun);
        Planet jupiter = new Planet("Jupiter", 142984/2 , 10/24 , 778340821, 4332.82, sun);
        Planet neptune = new Planet("Neptune", 49528/2, 16/24, 4498396441, 60190.03, sun);
        Planet mars = new Planet("Mars", 6805/2, 24.6/24, 227943824, 686.98, sun);
        DwarfPlanet pluto = new DwarfPlanet("Pluto", 2368/2, 153/24, 5874000000, 247.92065, sun);

        Moon moon = new Moon("The Moon", 3475/2 , 29.5, 384400, 27, terra);

        //AsteroidBelt belt = new AsteroidBelt("Belt", 0, 0, 0, 0, sun);

        // Småjukser litt på denne siden det er en solid ring, så sier vi den står i ro.
        AsteroidBelt saturnsRings = new AsteroidBelt("Saturns rings", (saturn.objectRadius + 250000), 0, 0, 0, saturn);

        // Center 
        solarSystem.Add(sun);
        
        // Planets
        solarSystem.Add(mercury);
        solarSystem.Add(venus);
        solarSystem.Add(terra);
        solarSystem.Add(uranus);
        solarSystem.Add(saturn);
        solarSystem.Add(jupiter);
        solarSystem.Add(neptune);
        solarSystem.Add(mars);
        solarSystem.Add(pluto);

        // other
        solarSystem.Add(moon);
        //solarSystem.Add(belt);
        solarSystem.Add(saturnsRings);

        double time = 0;
        String spaceObj = "sun";

        Console.WriteLine("Skriv inn tidspunkt: ");
        time = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Skriv inn romlegeme: ");
        spaceObj = Console.ReadLine();

        Console.WriteLine("---------------------------");

        // If null, it will default to show Sun and its orbiters
        if (spaceObj == "")
        {
            sun.Draw();
            Console.WriteLine("Located at position: " + sun.calcPosition(time));
            Console.WriteLine();

            foreach (SpaceObject orbiter in solarSystem)
            {
                if (orbiter.parent == sun)
                {
                    orbiter.Draw();
                    Console.WriteLine("Located at position: " + orbiter.calcPosition(time));
                    Console.WriteLine("Orbital Period: " + orbiter.orbitalPeriod + " earthdays around " + orbiter.parent.name);
                    Console.WriteLine();
                }
            }
        } else
        {
            foreach (SpaceObject obj in solarSystem)
            {
                if (obj.name == spaceObj)
                {
                    obj.Draw();
                    Console.WriteLine("Located at position: " + obj.calcPosition(time));
                    Console.WriteLine("Orbital Period: " + obj.orbitalPeriod + " earthdays around " + obj.parent.name);
                    Console.WriteLine();

                    foreach (SpaceObject orbiter in solarSystem)
                    {
                        if (orbiter.parent != null && orbiter.parent.name == spaceObj)
                        {
                            orbiter.Draw();
                            Console.WriteLine("Located at position: " + orbiter.calcPosition(time));
                            Console.WriteLine("Orbital Period: " + orbiter.orbitalPeriod + " earthdays around " + orbiter.parent.name);
                            Console.WriteLine();
                        }
                    }
                }
            }
        }

        
    }
}