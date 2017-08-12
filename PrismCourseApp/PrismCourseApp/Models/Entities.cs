using Prism.Mvvm;
using System.Collections.Generic;

namespace PrismCourseApp.Models
{
    public class Coord : BindableBase
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }
    [Newtonsoft.Json.JsonArray()]
    public class Weather : BindableBase
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
    
    public class Main : BindableBase
    {
        private string _temp;
        public string temp
        {
            get { return _temp; }
            set { SetProperty(ref _temp, value); }
        }
        private string _pressure;
        public string pressure
        {
            get { return _pressure; }
            set { SetProperty(ref _pressure, value); }
        }
        private string _humidity;
        public string humidity
        {
            get { return _humidity; }
            set { SetProperty(ref _humidity, value); }
        }
        private string _temp_min;
        public string temp_min
        {
            get { return _temp_min; }
            set { SetProperty(ref _temp_min, value); }
        }
        private string _temp_max;
        public string temp_max
        {
            get { return _temp_max; }
            set { SetProperty(ref _temp_max, value); }
        }
    }
    public class Wind : BindableBase
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }
    public class Clouds : BindableBase
    {
        public int all { get; set; }
    }
    public class Sys : BindableBase
    {
        public int type { get; set; }
        public int id { get; set; }
        public double message { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }
    
    public class RootObject : BindableBase
    {
        //public Coord coord { get; set; }
        //public List<Weather> weather { get; set; }
        public string @base { get; set; }
        private Main _main;
        public Main main
        {
            get { return main; }
            set { SetProperty(ref _main, value); }
        }
        
        public int visibility { get; set; }
        /*public Wind wind { get; set; }
        public Clouds clouds { get; set; }*/

        private int _dt;
        public int dt
        {
            get { return _dt; }
            set { SetProperty(ref _dt, value); }
        }

        /*private Sys _sys;
        public Sys sys
        {
            get { return _sys; }
            set { SetProperty(ref _sys, value); }
        }*/
        private int _id;
        public int id
        {
            get { return _id; }
            set { SetProperty(ref _id, value); }
        }
        private string _name;
        public string name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }
        private int _cod;
        public int cod
        {
            get { return _cod; }
            set { SetProperty(ref _cod, value); }
        }
    }
}
