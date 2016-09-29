using InteractiveSpeechApplication.Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// The IteractiveSpeechApplication itself.
/// Author: Han
/// Date: 9/28/2016 11:40 AM
/// </summary>
namespace InteractiveSpeechApplication
{
    class SpeechInteractor
    {
        public SpeechInteractor() { }
        /// <summary>
        /// "Run" method
        /// </summary>
        public void run()
        {
            Log log = new Log();
            string res = "";
            do
            {
                Session session = workflow();
                log.recordSession(session);
                Console.WriteLine();
                Console.WriteLine("Do you want to run it again?");
                Console.WriteLine("Press Y to run it again; Press other key to quit the dialog.");
                ConsoleKeyInfo result = Console.ReadKey();
                res = result.KeyChar.ToString();
            } while (ignoreCaseEqual(res, "Y"));

            log.generateXML();
        }


        /// <summary>
        /// "work-flow" is the simulation to reproduce the scenario.
        /// It might be called multiple times in "run" method.
        /// </summary>
        private static Session workflow()
        {

            //Initialize a new session
            Session session = new Session();

            //Introduction section
            Console.WriteLine();
            introductionSection(session);

            //Question section
            //Set "ask_answerAllQuestions" as local variable for later use.
            string ask_answerAllQuestions = questionSection(session);

            DateTime currentTime = DateTime.Now;

            //Transfer section
            transferSection(session, ask_answerAllQuestions);

            return session;
        }

        /// <summary>
        /// Introduction Section
        /// </summary>
        /// <param name="session"></param>
        private static void introductionSection(Session session)
        {
            //Say hello
            session.SAY(DataElement.S_Hello);

            //Ask for user name
            string user_name = session.ASK(DataElement.P_Name);

            //Assign user name to session
            session.user_name = user_name;

            //Ask if user wants to answer questions
            string ask_question = session.ASK(DataElement.P_Questions);

            //If user input "no"
            if (ignoreCaseEqual(ask_question, DataElement.NO))
            {

                string ask_busy = session.ASK(DataElement.P_Busy);
                //If user is busy
                if (ignoreCaseEqual(ask_busy, DataElement.YES))
                {
                    session.SAY(DataElement.S_TooBad);
                }
                else
                {
                    session.ASK(DataElement.P_Problem);
                    session.SAY(DataElement.S_OhStopIt);
                }
            }
        }

        /// <summary>
        /// Question Section
        /// </summary>
        /// <param name="session"></param>
        /// <param name="ask_answerAllQuestions"></param>
        private static string questionSection(Session session)
        {
            string ask_answerAllQuestions = "";
            session.SAY(DataElement.S_Questions);

            //Ask user the interview length
            string ask_length = session.ASK(DataElement.P_InterviewLength);

            //Check length
            int length;
            if (int.TryParse(ask_length, out length))
            {
                if (length >= 0 && length <= 30)
                {
                    session.SAY(DataElement.S_LessThan30);
                }
                else if (length > 30 && length <= 60)
                {
                    session.ASK(DataElement.P_WentWell);
                }
                else
                {
                    session.SAY(DataElement.S_OverHour);
                }
            }
            else
            {
                session.ASK(DataElement.P_WentWell);
            }
            string ask_doYouRemember = session.ASK(DataElement.P_RememberInterviewers);
            //If user cannot remember
            if (ignoreCaseEqual(ask_doYouRemember, DataElement.NO))
            {
                //Ask user whether interviewer forgot to self-introduce or not
                string ask_forgotIntroduce = session.ASK(DataElement.P_ForgotToIntroduce);

                if (ignoreCaseEqual(ask_forgotIntroduce, DataElement.NO))
                {
                    //Ask user how she/he thinks if the company should or shouldn't hire her/him
                    string ask_shouldHire = session.ASK(DataElement.P_ShouldHire);
                    if (ignoreCaseEqual(ask_shouldHire, DataElement.NO))
                    {
                        session.SAY(DataElement.S_ShouldHire_N);
                    }
                    else
                    {
                        session.SAY(DataElement.S_ShouldHire_Y);
                    }
                }
                else
                {
                    //Someone's in trouble...
                    session.SAY(DataElement.S_ForgotToIntroduce_Y);
                }
            }
            else
            {
                //Ask user whom she/he spoke to
                string ask_whomSpoke = session.ASK(DataElement.P_WhomSpokeTo);
                ask_answerAllQuestions = session.ASK(DataElement.P_AnsweredQuestions);
                if (ignoreCaseEqual(ask_answerAllQuestions, DataElement.YES))
                {
                    session.SAY(DataElement.S_Great);
                }
            }
            return ask_answerAllQuestions;
        }

