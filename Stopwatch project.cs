using System;

class Program
{
    static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();

        stopwatch.OnStarted += message => Console.WriteLine(message);
        stopwatch.OnStopped += message => Console.WriteLine(message);
        stopwatch.OnReset += message => Console.WriteLine(message);

        Console.WriteLine("Press S to start, T to stop, or R to reset the stopwatch.");

        while (true)
        {
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.S:
                    stopwatch.Start();
                    break;
                case ConsoleKey.T:
                    stopwatch.Stop();
                    break;
                case ConsoleKey.R:
                    stopwatch.Reset();
                    break;
            }

            if (stopwatch.IsRunning)
            {
                Console.WriteLine($"Time Elapsed: {stopwatch.TimeElapsed}");
            }
        }
    }
}
