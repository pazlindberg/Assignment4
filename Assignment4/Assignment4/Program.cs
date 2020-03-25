using System;
using System.Collections;
using System.Collections.Generic;

//some of this code should probably be generalised and whatnot - im not done and ill see how much thought i make into it or if i focus on other tasks when i works acc2specs

namespace Assignment4
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {

            while (true)
            {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()[0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            bool running = true;
            List<string> theList = new List<string>();

            do
            {
                Console.WriteLine("list has: ");

                foreach (var c in theList) Console.Write(c + "\t");

                Console.Write("\r\nenter +/-/q: ");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        break;
                    case '-':
                        theList.Remove(value);
                        break;
                    case 'q':
                    case 'Q':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("only use + or -");
                        break;
                }

            } while (running);
        }
        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            bool running = true;
            var queue = new Queue();
            do
            {
                Console.WriteLine("queue has: ");

                foreach (var c in queue) Console.Write(c + "\t");

                Console.Write("\r\nenter +/-/q: ");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        //theList.Add(value);
                        break;
                    case '-':
                        queue.Dequeue();
                        //theList.Remove(value);
                        break;
                    case 'q':
                    case 'Q':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("only use + or -");
                        break;
                }


            } while (running);

        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */
            bool running = true;
            var stack = new Stack();
            do
            {
                Console.WriteLine("stack has: ");

                foreach (var c in stack) Console.Write(c + "\t");

                Console.Write("\r\nenter +/-/q: ");
                string input = Console.ReadLine();
                char nav = input[0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        //theList.Add(value);
                        break;
                    case '-':
                        stack.Pop();
                        //theList.Remove(value);
                        break;
                    case 'q':
                    case 'Q':
                        running = false;
                        break;
                    default:
                        Console.WriteLine("only use + or -");
                        break;
                }


            } while (running);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            string testCase = "((}}";
            var lefts = new Stack<char>();
            bool incorrClose = false;

            foreach (var ch in testCase)
            {
                if(ch=='{'||ch=='('||ch=='['||ch=='<')
                {
                    lefts.Push(ch);
                }
                else if(ch=='}'||ch==')'||ch==']'||ch=='>')
                {

                    if(lefts.Count<1)
                    {
                        incorrClose = true;                      
                    }
                    else
                    {
                        var peeked = lefts.Peek();
                        lefts.Pop();
                        Console.WriteLine("{0}-{1}",peeked, ch);
                        if ((ch == ')' && peeked != '(')) { incorrClose = true; }
                        else if ((ch == ']' && peeked != '[')) { incorrClose = true; }
                        else if ((ch == '}' && peeked != '{')) { incorrClose = true; }
                        else if ((ch == '>' && peeked != '<')) { incorrClose = true; }
                        else { incorrClose = false; }

                    }
                }
                if (incorrClose) break; //out of loop in first error
            }

            Console.WriteLine(incorrClose);
        }

    }
}

