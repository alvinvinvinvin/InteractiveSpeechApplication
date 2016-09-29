using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InteractiveSpeechApplication.Module
{
    /// <summary>
    /// All that static data for the program's use.
    /// </summary>
    static class DataElement
    {
        public static string S_Hello = "S_Hello";
        public static string S_TooBad = "S_TooBad";
        public static string S_OhStopIt = "S_OhStopIt";
        public static string S_Questions = "S_Questions";
        public static string S_LessThan30 = "S_LessThan30";
        public static string S_OverHour = "S_OverHour";
        public static string S_ForgotToIntroduce_Y = "S_ForgotToIntroduce_Y";
        public static string S_ShouldHire_Y = "S_ShouldHire_Y";
        public static string S_ShouldHire_N  = "S_ShouldHire_N";
        public static string S_Great  = "S_Great";
        public static string S_Transferring  = "S_Transferring";
        public static string S_Alright  = "S_Alright";
        public static string S_OutsideHours  = "S_OutsideHours";
        public static string S_Goodbye_AM  = "S_Goodbye_AM";
        public static string S_Goodbye_PM  = "S_Goodbye_PM";
        public static string S_Goodbye_PM2  = "S_Goodbye_PM2";
        public static string P_Name  = "P_Name";
        public static string P_Questions  = "P_Questions";
        public static string P_Busy  = "P_Busy";
        public static string P_Problem  = "P_Problem";
        public static string P_InterviewLength  = "P_InterviewLength";
        public static string P_WentWell  = "P_WentWell";
        public static string P_RememberInterviewers  = "P_RememberInterviewers";
        public static string P_WhomSpokeTo  = "P_WhomSpokeTo";
        public static string P_ForgotToIntroduce  = "P_ForgotToIntroduce";
        public static string P_ShouldHire  = "P_ShouldHire";
        public static string P_AnsweredQuestions  = "P_AnsweredQuestions";
        public static string P_TransferWithQuestions  = "P_TransferWithQuestions";
        public static string P_TransferToSpeak  = "P_TransferToSpeak";
        public static string YES = "YES";
        public static string NO = "NO";

        public static string get_value_from_Says_Conversation_Library(string key)
        {
            string value;
            if (Says_Conversation_Library.TryGetValue(key, out value))
            {
                return value;
            }
            return value;
        }
        private static Dictionary<string, string> Says_Conversation_Library = new Dictionary<string, string>
        {
            { S_Hello, "Hello, this is Eliza Corp calling." },
            { S_TooBad,"Too bad..." },
            { S_OhStopIt, "Oh stop it..." },
            { S_Questions, "Great! The following questions are about the interview process you just went through."},
            { S_LessThan30, "That’s a pretty short interview..." },
            { S_OverHour, "That must have been brutal..." },
            { S_ForgotToIntroduce_Y, "O-o, someone’s in trouble." },
            { S_ShouldHire_Y, "We’ll see about that..." },
            { S_ShouldHire_N, "Don’t be so hard on your self. Interviews can be stressful." },
            { S_Great, "Great!" },
            { S_Transferring, "Transferring now..." },
            { S_Alright, "Alright..." },
            { S_OutsideHours, "If you have any questions about the interview please give us a call." },
            { S_Goodbye_AM, "We hope to be seeing you soon. Good luck and have a good day" },
            { S_Goodbye_PM, "We hope to be seeing you soon. Good luck and have a good evening" },
            { S_Goodbye_PM2, "We hope to be seeing you soon. Good luck and have a good night" },
            
        };

        public static string get_value_from_Asks_Conversation_Library(string key)
        {
            string value;
            if (Asks_Conversation_Library.TryGetValue(key, out value))
            {
                return value;
            }
            return value;
        }

        private static Dictionary<string, string> Asks_Conversation_Library = new Dictionary<string, string>
        {
            { P_Name, "What is your name?" },
            { P_Questions, "may I ask you a few questions?" },
            { P_Busy, "Are you too busy to answer my questions?" },
            { P_Problem, "Well what is the problem then?" },
            { P_InterviewLength, "How long did the interview take? " },
            { P_WentWell, "Do you think it went well? " },
            { P_RememberInterviewers, "Do you remember whom you spoke with? " },
            { P_WhomSpokeTo, "Whom did you speak with? " },
            { P_ForgotToIntroduce, "Did the interviewers forget to introduce them selves?" },
            { P_ShouldHire, "And you think we should hire you? " },
            { P_AnsweredQuestions, "Did they answer all your questions? " },
            { P_TransferWithQuestions, "Would you like to be transferred to Eliza so that someone there could answer your questions? " },
            { P_TransferToSpeak, "Would you like to be transferred to Eliza so that you could speak to someone there?" },

        };

        public static string get_value_from_Asks_NAME_Matching_Dictionary(string key)
        {
            string value;
            if (Asks_NAME_Matching_Dictionary.TryGetValue(key, out value))
            {
                return value;
            }
            return value;
        }

        private static Dictionary<string, string> Asks_NAME_Matching_Dictionary = new Dictionary<string, string>
        {
            { P_Name,"NAME" },
            { P_Questions,"DO_YOU_MIND_QUESTIONS" },
            { P_InterviewLength,"INTERVIEW_LENGTH" },
            { P_RememberInterviewers,"REMEMBER_INTERVIEWERS" },
            { P_WhomSpokeTo,"WHO_INTERVIEWED" },
            { P_AnsweredQuestions,"ANSWERED_ALL" },
        };
    }
}
