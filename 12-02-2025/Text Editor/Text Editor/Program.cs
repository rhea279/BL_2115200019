using System;


namespace Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            TextEditor editor = new TextEditor();
            while (true)
            {
                Console.WriteLine("\nText Editor with Undo/Redo");
                Console.WriteLine("1. Add Text State");
                Console.WriteLine("2. Undo");
                Console.WriteLine("3. Redo");
                Console.WriteLine("4. Display Current State");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter new text: ");
                        string text = Console.ReadLine();
                        editor.AddState(text);
                        break;
                    case 2:
                        editor.Undo();
                        break;
                    case 3:
                        editor.Redo();
                        break;
                    case 4:
                        editor.DisplayCurrentState();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        break;
                }
            }
        }
    }
    class State
    {
        public string Content;
        public State Prev;
        public State Next;

        public State(string content)
        {
            Content = content;
            Prev = null;
            Next = null;
        }
    }
    class TextEditor
    {
        private State currentState;
        private int historySize;
        private int stateCount;
        private State firstState;
        public TextEditor(int historySize = 10)
        {
            this.historySize = historySize;
            stateCount = 0;
            currentState = null;
            firstState = null;
        }
        //Add a new text state at the end of the list every time the user types or performs an action
        public void AddState(string content)
        {
            State newState = new State(content);
            newState.Prev = currentState;
            if (currentState != null)
            {
                currentState.Next = newState;
            }
            currentState = newState;
            stateCount++;
            if (firstState == null)
            {
                firstState = currentState;
            }

            // Clear redo history
            newState.Next = null;

            // Maintain history limit
            if (stateCount > historySize)
            {
                firstState = firstState.Next;
                if (firstState != null)
                {
                    firstState.Prev = null;
                }
                stateCount--;
            }
        }
        //Implement the undo functionality
        public void Undo()
        {
            if (currentState.Prev != null)
            {
                currentState = currentState.Prev;
            }
            else
            {
                Console.WriteLine("No more undo actions available.");
            }
        }
        //Implement the redo functionality
        public void Redo()
        {
            if (currentState.Next != null)
            {
                currentState = currentState.Next;
            }
            else
            {
                Console.WriteLine("No more redo actions available.");
            }
        }
        //Display the current state of the text
        public void DisplayCurrentState()
        {
            Console.WriteLine("Current State:");
            Console.WriteLine(currentState.Content);
        }

    }
}
