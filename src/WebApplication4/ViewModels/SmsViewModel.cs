using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication4.ViewModels
{
    public class SmsViewModel
    {
        public string sms_to { get; set; }
        public string sms_from { get; set; }
        public string sms_text { get; set; }
        public string sms_date { get; set; }
        public string username { get; set; }
        public string MsgId { get; set; }
    }
}
//sms_to numer telefonu odbiorcy
//sms_from numer telefonu nadawcy
//sms_text treść wiadomości
//sms_date czas w postaci unixtime pobrany z SMS'a
//username nazwa użytkownika(login) do którego wiadomość została przydzielona
//MsgId