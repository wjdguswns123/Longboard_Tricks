using System.Diagnostics;

public static class Timer
{
    static Stopwatch watch = new Stopwatch();

    public static void Start()
    {
        watch.Reset();
        watch.Start();
    }

    public static void Stop()
    {
        watch.Stop();
    }

    public static float GetTime()
    {
        return watch.ElapsedMilliseconds;
    }
}
