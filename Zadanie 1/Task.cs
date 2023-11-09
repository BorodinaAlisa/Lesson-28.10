using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie_1
{
    internal class Task
    {
        private string description;
        private DateTime deadline;
        private string initiator;
        private string performer;
        public TaskStatus status;
        private List<Report> reports;

        public Task(string description, DateTime deadline, string initiator)
        {
            this.description = description;
            this.deadline = deadline;
            this.initiator = initiator;
            this.performer = null;
            this.status = TaskStatus.Assigned;
            this.reports = new List<Report>();
        }

        public void setPerformer(string performer)
        {
            this.performer = performer;
        }

        public void startWork()
        {
            this.status = TaskStatus.InProgress;
        }

        public void delegateTask(string newPerformer)
        {
            this.performer = newPerformer;
            this.status = TaskStatus.Assigned;
        }

        public void rejectTask()
        {
            this.performer = null;
            this.status = TaskStatus.Assigned;
        }

        public void addReport(Report report)
        {
            this.reports.Add(report);
        }

        public void reviewReport(bool approved)
        {
            if (this.reports.Count == 0)
            {
                throw new Exception("Нет репортов для этой задачи");
            }
            Report report = reports[reports.Count - 1];

            if (approved)
            {
                this.status = TaskStatus.Completed;
            }
            else
            {
                report.status = ReportStatus.RevisionRequired;
            }
        }
    }
}
