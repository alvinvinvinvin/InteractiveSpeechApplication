using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            SpeechInteractor si = new SpeechInteractor();
            si.run();
        }
    }
}
