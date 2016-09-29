using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication.Module
{
    class SAY : Prompt
    {
        public SAY() { }

        public SAY(string name, string content) : base(name, content)
        {
        }

        public SAY(string p_name, string content, string user_name)
        {
            P_name = p_name;
            CONTENT = content;
            USER_NAME = user_name;
            RECORD = "{" + P_name + "} " + CONTENT + ", {" + user_name + "}" + user_name + ".";
        }
    }
}
