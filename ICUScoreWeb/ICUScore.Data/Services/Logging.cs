using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ICUScore.Data.Services
{   
    public class Logging
    {
        private DateTime _dateOfLog;
        private string _eventTitle;
        private string _eventDetails;
        private Boolean _eventEmail;
        private string _fileLocation;
        public DateTime DateOfLog { get => _dateOfLog; set => _dateOfLog = value; }
        public string EventTitle { get => _eventTitle; set => _eventTitle = value; }
        public string EventDetails { get => _eventDetails; set => _eventDetails = value; }
        public bool EventEmail { get => _eventEmail; set => _eventEmail = value; }
        public string FileLocation { get => _fileLocation; set => _fileLocation = value; }

        public Logging()
        {

        }

        public Logging(DateTime timestampLog,string title,string details)
        {
            this.DateOfLog = timestampLog;
            this.EventTitle = title;
            this.EventDetails = details;
        }

        public void LogAction()
        {
            FileLocation = $"ScoreWebLog_{DateOfLog.ToShortDateString()}.txt";
            try
            {
                using(StreamWriter writeFile = new StreamWriter(FileLocation, true))
                {
                    writeFile.WriteLine($"{DateOfLog.ToString()} : {EventTitle}");
                    writeFile.WriteLine($"{EventDetails}");
                    writeFile.WriteLine(Environment.NewLine);
                }
                if(Debugger.IsAttached)
                {
                    LogActionEmail();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        public void LogActionEmail()
        {
            //Hook in emails to send
        }

       }
}
