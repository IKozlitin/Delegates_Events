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
    /*public delegate void ExamDelegate(string t);*/

    public delegate void StartDelegate(string massage);
    public delegate void GameDelegate(string massage);
       
   
    public abstract class Car
    {
        string _brand;
        string _model;
        int _speed;
        public Car(string brand, string model, int speed)
        {
            _brand = brand;
            _model = model;
            _speed = speed;
        }
        public override string ToString()
        {
            return $"{_brand}\t{_model}\tSpeed:{_speed}";
        }
        public void Start(string start)
        {
            WriteLine($"{_brand}\t{_model}\t{start}");
        }
               
        public void Game(string game)
        {
           WriteLine($"{_brand}\t{_model}\t{game}\t");
        }
    }

    class Sport : Car
    {
        double _engineVolume;

        public Sport(string brand, string model, int speed, double engineVolume) : base(brand, model, speed)
        {
            _engineVolume = engineVolume;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nVolume:{_engineVolume}";
        }
       
    }

    class Passenger : Car
    {
        string _carColor;

        public Passenger(string brand, string model, int speed, string carColor) : base(brand, model, speed)
        {
            _carColor = carColor;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nColor:{_carColor}";
        }
       
    }

    class Truck : Car
    {
        string _engineType;
        public Truck(string brand, string model, int speed, string engineType) : base(brand, model, speed)
        {
            _engineType = engineType;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nType:{_engineType}";
        }
       
    }

    class Bus : Car
    {
        int _numberOfSeats;
        public Bus(string brand, string model, int speed, int numberOfSeats) : base(brand, model, speed)
        {
            _numberOfSeats = numberOfSeats;
        }
        public override string ToString()
        {
            return base.ToString() + $"\nSeats:{_numberOfSeats}";
        }
        
    }
    
    class Organizer
    {
        public event StartDelegate startEvent;
        public void Start(string start)
        {
            startEvent(start);
        }
              
    }

    class Game
    {
        public event GameDelegate racingEvent;
        public void Racing(string racing)
        {                
            int carDistance = 0;
            Random rand = new Random();

            while (carDistance <= 1000)
            {
                int carSpeed = rand.Next(10, 100);
                carDistance += carSpeed;
                WriteLine($"Distance = {carDistance} Speed = {carSpeed}");
            }
            if (carDistance > 1000)
            {
                WriteLine($"{carDistance} WIN");
            }
            racingEvent(racing);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>
            {
               new Sport("Nissan", "GT-R", 300, 3.8),
               new Passenger("Kia", "Rio", 180, "Red"),
               new Truck("Dodge", "Ram", 160, "V8"),
               new Bus("Iveco", "FBI", 120, 45)
            };
            
            foreach (Car car in cars)
            {
                WriteLine(cars.ToString()); WriteLine();
            }
            //---------------------------------------------//
            Organizer organizer = new Organizer();
            foreach (Car item in cars)
            {
                organizer.startEvent += item.Start;
            }
            organizer.Start("Start Racing");
            //---------------------------------------------//

            Game racing = new Game();
            foreach (Car item in cars)
            {
               
                racing.racingEvent += item.Game;
                
            }
            racing.Racing("Finish");
        }

    }
}

        
