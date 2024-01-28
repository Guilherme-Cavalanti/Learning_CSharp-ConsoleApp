using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ListPacks
{
    internal class TaskList
    {
        private List<Task> tasks;

        public TaskList()
        {
            tasks = new List<Task>();
        }
        public int TaskCount
        {
            get { return tasks.Count; }
        }
        public void PrintTaks()
        {
            if (tasks.Count > 0)
            {
                Console.WriteLine();
                foreach (var task in tasks)
                {
                    Console.WriteLine(task.ClassName);
                }
            }
            else { Console.WriteLine("\nLista Vazia"); }
        }
        public void InsertTask(Task task)
        {
            tasks.Add(task);
        }
        public void RemoveTask()
        {
            if (tasks.Count > 0)
            {
                while (true)
                {
                    this.PrintTaks();
                    Console.WriteLine($"Choose one to remove from 1 to {this.TaskCount} or type exit to quit.");
                    string taskChoice = Console.ReadLine();
                    if (taskChoice == "exit")
                    {
                        Console.WriteLine("Quitting...");
                        break;
                    }
                    int numberTask;
                    try
                    {
                        numberTask = int.Parse(taskChoice);
                        if (numberTask < 1 || numberTask > this.TaskCount)
                        {
                            Console.WriteLine("Invalid number...");
                            continue;
                        }
                        else
                        {
                            tasks.RemoveAt(numberTask);
                            Console.WriteLine($"Task number {numberTask} removed succesfully!");
                            break;
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Wrong input must be a number");
                    }
                }
            }
            else
            {
                Console.WriteLine("\nNo tasks to remove.");
            }
        }
        public void DoTask()
        {
            if (tasks.Count > 0)
            {
                switch(tasks[0].ClassName)
                {
                    case "Eat":
                        Console.WriteLine("\nYummy *eating sounds*\nThat was delicious!");
                        break;
                    case "Work":
                        Console.WriteLine("\n*You're doing your work...*\nFinally finished this part!");
                        break;
                    case "Sleep":
                        Console.WriteLine("\nZzZzZ *snores*\n*Wakes up* Im rested now =)");
                        break;
                }
                tasks.RemoveAt(0);
                Console.WriteLine("Task done succesfully");
            }
        }
        public void StartTaskCycle()
        {
            bool end = false;
            while (!end)
            {
                if (tasks.Count == 0) {
                    Console.WriteLine("\nNo tasks to be done!");
                    break;
                }
                Console.WriteLine($"\nThere are {tasks.Count} tasks(s) to be done.");
                Console.WriteLine("Type 1 to do the next task");
                Console.WriteLine("Type 2 to exit");
                string input = Console.ReadLine();
                switch(input)
                {
                    case "1":
                        DoTask();
                        break;
                    case "2":
                        Console.WriteLine("Quitting Task Cycle");
                        end = true;
                        break;
                    default:
                        Console.WriteLine("Must be 1 or 2");
                        break;
                }
            }
        }
    }

    internal class Task
    {
        private string className;
        public string ClassName {   
            get { return className; } 
            set { className = value; }
        }

        public void CreateTask(int n)
        {
            switch (n)
            {
                case 0:
                    ClassName = "Eat";
                    break;
                case 1:
                    className = "Work";
                    break;
                case 2:
                    className = "Sleep";
                    break;
            }
        }

    }
}
