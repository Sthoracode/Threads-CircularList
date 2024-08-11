

using System;
using System.Threading;

namespace CircularQueue
{
    partial class Client
    {
        static void Main(string[] args)
        {
            //Console window in the centre of the screen
            SetWindow(600, 500);

            //Show menu
            Menu();
        } //Main

        private static void Menu()
        {
            //Header
            CLS("TRAFFIC INTERSECTIONS");

            //Options
            Console.WriteLine("\tA. Traffic lights");
            Console.WriteLine("\tB. Four-way stop");
            Console.WriteLine("\tX. Exit");

            //Get user choice
            Console.Write("\n\tOption : ");
            char option = char.ToUpper(Console.ReadKey().KeyChar);

            //Branch out
            switch (option)
            {
                case 'A': TrafficLights(); Menu(); break;
                case 'B': new FourwayStop(); Menu(); break;
                case 'X': Environment.Exit(0); break;
                default: Menu(); break;
            } //switch
        } //Menu

        private static void TrafficLights()
        {
            CLS("TRAFFIC LIGHTS");

            //Initialise the circular queue
            CircularQueue<string> cQueue = new CircularQueue<string>(4);
            cQueue.Enqueue("Red"); cQueue.Enqueue("Green"); cQueue.Enqueue("Yellow"); cQueue.Enqueue("Blue");

            //Ten iterations 
            int i = 0;
            while (i < 10)
            {
                Console.WriteLine("\t" + cQueue.Next());
                Thread.Sleep(400);
                i++;
            } //while i < 10

            //Dequeue the current head
            Console.WriteLine("\n\t" + cQueue.Dequeue() + "\n");
            Thread.Sleep(400);

            //Another ten iterations
            i = 0;
            while (i < 10)
            {
                Console.WriteLine("\t" + cQueue.Next());
                Thread.Sleep(400);
                i++;
            } //while i < 10

            //Back to menu
            ReadKey();
        } //TrafficLights

    } //class Client



} //namespace