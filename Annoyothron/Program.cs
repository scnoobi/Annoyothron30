using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Media;

namespace BeAnnoyingEvery30Seconds
{
    class Program
    {


        //TODO: make the beeping only happen for 10 minutes then restart it.



        private static bool shouldIBeep = false;
        private static bool shouldIContinueAskingForPassword = false;
        static void Main(string[] args)
        {

            Thread sampleThread1 = new Thread(new ThreadStart(SampleThread1));
            sampleThread1.Start();
        }

        static void SampleThread1()
        {
            Thread beepThread = new Thread(new ThreadStart(BeepThread));
            beepThread.Start();
            while (true)
            {
                Thread.Sleep(30 * 1000 * 60);
                shouldIBeep = true;
                shouldIContinueAskingForPassword = true;
                while (shouldIContinueAskingForPassword)
                {
                    if (Console.ReadLine().ToLower() == "i looked away for 20 seconds")
                    {
                        shouldIContinueAskingForPassword = false;
                        shouldIBeep = false;
                    }
                }
            }
        }

        static void BeepThread()
        {
            while (true)
            {
                while (shouldIBeep)
                {
                    SystemSounds.Asterisk.Play();
                    Thread.Sleep(400);
                }
                Thread.Sleep(2000);
            }
        }
    }
}