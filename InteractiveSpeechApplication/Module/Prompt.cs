using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication.Module
{
    class Prompt
    {
        public Prompt() { }
        public Prompt(string name, string content)
        {
            P_name = name;
            CONTENT = content;
            RECORD = "{" + P_name + "} " + CONTENT;
        }
        public string P_name { get; set; }
        public string CONTENT { get; set; }
        public string RECORD { get; set; } 
        public string USER_NAME { get; set; }
        public string toString() { return RECORD; }
    }
}
