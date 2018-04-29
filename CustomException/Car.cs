using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomException
{
    class Car
    {
        //  Константа  для  представления  максимальной  скорости,
        public const int MaxSpeed = 100;
        //  Свойства  автомобиля.
        public int CurrentSpeed { get; set; }
        public string PetName { get; set; }
        //  Не  вышел  ли  автомобиль  из  строя?
        private bool carIsDead;
        //  Автомобиль  имеет  радиоприемник,
        private Radio theMusicBox = new Radio();
        //  Конструкторы,
        public Car() { }
        public Car(string name, int speed)
        {
            CurrentSpeed = speed;
            PetName = name;
        }
        public void CrankTunes(bool state)
        {
            //  Делегировать  запрос  внутреннему  объекту.
            theMusicBox.TurnOn(state);
        }
        public void Accelerate(int delta)
        {
            if (carIsDead)
                Console.WriteLine("{0}  is  out  of  order...", PetName);
            else
            {
                CurrentSpeed += delta;
                if (CurrentSpeed >= MaxSpeed)
                {
                    carIsDead = true;
                    CurrentSpeed = 0;
                    CarIsDeadException ex = new CarIsDeadException(string.Format("{0}  has  overheated!", PetName), 
                        "You  have  а  lead  foot", DateTime.Now);
                    ex.HelpLink = "http://www.CarsRUs.com";
                    throw ex;
                }
                else
                    Console.WriteLine("=>  CurrentSpeed  = {0}", CurrentSpeed);
            }
        }
    }
}
