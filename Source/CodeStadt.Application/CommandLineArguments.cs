using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace CodeStadt.Application
{

    /// <summary>
    /// This class converts command line arguments into something that can be used by the application
    /// </summary>
    public class CommandLineArguments
    {
        public IEnumerable<string> Assemblies { get; set; }
       
        public CommandLineArguments(string [] args)
        {
            ProcessArguments(args);
        }


        private void ProcessArguments(string[] args)
        {
            for (int i = 0; i < args.Length; i = i + 2)
            {
                //evil switch
                string key = args[i];
                string value = args[i + 1];
                switch (key)
                {
                    case "-a":
                        ProcessA(value);
                        break;

                        //to process more arguments from the command line
                        //add more cases and process in a method
                        //TODO: consider how we handle default values
                }
            }
        }

        private void ProcessA(string value)
        {
            string [] assemblies = value.Split('|');

            //not a very tough check :-)
            Regex nameCheck  = new Regex(@"\w\.(dll|exe)$");

            List<string> finalList = new List<string>();


            foreach (string assem in assemblies)
            {
                if (nameCheck.IsMatch(assem))
                    finalList.Add(assem);
                else
                {
                    //should we report this?
                }
            }

            this.Assemblies = finalList;
        }
    
    }
}
