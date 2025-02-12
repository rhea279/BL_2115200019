using System;
using System.Threading.Tasks;

namespace Task_Scheduler
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskScheduler taskScheduler = new TaskScheduler();
            while (true)
            {
                Console.WriteLine("\n--- Task Scheduler ---");
                Console.WriteLine("1. Add Task at Beginning");
                Console.WriteLine("2. Add Task at End");
                Console.WriteLine("3. Add Task at Specific Position");
                Console.WriteLine("4. Remove Task by Task ID");
                Console.WriteLine("5. View Current Task");
                Console.WriteLine("6. Move to Next Task");
                Console.WriteLine("7. Display All Task");
                Console.WriteLine("8. Search Task by Priority");
                Console.WriteLine("9. Exit");
                Console.Write("Enter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                    case 2:
                    case 3:
                        Console.Write("\nEnter Task ID: ");
                        int taskId = int.Parse(Console.ReadLine());

                        Console.Write("Enter Task Name: ");
                        string taskName = Console.ReadLine();

                        Console.Write("Enter Priority of Task: ");
                        int priority = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Enter Due Date : ");
                        DateTime dueDate = Convert.ToDateTime(Console.ReadLine());

                        if (choice == 1) taskScheduler.AddTaskAtBeginning(taskId, taskName, priority, dueDate);
                        else if (choice == 2) taskScheduler.AddAtEnd(taskId, taskName, priority, dueDate);
                        else
                        {
                            Console.Write("Enter Position: ");
                            int position = Convert.ToInt32(Console.ReadLine());
                            taskScheduler.AddAtPosition(taskId, taskName, priority, dueDate, position); ;
                        }
                        break;

                    case 4:
                        Console.Write("\nEnter Task Id to Remove: ");
                        taskScheduler.RemoveTask(Convert.ToInt32(Console.ReadLine()));
                        break;

                    case 5:
                        taskScheduler.ViewCurrentTask();
                        break;

                    case 6:
                        taskScheduler.MoveToNextTask();
                        break;

                    case 7:
                        taskScheduler.DisplayTasks();
                        break;

                    case 8:
                        Console.WriteLine("Enter Priority to Search: ");
                        taskScheduler.SearchByPriority(Convert.ToInt32(Console.ReadLine()));
                        break;
                    case 9: return;
                    default: Console.WriteLine("Invalid choice! Try again."); break;
                }
            }
        }
        class Task
        {
            public int TaskId;
            public string TaskName;
            public int Priority;
            public DateTime DueDate;
            public Task Next;
            public Task(int taskId, string taskName, int priority, DateTime dueDate)
            {
                TaskId = taskId;
                TaskName = taskName;
                Priority = priority;
                DueDate = dueDate;
                Next = this;
            }
        }
        class TaskScheduler
        {
            private Task head = null;
            private Task current = null;

            //Add a task at the beginning
            public void AddTaskAtBeginning(int taskId, string taskName, int priority, DateTime dueDate)
            {
                Task newTask = new Task(taskId, taskName, priority, dueDate);
                if (head == null)
                {
                    head = current = newTask;
                }
                else
                {
                    Task temp = head;
                    while (temp.Next != head)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = newTask;
                    newTask.Next = head;
                    head = newTask;

                }
                Console.WriteLine("Task added at beginning successfully");
            }
            //Add at the end
            public void AddAtEnd(int taskId, string taskName, int priority, DateTime dueDate)
            {

                Task newTask = new Task(taskId, taskName, priority, dueDate);
                if (head == null)
                {
                    head = current = newTask;
                }
                else
                {
                    Task temp = head;
                    while (temp.Next != head)
                    {
                        temp = temp.Next;
                    }
                    temp.Next = newTask;
                    newTask.Next = head;
                }
                Console.WriteLine("Task Added at the end successfully");
            }
            //Add at a specific position
            public void AddAtPosition(int taskId, string taskName, int priority, DateTime dueDate, int position)
            {
                Task newTask = new Task(taskId, taskName, priority, dueDate);
                if (position < 1)
                {
                    Console.WriteLine("Invalid Position Added");
                    return;
                }
                if (position == 1)
                {
                    head = current = newTask;
                    return;
                }
                Task temp = head;
                for (int i = 1; temp.Next != head && i < position - 1; i++)
                {
                    temp = temp.Next;
                }

                newTask.Next = temp.Next;
                temp.Next = newTask;
                Console.WriteLine("Task Added At Specified Position");
            }

            //Remove a task by Task ID.
            public void RemoveTask(int taskId)
            {
                if (head == null) Console.WriteLine("No Task Available");
                Task temp = head, prev = null;
                do
                {
                    if (temp.TaskId == taskId)
                    {
                        if (temp == head)
                        {
                            Task last = head;
                            while (last.Next != head) last = last.Next;
                            head = head.Next;
                            last.Next = head;
                            if (temp == current) { current = head; }
                        }
                        else
                        {
                            prev.Next = temp.Next;
                            if (temp == current) { current = prev.Next; }
                        }
                        Console.WriteLine($"Task {taskId} removed successfully");
                        return;
                    }
                    prev = temp;
                    temp = temp.Next;
                } while (temp != head);
                Console.WriteLine("Task Not Found");
            }
            //View the current task and move to the next task in the circular list.
            public void ViewCurrentTask()
            {
                if (current == null)
                {
                    Console.WriteLine("No tasks available.");
                    return;
                }
                Console.WriteLine($"\nCurrent Task: {current.TaskId} - {current.TaskName}, Priority: {current.Priority}, Due: {current.DueDate}");
            }

            public void MoveToNextTask()
            {
                if (current != null)
                {
                    current = current.Next;
                    ViewCurrentTask();
                }
            }

            //Display all tasks in the list starting from the head node.
            public void DisplayTasks()
            {
                if (head == null)
                {
                    Console.WriteLine("No Task Available");
                    return;
                }
                Task temp = head;
                Console.WriteLine("\nTask List:");
                while (temp != null)
                {
                    Console.WriteLine($"ID: {temp.TaskId} \nName: {temp.TaskName} \nPriority: {temp.Priority} \n Due Date: {temp.DueDate}");
                    temp = temp.Next;
                }
            }
            //Search for a task by Priority.
            public void SearchByPriority(int priority)
            {
                if (head == null)
                {
                    Console.WriteLine("No Task Found.");
                    return;
                }
                Task temp = head;
                while (temp != null)
                {
                    if (temp.Priority == priority)
                    {
                        Console.WriteLine($"ID: {temp.TaskId} \nName: {temp.TaskName} \nDue Date: {temp.DueDate}");
                        return;
                    }
                    temp = temp.Next;
                }
                if (temp == null)
                {
                    Console.WriteLine("Task Not Found");
                    return;
                }
            }
        }
    }
}