        /// <summary>
        /// Transfer Section
        /// </summary>
        private static void transferSection(Session session, string ask_answerAllQuestions)
        {
            DateTime currentTime = DateTime.Now;
            //Different days in a week have different office hours tho...
            if (
                (currentTime.DayOfWeek >= DayOfWeek.Monday && currentTime.DayOfWeek <= DayOfWeek.Thursday &&
                isTimeBetween(currentTime, new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)))
                ||
                (currentTime.DayOfWeek == DayOfWeek.Friday &&
                isTimeBetween(currentTime, new TimeSpan(8, 0, 0), new TimeSpan(17, 30, 0)))
                ||
                (currentTime.DayOfWeek == DayOfWeek.Saturday &&
                isTimeBetween(currentTime, new TimeSpan(12, 30, 0), new TimeSpan(17, 0, 0))))
            {
                //Use value of "ask_answerAllQuestions" to determine which branch it has to go to
                if (ignoreCaseEqual(ask_answerAllQuestions, DataElement.YES))
                {
                    string ask_transferToSpeak = session.ASK(DataElement.P_TransferToSpeak);
                    if (ignoreCaseEqual(ask_transferToSpeak, DataElement.NO))
                    {
                        session.SAY(DataElement.S_Alright);
                        //Go to end call
                        endCallSection(session);
                    }
                    else
                    {
                        session.SAY(DataElement.S_Transferring);
                        //Transfer
                        session.transfer(true);
                        //Hang up
                    }

                }
                else
                {
                    string ask_transferWithQuestions = session.ASK(DataElement.P_TransferWithQuestions);
                    if (ignoreCaseEqual(ask_transferWithQuestions, DataElement.NO))
                    {
                        session.SAY(DataElement.S_Alright);
                        //Go to end call
                        endCallSection(session);
                    }
                    else
                    {
                        session.SAY(DataElement.S_Transferring);
                        //Transfer
                        session.transfer(true);
                        //Hang up
                    }
                }

            }
            //No more works...
            else
            {
                session.transfer(false);
                session.SAY(DataElement.S_OutsideHours);
                //Go to end call
                endCallSection(session);
            }
        }

        /// <summary>
        /// End Call Section
        /// </summary>
        /// <param name="session"></param>
        /// <param name="currentTime"></param>
        private static void endCallSection(Session session)
        {
            DateTime currentTime = DateTime.Now;
            if (currentTime.TimeOfDay >= new TimeSpan(5, 0, 0) && currentTime.TimeOfDay < new TimeSpan(16, 0, 0))
            {
                session.SAY(DataElement.S_Goodbye_AM);
            }
            else if (currentTime.TimeOfDay >= new TimeSpan(16, 0, 0) && currentTime.TimeOfDay < new TimeSpan(20, 0, 0))
            {
                session.SAY(DataElement.S_Goodbye_PM);
            }
            else
            {
                session.SAY(DataElement.S_Goodbye_PM2);
            }
        }

        /// <summary>
        /// Check whether current time is in office hours.
        /// 
        /// </summary>
        /// <param name="currentTime"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <returns></returns>
        private static bool isTimeBetween(DateTime currentTime, TimeSpan startTime, TimeSpan endTime)
        {
            return currentTime.TimeOfDay >= startTime && currentTime.TimeOfDay <= endTime;
        }

        /// <summary>
        /// Comparing two string ignoring cases.
        /// Generally for checking user's input.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private static bool ignoreCaseEqual(string a, string b)
        {
            return a.Equals(b, StringComparison.CurrentCultureIgnoreCase);
        }


    }
}
