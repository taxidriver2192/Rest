using System;

namespace lib
{
    public class Mesaurement
    {
        //Instansfelter
        private int _pressure;
        private int _humidity;
        private int _temperature;
        private int _time;

        public Mesaurement()
        {
        }

        public Mesaurement(int id, int pressure, int humidity, int temperature, int time)
        {
            Id = id;
            Pressure = pressure;
            Humidity = humidity;
            Temperature = temperature;
            Time = time;
        }

        //Properties defineret og der er tilføjet property test der tester om den opfylder de krav der er tilføjet
        public int Id
        {
            get; set;
        }

        public int Pressure 
        { 
            get => _pressure; set 
            {
                _pressure = value;
            } 
        }
        public int Humidity
        {
            get => _humidity; set
            {
                _humidity = value;
            }
        }
        public int Temperature
        {
            get => _temperature; set
            {
                _temperature = value;
            }
        }

        public int Time
        {
            get => _time; set
            {
                _time = value;
            }
        }

        public override string ToString()
        {
            return $"{nameof(_pressure)}: {_pressure}, {nameof(_humidity)}: {_humidity}, {nameof(_temperature)}: {_temperature}, {nameof(_time)}: {_time}, {nameof(Id)}: {Id}, {nameof(Pressure)}: {Pressure}, {nameof(Humidity)}: {Humidity}, {nameof(Temperature)}: {Temperature}, {nameof(Time)}: {Time}";
        }
    }
}
