using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    enum ReportStatus 
    {   Approved, 
        RevisionRequired, 
        Pending 
    }
    internal class Report
    {
        private string text;
        private DateTime executionDate;
        private string performer;
        public ReportStatus status;

        public Report(string text, DateTime executionDate, string performer)
        {
            this.text = text;
            this.executionDate = executionDate;
            this.performer = performer;
            this.status = ReportStatus.Pending;
        }

        public string getText()
        {
            return text;
        }

        public void setText(string text)
        {
            this.text = text;
        }

        public DateTime getExecutionDate()
        {
            return executionDate;
        }

        public void setExecutionDate(DateTime executionDate)
        {
            this.executionDate = executionDate;
        }

        public string getPerformer()
        {
            return performer;
        }

        public void setPerformer(string performer)
        {
            this.performer = performer;
        }

        public ReportStatus getStatus()
        {
            return status;
        }

        public void setStatus(ReportStatus status)
        {
            this.status = status;
        }
    }
}
