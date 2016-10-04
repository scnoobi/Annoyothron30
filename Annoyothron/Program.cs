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


        static float iHaveBeenBeepingForXSeconds = 0;
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
                //minutes    seconds   miliseconds
                Thread.Sleep(30 * 60 * 1000);
                BeepingState(true);
                while (shouldIContinueAskingForPassword)
                {
                    if (Console.ReadLine().ToLower() == "i looked away for 20 seconds")
                    {
                        BeepingState(false);
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
                    Thread.Sleep(250);
                    SystemSounds.Beep.Play();
                    Thread.Sleep(250);
                    SystemSounds.Exclamation.Play();
                    Thread.Sleep(28000);
                    iHaveBeenBeepingForXSeconds += 28000;
                    //minutes    seconds   miliseconds
                    if (iHaveBeenBeepingForXSeconds > 10* 60*1000)
                    {
                        iHaveBeenBeepingForXSeconds = 0;
                        BeepingState(false);
                        
                    }
                    
                }
                Thread.Sleep(2000);
            }
        }

        static void BeepingState(bool theState)
        {
            shouldIContinueAskingForPassword = theState;
            shouldIBeep = theState;
        }
    }
}