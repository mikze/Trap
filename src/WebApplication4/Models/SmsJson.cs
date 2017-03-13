using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication4.Models
{
    public class SmsJson
    {
        public int Id { get; set; }
        public int Battery { get; set; }
        public int Rats { get; set; }
        public string Communicat { get; set; }

        public void StringToJson(string str)
        {
            int dolar = 0;
            char sign = '#';

            string _id = "", _battery = "", _rats = "";

            foreach(char c in str)
            {
                
                if(dolar==1)  //do id
                {
                    if (c != sign)
                     _id += c;
                }
                if(dolar==2)
                {
                    if(c!=sign)
                    _rats += c;
                }
                if(dolar==3)
                {
                    if (c != sign)
                    _battery += c;
                }
                if (c == sign)
                {
                    dolar++;
                }
            }
            

            if(_id == "block")
            {
                Communicat = "BLOCKED";
            }


            Id = Convert.ToInt32(_id);
            Rats = Convert.ToInt32(_rats); // +1 bo smo wyslanie sms to szczur
            Battery = 0;

        }
    }
}
