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
    public delegate void StartDelegate(string massage);
    public abstract class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Speed { get; set; }
        public int Distance { get; set; }

        public void Start()
        {
            WriteLine("\t\t\t\t\t***Start Game***");
        }
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
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\t\t\t***Finish***");
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
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\t\t\t***Finish***");
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
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\t\t\t***Finish***");
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
            WriteLine($"{Brand} {Model}\tSpeed:{Speed}\tDistance:{Distance}\t\t\t***Finish***");
        }
    }
    class StartEvent : Car
    {
        public event StartDelegate startEvent;
        public void Start(string massage)
        {
            if (startEvent != null)
            {
                startEvent(massage);
            }
                     
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
            else if (passenger.Distance > 1000)
            {
                passenger.Finish();
            }
            else if (truck.Distance > 1000)
            {
                truck.Finish();
            }
            else if (bus.Distance > 1000)
            {
                bus.Finish();
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StartEvent start = new StartEvent();
            start.Start();
            Game game = new Game();
            game.Racing("Finish");
        }
    }
}


