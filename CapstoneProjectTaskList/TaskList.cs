using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Text;

namespace CapstoneProjectTaskList
{
    
    class TaskList
    {
        //fields
        private string teamMember;
        private string taskDescription;
        private DateTime dueDate;
        private bool complete;

        //properties

        public string TeamMember
        {
            get { return teamMember; }
            set { teamMember = value; }
        }
        public string TaskDescription
        {
            get { return taskDescription; }
            set { taskDescription = value; }
        }
        public DateTime DueDate
        {
            get { return dueDate; }
            set { dueDate = value; }
        }
        public bool Complete
        {
            get { return complete; }
            set { complete = value; }
        }


        //constructor(s)

        public TaskList()
        {
            complete = false;
        }

        public TaskList(string argTeamMember, string argTaskDescription, DateTime argDueDate)
        {
            complete = false;
        }



        //methods


        





    }

    
}
