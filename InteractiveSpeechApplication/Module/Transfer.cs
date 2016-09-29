using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication.Module
{
    class Transfer : Prompt
    {
        public Transfer() { }
        private DateTime DATE { get; set; }
        private DateTime CURRENT_TIME { get; set; }
        private bool VALID { get; set; }
        public Transfer(bool valid)
        {
            DATE = DateTime.Today;
            CURRENT_TIME = DateTime.Now;
            VALID = valid;
        }
        public string getDATE()
        {
            return DATE.ToString("D");
        }
        public string getCurrentTime()
        {
            return CURRENT_TIME.ToString("hh:mm:ss");
        }
        public string getValid()
        {
            if (VALID) return "TRUE";
            else return "FALSE";
        }
    }
}
