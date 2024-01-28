using System;
using ListPacks;
using Task = ListPacks.Task;
using System.Threading.Tasks;

class Program
{   

    static void Main()
    {
        TaskList lista = new TaskList();

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("\nTask Manager");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Remove Task");
            Console.WriteLine("4. Do tasks");
            Console.WriteLine("5. Clear Console");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    if (lista.TaskCount == 6)
                    {
                        Console.WriteLine("\nMax length of 6 reached!");
                        continue;
                    }
                    int n = AddTask();
                    if(n == 3)
                    {
                        Console.WriteLine("Invalid Task, Restarting...");
                        continue;
                    }
                    Task task = new Task();
                    task.CreateTask(n);
                    lista.InsertTask(task);
                    Console.WriteLine("\nTask added");
                    break;
                case "2":
                    lista.PrintTaks();
                    break;
                case "3":
                    lista.RemoveTask();
                    break;
                case "4":
                    lista.StartTaskCycle();
                    break;
                case "5":
                    Console.Clear();
                    break;
                case "6":
                    exit = true;
                    Console.WriteLine("\nQuitting");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please enter a number from 1 to 5.");
                    break;
            }
        }
    }
    static int AddTask()
    {
        Console.WriteLine("\nWhich Task:");
        Console.WriteLine("0. Eat");
        Console.WriteLine("1. Work");
        Console.WriteLine("2. Sleep");
        Console.WriteLine("Enter task:");
        string task = Console.ReadLine();
        switch(task)
        {
            case "0":
                return 0;
            case "1":
                return 1;
            case "2":
                return 2;
            default:
                Console.WriteLine("Invalid Input!");
                return 3;
        }
    }
}
