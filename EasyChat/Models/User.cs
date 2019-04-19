using System;
using System.Collections.Generic;
using System.Text;

namespace EasyChat.Models
{
   public class User
    {
        public string Username { get; set; }
        public string TargetUsername { get; set; }
        public string Text { get; set; }
    }
}
