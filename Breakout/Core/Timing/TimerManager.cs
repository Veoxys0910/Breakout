using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Breakout.Core.Timing
{
    public class TimerManager
    {
        private Timer __timer;
        private Stopwatch __stopwatch;

        private long __previousTime;

        public TimerManager()
        {
            this.__timer = new Timer();
            this.__stopwatch = new Stopwatch();
        }

        public void toggleTimer()
        {
            if (this.__timer.Enabled)
            {
                this.stopTimer();
            }
            else
            {
                this.startTimer();
            }
        }

        public double getDeltaTime()
        {
            long currentTime = this.__stopwatch.ElapsedMilliseconds;
            double deltaTime = (currentTime - this.__previousTime) / 10.00f;

            this.__previousTime = currentTime;

            return deltaTime;
        }

        public void startTimer()
        {
            this.__timer.Start();
            this.__stopwatch.Start();

            this.__previousTime = this.__stopwatch.ElapsedMilliseconds;
        }

        public void stopTimer()
        {
            this.__timer.Stop();
            this.__stopwatch.Stop();
        }

        public void setTimerInterval(int p_interval)
        {
            this.__timer.Interval = p_interval;
        }

        public void addTimerTickListener(EventHandler p_listener)
        {
            this.__timer.Tick += p_listener;
        }
    }
}
