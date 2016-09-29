using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication.Module
{
    class ASK : Prompt
    {
        public ASK() { }
        public ASK(string name, string response, string p_name, string content)
        {
            NAME = name;
            RESPONSE = response;
            CONTENT = content;
            P_name = p_name;
            RECORD = "{" + P_name + "} " + CONTENT;
        }
        public ASK(string name, string response, string p_name, string content, string user_name)
        {
            NAME = name;
            RESPONSE = response;
            CONTENT = content;
            P_name = p_name;
            USER_NAME = user_name;
            RECORD = "{" + user_name + "} " + user_name + ", " + "{" + P_name + "} " + CONTENT;
        }
        private string NAME { get; set; }
        private string RESPONSE { get; set; }
        public string getName()
        {
            return NAME;
        }
        public string getResponse()
        {
            return RESPONSE;
        }
    }
}
