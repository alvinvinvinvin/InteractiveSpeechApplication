using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InteractiveSpeechApplication.Module;

namespace InteractiveSpeechApplication.Module
{
    class Session
    {
        public Session() { }
        private List<Prompt> promptsList = new List<Prompt>();
        public string user_name { get; set; }

        /// <summary>
        /// SAY function
        /// 
        /// The SAY function should receive one string parameter 
        /// with the information you want to “speak” to the user.
        /// When called it should output the passed in string to the command prompt.
        /// 
        /// </summary>
        public void SAY(string infor)
        {
            string output = "";
            output = DataElement.get_value_from_Says_Conversation_Library(infor);
            SAY say;
            //If the "say" is about the end call say, it will end with user's name.
            if (infor == DataElement.S_Goodbye_AM
                || infor == DataElement.S_Goodbye_PM
                || infor == DataElement.S_Goodbye_PM2)
            {
                say = new SAY(infor, output, user_name);
                CommonHelper.printLine(output+", "+ user_name);
            }
            else
            {
                say = new SAY(infor, output);
                CommonHelper.printLine(output);
            }
            record(say);
        }

        /// <summary>
        /// Parameter "question" is the key of getting corresponding sentence from DataElement.
        /// "NAME" is the corresponding "NAME" attribute in "ASK" tag in the log file.
        /// </summary>
        /// <param name="question"></param>
        /// <returns></returns>
        public string ASK(string question)
        {
            string output = "";
            string response = "";
            output = DataElement.get_value_from_Asks_Conversation_Library(question);
            string NAME = DataElement.get_value_from_Asks_NAME_Matching_Dictionary(question);
            ASK ask;
            //If the question is about asking user question, it will start with user's name
            if (question == DataElement.P_Questions)
            {
                
                CommonHelper.printLine(user_name+", "+output);
                response = CommonHelper.readLine();
                ask = new ASK(NAME, response, question, output, user_name);
            }
            else
            {
                
                CommonHelper.printLine(output);
                response = CommonHelper.readLine();
                ask = new ASK(NAME, response, question, output);
            }
            record(ask);
            return response;
        }

        public void transfer(bool valid)
        {
            Transfer transfer = new Transfer(valid);
            record(transfer);
        }

        private void record(SAY say)
        {
            if(say != null)
            promptsList.Add(say);
        }

        private void record(ASK ask)
        {
            if(ask != null)
            promptsList.Add(ask);
        }

        private void record(Transfer transfer)
        {
            if(transfer != null)
            promptsList.Add(transfer);
        }

        public List<Prompt> getPromptList()
        {
            return promptsList;
        }
    }
}
