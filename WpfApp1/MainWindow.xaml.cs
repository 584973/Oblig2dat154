using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using SpaceSim;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        DispatcherTimer timer = new DispatcherTimer();
        List<SpaceObject> solarSystem = new List<SpaceObject> { };
        List<Ellipse> planetList = new List<Ellipse> { };
        int moonScaling = 2000;
        double time = 0;
        string focus = "Sun";

        public MainWindow()
        {
            InitializeComponent();

            Star sun = new Star("Sun", 15000, 0, 0, 0, null);
            Planet mercury = new Planet("Mercury", 4879 / 2, 59, 57909227, 87.97, sun);
            Planet venus = new Planet("Venus", 12104 / 2, 243, 108209475, 224.70, sun);
            Planet terra = new Planet("Terra", 12714 / 2, 1, 149598262, 365.26, sun);
            Planet uranus = new Planet("Uranus", 51118 / 2, 17 / 24, 2870658186, 30687.15, sun);
            Planet saturn = new Planet("Saturn", 120536 / 2, 10.6 / 24, 1426666422, 10755.70, sun);
            Planet jupiter = new Planet("Jupiter", 142984 / 2, 10 / 24, 778340821, 4332.82, sun);
            Planet neptune = new Planet("Neptune", 49528 / 2, 16 / 24, 4498396441, 60190.03, sun);
            DwarfPlanet pluto = new DwarfPlanet("Pluto", 2368 / 2, 153 / 24, 5874000000, 247.92065, sun);
            Planet mars = new Planet("Mars", 6805 / 2, 24.6 / 24, 227943824, 686.98, sun);

            Moon moon = new Moon("Luna", 3475 / 2, 29.5, 384400, 27, terra);
            Moon phobos = new Moon("Phobos", 22.2 / 2, 0, 9000, 8 / 24, mars);
            Moon deimos = new Moon("Deimos", 6.2, 0, 23000, 1.26, mars);

            solarSystem.Add(mercury);
            solarSystem.Add(venus);
            solarSystem.Add(terra);
            solarSystem.Add(uranus);
            solarSystem.Add(saturn);
            solarSystem.Add(jupiter);
            solarSystem.Add(neptune);
            solarSystem.Add(mars);
            solarSystem.Add(pluto);

            solarSystem.Add(moon);
            //solarSystem.Add(phobos);
            solarSystem.Add(deimos);


            timer.Interval = TimeSpan.FromSeconds(0.1);
            timer.Tick += timer_Tick;
            timer.Start();

            focus = "Terra";

            DrawSystem();

        }

        private void DrawSystem()
        {

            Ellipse planet;
            SolidColorBrush planetColor = new SolidColorBrush(Color.FromRgb(255, 255, 255)); // White
            SolidColorBrush orbitColor = new SolidColorBrush(Color.FromRgb(0, 0, 0)); // Black
            SolidColorBrush sunColor = new SolidColorBrush(Color.FromRgb(255, 165, 0)); // Orange
            List<SpaceObject> sortedSolarSystem = solarSystem.OrderBy(p => p.orbitalRadius).ToList();
            sortedSolarSystem.Reverse();
            (double, double) pos;

            if (focus == "Sun")
            {

                // Orbit tracks
                foreach (SpaceObject spaceObj in sortedSolarSystem)
                {
                    if (spaceObj.name != "Sun" || spaceObj.name != "The Moon") // middlertidig med månen.
                    {
                        Ellipse orbitTrack = new Ellipse();
                        orbitTrack.Stroke = System.Windows.Media.Brushes.White;
                        orbitTrack.StrokeThickness = 1;
                        orbitTrack.Height = Math.Abs(spaceObj.calcPosition(time).Item1);
                        orbitTrack.Width = Math.Abs(spaceObj.calcPosition(time).Item1);
                        orbitTrack.HorizontalAlignment = HorizontalAlignment.Center;
                        orbitTrack.VerticalAlignment = VerticalAlignment.Center;
                        SolarSystem.Children.Add(orbitTrack);
                    }
                }


                // Planets
                foreach (SpaceObject spaceObj in solarSystem)
                {
                    if (spaceObj.parent.name == "Sun")
                    {
                        planet = new Ellipse();
                        planetColor = new SolidColorBrush(Color.FromRgb(255, 255, 255));

                        if (spaceObj.name == "Terra")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(0, 100, 200);
                        }
                        else if (spaceObj.name == "Mars")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(147, 72, 56);
                        }
                        else if (spaceObj.name == "Mercury")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(232, 211, 185);
                        }
                        else if (spaceObj.name == "Uranus")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(209, 231, 231);
                        }
                        else if (spaceObj.name == "Jupiter")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(188, 175, 178);
                        }
                        else if (spaceObj.name == "Neptune")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(75, 112, 221);
                        }
                        else if (spaceObj.name == "Venus")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(165, 124, 27);
                        }
                        else if (spaceObj.name == "Saturn")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(234, 214, 184);
                        }
                        else if (spaceObj.name == "Pluto")
                        {
                            planetColor = new SolidColorBrush();
                            planetColor.Color = Color.FromRgb(156, 166, 183);
                        }

                        pos = spaceObj.calcPosition(time);
                        Thickness m = new Thickness(pos.Item1, pos.Item2, 0, 0);
                        planet.Stroke = System.Windows.Media.Brushes.Black;
                        // circle 
                        planet.Height = 15;
                        planet.Width = 15;
                        planet.Fill = planetColor;
                        planet.Margin = m;
                        planet.Name = spaceObj.name;

                        planetList.Add(planet);
                        SolarSystem.Children.Add(planet);
                    }

                }

                // Sun
                Ellipse centerSun = new Ellipse();
                centerSun.Height = 45;
                centerSun.Width = 45;
                centerSun.Fill = sunColor;
                SolarSystem.Children.Add(centerSun);

                // Subsystems
            }
            else if (focus == "Terra")
            {

                Ellipse centerPlanet = new Ellipse();
                centerPlanet.Height = 45;
                centerPlanet.Width = 45;
                centerPlanet.Fill = new SolidColorBrush(Color.FromRgb(0, 100, 200));
                SolarSystem.Children.Add(centerPlanet);

                foreach (SpaceObject obj in solarSystem)
                {
                    if (obj.parent.name == "Terra")
                    {
                        DrawMoon(obj);
                    }

                }
            }
            else if (focus == "Mars")
            {
                Ellipse centerPlanet = new Ellipse();
                centerPlanet.Height = 30;
                centerPlanet.Width = 30;
                centerPlanet.Fill = new SolidColorBrush(Color.FromRgb(147, 72, 56));
                SolarSystem.Children.Add(centerPlanet);

                foreach (SpaceObject obj in solarSystem)
                {
                    if (obj.parent.name == "Mars")
                    {
                        DrawMoon(obj);
                    }

                }
            }
        }

        private void DrawMoon(SpaceObject obj)
        {
            Ellipse orbitTrack = new Ellipse();
            orbitTrack.Stroke = System.Windows.Media.Brushes.White;
            orbitTrack.StrokeThickness = 1;
            orbitTrack.Height = Math.Abs(obj.calcPosition(time).Item1 * moonScaling);
            orbitTrack.Width = Math.Abs(obj.calcPosition(time).Item1 * moonScaling);
            orbitTrack.HorizontalAlignment = HorizontalAlignment.Center;
            orbitTrack.VerticalAlignment = VerticalAlignment.Center;
            SolarSystem.Children.Add(orbitTrack);

            Ellipse moon = new Ellipse();
            (double, double) pos = obj.calcPosition(time);
            Thickness m = new Thickness(pos.Item1 * moonScaling, pos.Item2 * moonScaling, 0, 0);
            moon.Stroke = System.Windows.Media.Brushes.Black;
            moon.Height = 15;
            moon.Width = 15;
            moon.Fill = new SolidColorBrush(Color.FromRgb(100, 100, 100)); ;
            moon.Margin = m;
            moon.Name = obj.name;
            planetList.Add(moon);
            SolarSystem.Children.Add(moon);
        }

        private void timer_Tick(object? sender, EventArgs e)
        {
            time++;
            Update();

        }

        private void Update()
        {
            foreach (SpaceObject spaceObj in solarSystem)
            {
                foreach (Ellipse planet in planetList)
                {
                    if (spaceObj.name == planet.Name)
                        if (focus == "Sun") // Planets 
                        {
                            (double, double) newPos = spaceObj.calcPosition(time);
                            Thickness m = new Thickness(newPos.Item1, newPos.Item2, 0, 0);
                            planet.Margin = m;
                        }
                        else if (focus != "Sun" && spaceObj.parent.name == "Terra")
                        {
                            (double, double) newPos = spaceObj.calcPosition(time);
                            Thickness m = new Thickness(newPos.Item1 * moonScaling, newPos.Item2 * moonScaling, 0, 0);
                            planet.Margin = m;
                        }
                        else if (focus != "Sun" && spaceObj.parent.name == "Mars")
                        {
                            (double, double) newPos = spaceObj.calcPosition(time);
                            Thickness m = new Thickness(newPos.Item1 * moonScaling, newPos.Item2 * moonScaling, 0, 0);
                            planet.Margin = m;
                        }


                }
            }
        }




    }



}
