

using System;
using System.Threading;

namespace CircularQueue
{
    public class FourwayStop
    {
        //Private variables
        private DynamicQueue<string> qA, qB, qC, qD, cQ;
        private string[] cars = new string[] {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M",
                                              "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z" };
        private int nCars = 0;
        private readonly object lock_ = new object();
        private string carsCrossed = "";
        private bool isRunning = true;

        int iTracker = 0;
        //Constructor
        public FourwayStop()
        {
            //Header
            Console.Clear();
            Console.WriteLine();
            string header = "FOUR-WAY STOP";
            Console.WriteLine("\t" + header);
            Console.WriteLine("\t" + "".PadRight(header.Length, '='));
            Console.WriteLine();

            //Initialise the continuous enqueuing of cars in the four entry queues
            //... To be completed
            qA = new DynamicQueue<string>();
            qB = new DynamicQueue<string>();
            qC = new DynamicQueue<string>();
            qD = new DynamicQueue<string>();

            new Thread(() => Enqueue(qA, "A", 6, 1000)).Start();
            new Thread(() => Enqueue(qB, "B", 7, 1400)).Start();
            new Thread(() => Enqueue(qC, "C", 8, 1200)).Start();
            new Thread(() => Enqueue(qD, "D", 9, 900)).Start();


            //Cross the intersection
            cQ = new CircularQueue<string>(4);

            new Thread(() => Intersection()).Start();
            //Back to menu
            Console.SetCursorPosition(0, 12);
            Console.Write("\n\tPress any key to return to the menu ... ");
            Console.ReadKey();

            isRunning = false; //Change running status
            Thread.Sleep(3000); //Give opportunity for running loops to finish
            Console.Clear();
        } //FourwayStop

        private void Enqueue(DynamicQueue<string> q, string label, int y, int msSleep)
        {
            //Continuously enqueue the queue with the next car
            while (isRunning)
            {
                
                lock (lock_) //We need a lock because nCars can be changed in other queues
                {
                    //...
                    if (iTracker >= cars.Length)
                        iTracker = 0;
                    q.Enqueue(cars[iTracker]);
                    nCars++;
                    WriteLine(8, y, label + ": " + string.Join(", ", q.ToArray()));
                    iTracker++;
                } //Release lock
                Thread.Sleep(msSleep);
            } //while (true)
        } //Enqueue

        private void Intersection()
        {
            WriteLine(8, 5, "Cars waiting");

            //Continuously dequeue the four entry queues and enqueue the intersection queue
            while (isRunning)
            {
                CrossIntersection(qA, "A", 6);
                CrossIntersection(qB, "B", 7);
                CrossIntersection(qC, "C", 8);
                CrossIntersection(qD, "D", 9);

            } //while (true)

        } //CrossIntersection

        private void CrossIntersection(DynamicQueue<string> q, string label, int y)
        {
            //Wait a while before processing (The previous car is not yet on the other side of the intersection)
            Thread.Sleep(1000);

            //Hghlight current row
            Console.SetCursorPosition(1, 6); Console.Write("      ");
            Console.SetCursorPosition(1, 7); Console.Write("      ");
            Console.SetCursorPosition(1, 8); Console.Write("      ");
            Console.SetCursorPosition(1, 9); Console.Write("      ");
            Console.SetCursorPosition(1, y); Console.Write("     *");

            //Dequeue entry queue and enqueue intersection queue 
            lock (lock_)
            {
                //Dequeue the entry queue
                //Enqueue the intersection queue
                //Dequeue the intersection queue
                //Append to carsCrossed
                string car = q.Dequeue();
                cQ.Enqueue(car);
                carsCrossed += cQ.Dequeue() + " ";

                Console.SetCursorPosition(2, 3); Console.Write(new string(' ', Console.WindowWidth - 4));
                Console.SetCursorPosition(2, 3); Console.Write("\tCrossed: " + carsCrossed);

                //Waiting queue
                WriteLine(8, y, label + ": " + string.Join(", ", q.ToArray()));

            }//lock

        } //CrossIntersection

        private static void WriteLine(int x, int y, string s)
        {
            //Clear line
            Console.SetCursorPosition(x, y); Console.Write(new string(' ', Console.WindowWidth - x));
            //Overwite line 
            Console.SetCursorPosition(x, y); Console.Write(s);
        } //WriteLine


    } //class Fourway stop





}

