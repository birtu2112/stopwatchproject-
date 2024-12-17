// See https://aka.ms/new-console-template for more information
using System;
using System.Threading;
public class Stopwatch
{
    private TimeSpan timeElapsed;
    private bool isRunning;

    public delegate void StopwatchEventHandler(string message);
    public event StopwatchEventHandler OnStarted;
    public event StopwatchEventHandler OnStopped;
    public event StopwatchEventHandler OnReset;

    public TimeSpan TimeElapsed => timeElapsed;
    public bool IsRunning => isRunning;

    public void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
            OnStarted?.Invoke("Stopwatch Started!");
            Run();
        }
    }

    public void Stop()
    {
        if (isRunning)
        {
            isRunning = false;
            OnStopped?.Invoke("Stopwatch Stopped!");
        }
    }

    public void Reset()
    {
        isRunning = false;
        timeElapsed = TimeSpan.Zero;
        OnReset?.Invoke("Stopwatch Reset!");
    }

    private void Run()
    {
        while (isRunning)
        {
            Thread.Sleep(1000);
            timeElapsed = timeElapsed.Add(TimeSpan.FromSeconds(1));
        }
    }
};

