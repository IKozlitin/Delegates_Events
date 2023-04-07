using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

//синтаксис события
/*[модификатор] event ИмяДелегата ИмяСобытия;*/

namespace Delegates_Events
{
      
    public abstract class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }
    }

    class Sport : Car
    {
        public Sport()
        {
            Brand = "Nissan";
            Model = "GT-R";
            Speed = 0;
            Distance = 0;
        }
        public void NextPoint()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\tGo next");
        }
        public void Finish()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance} Finish");
        }
    }

    class Passenger : Car
    {
       
        public Passenger()
        {
            Brand = "VW";
            Model = "Passat";
            Speed = 0;
            Distance = 0;
        }
        public void NextPoint()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\tGo next");
        }
        public void Finish()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance} Finish");
        }
    }

    class Truck : Car
    {
        
        public Truck()
        {
            Brand = "Ford";
            Model = "F-150";
            Speed = 0;
            Distance = 0;
        }
        public void NextPoint()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\tGo next");
        }
        public void Finish()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance} Finish");
        }

    }

    class Bus : Car
    {
        
        public Bus()
        {
            Brand = "Iveco";
            Model = "FBI";
            Speed = 0;
            Distance = 0;
        }
        public void NextPoint()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\tGo next");
        }
        public void Finish()
        {
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance} Finish");
        }

    }
    
    class Game : Car
    {
        public void Racing(string racing)
        {
            Sport sport = new Sport();
            Passenger passenger = new Passenger();
            Truck truck = new Truck();
            Bus bus = new Bus();
                                    
            Random rand = new Random();
            while (sport.Distance < 1000 && passenger.Distance < 1000 && truck.Distance < 1000 && bus.Distance < 1000)
            {
                //ReadKey();
                sport.NextPoint();
                passenger.NextPoint();
                truck.NextPoint();
                bus.NextPoint();
                WriteLine();

                sport.Speed = rand.Next(10, 100);
                passenger.Speed = rand.Next(10, 100);
                truck.Speed = rand.Next(10, 100);
                bus.Speed = rand.Next(10, 100);
                sport.Distance += sport.Speed;
                passenger.Distance += passenger.Speed;
                truck.Distance += truck.Speed;
                bus.Distance += bus.Speed;
                               
            }
            if (sport.Distance > 1000)
            {
                sport.Finish();
            }
            else if (passenger.Distance > sport.Distance)
            {
                passenger.Finish();
            }
            else if (truck.Distance > passenger.Distance)
            {
                truck.Finish();
            }
            else if (bus.Distance > truck.Distance)
            {
                bus.Finish();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.Racing("Finish");
        }
    }
}


