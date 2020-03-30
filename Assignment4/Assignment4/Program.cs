using System;
using System.Collections;
using System.Collections.Generic;

/*
 * Frågor/svar
 * 
 *  1.​​ Hur​ ​fungerar​ ​​stacken och​ ​​heapen?​ ​Förklara​ ​gärna​ ​med​ ​exempel​ ​eller​ ​skiss​ ​på​ ​dess grundläggande​ ​funktion
        SVAR: >>se illustrationen som är inkluderat i lösningen (assignment4real4.png)<< - 
        Två minnes-strukturer, kan man säga, varav stacken håller "koll" på egen hand. När minne inte används så frigörs det
        automatiskt etc, medan minne på heapen fortsätter att vara allokerat tills dess att garbage collector frigör det - så kallad 
        fragmentering/defragmentering. Stacken lyder under principen last in first out.

    2. ​​Vad​ ​är​ ​​Value Types ​respektive​ ​​Reference Types ​och​ ​vad​ ​skiljer​ ​dem​ ​åt?
        SVAR: Enkelt uttryck, i C#, är värdetyper structs medan referenstyper är classes, och där värdetyper kan lagras både på stack och
        medan referenstyper lagras på heapen i detta programmeringsspråk.

    3. Följande​ ​metoder​ ​(​se ​bild ​nedan)​ ​genererar​ ​olika​ ​svar.​ ​Den​ ​första​ ​returnerar​ ​3,​ ​den  andra​ ​returnerar​ ​4,​ ​varför?
        SVAR: Första exemplet demonstrerar en värdetyp med direkt access till värdet som variabeln används till, medan i det
        sedanare exemplet så är variablerna _egentligen_ referenser - alltså pekar y på samma instans som x, varpå båda modifieras
        vid ändringar. 

 * 
 */

namespace Assignment4
{
    class Program
    {
        private static readonly string[] ica = {    "ICA öppnar och kön till kassan är tom",
                                                    "Kalle ställer sig i kön",
                                                    "Greta ställer sig i kön",
                                                    "Kalle blir expedierad och lämnar kön",
                                                    "Stina ställer sig i kön",
                                                    "Greta blir expedierad och lämnar kön",
                                                    "Olle ställer sig i kön" };

        static void Main()
        {
            while (true)
            {
                Console.WriteLine("\n\nPlease navigate through the menu by inputting the number \n(1, 2, 3 ,4, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParanthesis" 
                    + "\n5. ReverseText"
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
                    case '5':
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive 
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }

        static void ExamineList()
        {
            /*
             2.​​ ​​ ​​ ​​ ​​ ​​ ​​ ​​När​ ​ökar​ ​listans​ ​kapacitet?​ ​(Alltså​ ​den​ ​underliggande​ ​arrayens​ ​storlek)
                        SVAR: när mer utrymme måste allokeras för att matcha listans storlek

            3.​​ ​​ ​​ ​​ ​​ ​​ ​​ ​​Med​ ​hur​ ​mycket​ ​ökar​ ​kapaciteten?
                        SVAR: 4

            4.​​ ​​ ​​ ​​ ​​ ​​ ​​ ​​Varför​ ​ökar​ ​inte​ ​listans​ ​kapacitet​ ​i​ ​samma​ ​takt​ ​som​ ​element​ ​läggs​ ​till?
                        SVAR: för att hela arrayen måste då allokeras om vilket inte blir effektivt

            5.​​ ​​ ​​ ​​ ​​ ​​ ​​ ​​Minskar​ ​kapaciteten​ ​när​ ​element​ ​tas​ ​bort​ ​ur​ ​listan?
                        SVAR: nej, då måste man trimexcess:a detta

            6.​​ ​​ ​​ ​​ ​​ ​​ ​​ ​​När​ ​är​ ​det​ ​då​ ​fördelaktigt​ ​att​ ​använda​ ​en​ ​egendefinierad​ ​​array​ istället​ ​för​ ​en​ ​lista? 
                        SVAR: när man vet antalet element på förhand och behöver optimera koden

            */
            bool running = true;
            List<string> theList = new List<string>();

            do
            {
                Console.WriteLine("list has (capacity:{0}: ",theList.Capacity);

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

        static void ExamineQueue()
        {
            bool running = true;
            var queue = new Queue();
                      
            foreach (var s in ica) queue.Enqueue(s);

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
                        break;
                    case '-':
                        queue.Dequeue();
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

        static void ExamineStack()
        {
            /*
             *  1.  Simulera ännu en gång ICA-kön på papper. Denna gång med en stack.
                    Varför är det inte så smart att använda en stack i det här fallet?
                        SVAR: lifo

                2.  Implementera en ReverseText-metod som läser in en sträng från användaren och
                    med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut
                    den omvända strängen till användaren. 

            */
            bool running = true;
            var stack = new Stack();

            foreach (var s in ica) stack.Push(s);

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
                        break;
                    case '-':
                        stack.Pop();
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
            string testCase = @"(()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );";
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
                    if (lefts.Count<1)
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
            Console.WriteLine("incorrect close=" +incorrClose);
        }

        private static void ReverseText()
        {
            Console.Write("text: ");
            string input = Console.ReadLine();
            if(!string.IsNullOrEmpty(input))
            {
                Stack<char> reversed = new Stack<char>();
                for(int i=0;i<input.Length;i++) reversed.Push(input[i]);

                Console.Write("reversed: ");
                foreach (var ch in reversed) Console.Write($"{ch}");
            }
            else Console.WriteLine("write something next time!");
        }
    }
}