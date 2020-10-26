using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace CapstoneProjectTaskList
{
    class Program
    {
        static void Main(string[] args)
        {
            bool runProgram = true;

            //empty list of TaskList Objects
            List<TaskList> taskLists = new List<TaskList>();

            //creating objects of TaskList to add to taskLists
            taskLists.Add(new TaskList
            { TeamMember = "Pin", TaskDescription = "Capstone Project", DueDate = DateTime.Parse("12/1/2020") });

            taskLists.Add(new TaskList
            { TeamMember = "Tom", TaskDescription = "Resume", DueDate = DateTime.Parse("12/9/2020") });

            taskLists.Add(new TaskList
            { TeamMember = "Joe", TaskDescription = "MVC Project", DueDate = DateTime.Parse("12/31/2020") });


            while (runProgram)
            {
                Console.WriteLine("Welcome to the Task Manager!");
                Console.WriteLine("   1. List tasks");
                Console.WriteLine("   2. Add tasks");
                Console.WriteLine("   3. Delete tasks");
                Console.WriteLine("   4. Mark task complete");
                Console.WriteLine("   5. Quit");
                Console.WriteLine();
                string inputChoice = GetUserInput("What would you like to do? ");
                inputChoice = ValidateUserChoice(inputChoice, "That is not an option!");

                if(inputChoice == "1")
                {
                    DisplayTasks(taskLists);
                }
                if(inputChoice == "2")
                {
                    AddTask(taskLists);
                }
                if (inputChoice == "3")
                {
                    DeleteTask(taskLists);
                }
                if (inputChoice == "4")
                {
                    MarkTaskComplete(taskLists);
                }
                if(inputChoice == "5")
                {
                    Console.Clear();
                    Console.WriteLine("Thank you. Have a nice day!");
                    runProgram = false;
                }

            }

        }

        //get user input
        public static string GetUserInput(string message)
        {
            Console.WriteLine(message);
            string UserInput = Console.ReadLine().ToLower().Trim();
            return UserInput;
        }

        //validate user input
        public static string ValidateUserChoice(string UserChoice, string message)
        {
            while (UserChoice != "1" && UserChoice != "2" && UserChoice != "3" && UserChoice != "4" && UserChoice != "5")
            {
                Console.WriteLine(message);
                UserChoice = Console.ReadLine().ToLower().Trim();
            }
            return UserChoice;

        }


        //display all tasks
        public static void DisplayTasks(List<TaskList> taskLists)
        {
            Console.Clear();
            Console.WriteLine($"No.\tTeam Member\tDue Date\tCompleted?\tTask Description");
            int i = 1;
            foreach (TaskList task in taskLists)
            {
                Console.WriteLine($"{i}\t{task.TeamMember}\t        {task.DueDate.ToShortDateString()}\t     {task.Complete}\t  {task.TaskDescription}");
                i++;
            }
            Console.WriteLine();
        }

        //add task
        public static void AddTask(List<TaskList> taskLists)
        {
            Console.Clear();
            bool validDate = false;
            Console.Write("Please input team member's name: ");
            string userName = Console.ReadLine();
            Console.Write("Please input the task to complete: ");
            string userTask = Console.ReadLine();

            while (validDate == false)
            {
                try
                {
                    Console.Write("Please input the due date in MM/DD/YYY format: ");
                    DateTime userDueDate = DateTime.Parse(Console.ReadLine());
                    taskLists.Add(new TaskList
                    { TeamMember = userName, TaskDescription = userTask, DueDate = userDueDate, Complete = false });
                    validDate = true;

                }
                catch (FormatException)
                {
                    Console.WriteLine("You did not enter a date or used the incorrect format!");
                }
            }
            Console.Clear();


        }

        //delete task
        public static void DeleteTask(List<TaskList> taskLists)
        {
            Console.Clear();
            DisplayTasks(taskLists);
            Console.WriteLine();
            Console.Write("Which task number would you like to delete? ");

            int userNumber = 0;
            bool validNumber = false;

            while(validNumber == false)
            {
                try
                {
                    userNumber = int.Parse(Console.ReadLine());

                    if (userNumber <= taskLists.Count && userNumber > 0)
                    {
                        validNumber = true;
                    }
                    else
                    {
                        Console.WriteLine($"Not in range!\nWhich task number would you like to delete? ");
                    }
                }
                catch(FormatException)
                {
                    Console.WriteLine("Please enter a number!");
                }

            }

            Console.WriteLine($"Task to delete: {taskLists[userNumber-1].TaskDescription}");
            Console.WriteLine("Are you sure (y/n)? ");
            string userYesNo = Console.ReadLine().Trim().ToLower();

            if (userYesNo == "y")
            {
                taskLists.RemoveAt(userNumber - 1);
            }

            Console.Clear();
        }

        //mark task complete
        public static void MarkTaskComplete(List<TaskList> taskLists)
        {
            Console.Clear();
            DisplayTasks(taskLists);
            Console.WriteLine();
            Console.Write("Which task number do you want to mark complete?" );

            int userNumber = 0;
            bool validNumber = false;

            while (validNumber == false)
            {
                try
                {
                    userNumber = int.Parse(Console.ReadLine());

                    if (userNumber <= taskLists.Count && userNumber > 0)
                    {
                        validNumber = true;
                    }
                    else
                    {
                        Console.WriteLine($"Not in range!\nWhich task number would you like to mark complete? ");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a number!");
                }

            }

            Console.WriteLine($"Task to mark complete: {taskLists[userNumber - 1].TaskDescription}");
            Console.WriteLine("Are you sure (y/n)? ");
            string userYesNo = Console.ReadLine().Trim().ToLower();

            if (userYesNo == "y")
            {
                taskLists[userNumber - 1].Complete = true;
            }

            Console.Clear();
        }

    }
}
