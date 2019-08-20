using System;
using System.Collections.Generic;
using System.Text;

namespace togos
{
    public class ApplicationRuntime
    {
        public static void StartApplication(string[] application)
        {
            //Run through the runtime and decide if the application needs to be run or not!
            foreach(string m in application)
            {
                //Check for application specific protocols
                CustomConsole.WarningLog("Initating Application Runtime...");
                string[] args = m.Split(' ');
                for(int i = 0; i < args.Length; i++)
                {
                    args[i] = args[i].ToLower();
                }

                switch (args[0])
                {
                    case "if":
                        //if condition
                        bool exitLoop = false;
                        for(int i = 1; i < args.Length; i++)
                        {
                            switch (args[i])
                            {
                                case "stop":
                                    //Stop the program and start to read the program
                                    if(exitLoop != true)
                                    {
                                        //Continue and execute the program after args[4]
                                        if(args[4] == null || args[4] == " " || args[4] == "")
                                        {
                                            CustomConsole.WarningLog("umm you need to add a executing function after the if condition!!!");
                                        }
                                        else
                                        {
                                            ExecuteCommand(args[4]);
                                        }
                                    }
                                    break;
                                case "readInt":
                                    //Check if an int from the registry is equal to this!!!!
                                    if (args[1] == null || args[2] == null || args[3] == null || args[1] == " " || args[2] == " " || args[3] == " ")
                                    {
                                        CustomConsole.ErrorLog("Argument either 1-3 is empty please fill them up!");
                                    }
                                    else
                                    {
                                        //Try to execute that read code
                                        bool adressExists = API.RegistryEditor.IntegerExists(args[1]);
                                        if (adressExists == true)
                                        {
                                            int adress = API.RegistryEditor.returnInteger(args[1]);
                                            if (args[2] != " " && args[2] == "equals")
                                            {
                                                string possibleinteger = args[3];
                                                if (possibleinteger.Contains("0") || possibleinteger.Contains("1") || possibleinteger.Contains("2") || possibleinteger.Contains("3") || possibleinteger.Contains("4") || possibleinteger.Contains("5") || possibleinteger.Contains("6") || possibleinteger.Contains("7") || possibleinteger.Contains("8") || possibleinteger.Contains("9"))
                                                {
                                                    int parsedPossibleInteger = int.Parse(possibleinteger);
                                                    if(adress != parsedPossibleInteger)
                                                    {
                                                        exitLoop = true;
                                                    }
                                                }
                                                else
                                                {
                                                    CustomConsole.ErrorLog("Seems like that isnt an integer!!!");
                                                }
                                            }
                                            else if(args[2] != " " && args[2] == "notequals")
                                            {
                                                string possibleinteger = args[3];
                                                if (possibleinteger.Contains("0") || possibleinteger.Contains("1") || possibleinteger.Contains("2") || possibleinteger.Contains("3") || possibleinteger.Contains("4") || possibleinteger.Contains("5") || possibleinteger.Contains("6") || possibleinteger.Contains("7") || possibleinteger.Contains("8") || possibleinteger.Contains("9"))
                                                {
                                                    int parsedPossibleInteger = int.Parse(possibleinteger);
                                                    if (adress != parsedPossibleInteger)
                                                    {
                                                        exitLoop = true;
                                                    }
                                                }
                                                else
                                                {
                                                    CustomConsole.ErrorLog("Seems like that isnt an integer!!!");
                                                }
                                            }
                                            else
                                            {
                                                CustomConsole.ErrorLog("Incorrect or wrong operation defined!!!!");
                                            }
                                        }
                                        else
                                        {
                                            CustomConsole.ErrorLog("That adress doesnt exist!");
                                        }
                                    }
                                    break;
                                case "readString":
                                    //Check if an string from the registry is equal to this!!!!
                                    if (args[1] == null || args[2] == null || args[3] == null || args[1] == " " || args[2] == " " || args[3] == " ")
                                    {
                                        CustomConsole.ErrorLog("Argument either 1-3 is empty please fill them up!");
                                    }
                                    else
                                    {
                                        //Try to execute that read code
                                        bool adressExists = API.RegistryEditor.StringExists(args[1]);
                                        if (adressExists == true)
                                        {
                                            string adress = API.RegistryEditor.returnString(args[1]);
                                            if (args[2] != " " && args[2] == "equals")
                                            {
                                                string possiblestring = args[3];
                                                if (adress != possiblestring)
                                                {
                                                    exitLoop = true;
                                                }
                                            }
                                            else if (args[2] != " " && args[2] == "notequals")
                                            {
                                                string possiblestring = args[3];
                                                if (adress == possiblestring)
                                                {
                                                    exitLoop = true;
                                                }
                                            }
                                            else
                                            {
                                                CustomConsole.ErrorLog("Incorrect or wrong operation defined!!!");
                                            }
                                        }
                                        else
                                        {
                                            CustomConsole.ErrorLog("That adress doesnt exist!");
                                        }
                                    }
                                    break;
                                case "readFloat":
                                    //Check if an int from the registry is equal to this!!!!
                                    if (args[1] == null || args[2] == null || args[3] == null || args[1] == " " || args[2] == " " || args[3] == " ")
                                    {
                                        CustomConsole.ErrorLog("Argument either 1-3 is empty please fill them up!");
                                    }
                                    else
                                    {
                                        //Try to execute that read code
                                        bool adressExists = API.RegistryEditor.FloatExists(args[1]);
                                        if (adressExists == true)
                                        {
                                            float adress = API.RegistryEditor.returnFloat(args[1]);
                                            if (args[2].ToLower() != " " && args[2].ToLower() == "equals")
                                            {
                                                string possibleinteger = args[3];
                                                if (possibleinteger.Contains("0") || possibleinteger.Contains("1") || possibleinteger.Contains("2") || possibleinteger.Contains("3") || possibleinteger.Contains("4") || possibleinteger.Contains("5") || possibleinteger.Contains("6") || possibleinteger.Contains("7") || possibleinteger.Contains("8") || possibleinteger.Contains("9"))
                                                {
                                                    float parsedPossibleInteger = float.Parse(possibleinteger);
                                                    if (adress != parsedPossibleInteger)
                                                    {
                                                        exitLoop = true;
                                                    }
                                                }
                                            }
                                            else if (args[2] != " " && args[2] == "notequals")
                                            {
                                                string possiblefloat = args[3];
                                                if (possiblefloat.Contains("0") || possiblefloat.Contains("1") || possiblefloat.Contains("2") || possiblefloat.Contains("3") || possiblefloat.Contains("4") || possiblefloat.Contains("5") || possiblefloat.Contains("6") || possiblefloat.Contains("7") || possiblefloat.Contains("8") || possiblefloat.Contains("9"))
                                                {
                                                    float parsedPossibleFLOAT = float.Parse(possiblefloat);
                                                    if (adress == parsedPossibleFLOAT)
                                                    {
                                                        exitLoop = true;
                                                    }
                                                }
                                                else
                                                {
                                                    CustomConsole.ErrorLog("Seems like that isnt an integer!!!");
                                                }
                                            }
                                            else
                                            {
                                                CustomConsole.ErrorLog("Seems like that isnt an integer!!!");
                                            }
                                        }
                                        else
                                        {
                                            CustomConsole.ErrorLog("That adress doesnt exist!");
                                        }
                                    }
                                    break;
                            }
                            if (exitLoop) break;
                        }
                        break;
                    case "while":
                        for (int i = 1; i < args.Length; i++)
                        {
                            bool exitLoopWhile = false;
                            //while condition
                            switch (args[i].ToLower())
                            {
                                case "readint":
                                    //write to this etc
                                    string nextString = args[2];
                                    bool integerExists = API.RegistryEditor.IntegerExists(nextString);
                                    if (integerExists == true)
                                    {
                                        //Continue and execute code
                                        string parseSymbol = args[3];
                                        string parsedObject = args[4];
                                        bool parsedObjectExisted = API.RegistryEditor.IntegerExists(parsedObject);
                                        if (parsedObjectExisted == true)
                                        {
                                            int newlyParsedObject = API.RegistryEditor.returnInteger(parsedObject);
                                            int nextStringParsed = API.RegistryEditor.returnInteger(nextString);
                                            switch (parseSymbol.ToLower())
                                            {
                                                //Doesnt really matter if it is the lower invariant or not it still should work
                                                case "==":
                                                    //Execute if the integer defined is equal to the parsing argument
                                                    if (newlyParsedObject != nextStringParsed)
                                                    {
                                                        exitLoopWhile = true;
                                                    }
                                                    break;
                                                case "!=":
                                                    //Same as the first but the complete opposite!!!
                                                    if(newlyParsedObject == nextStringParsed)
                                                    {
                                                        exitLoopWhile = true;
                                                    }
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            CustomConsole.ErrorLog("The right side variable of the while loop doesnt exist!!!");
                                        }
                                    }
                                    else
                                    {
                                        CustomConsole.ErrorLog("That integer doesnt exist in the registry!!!");
                                    }
                                    break;
                                case "readfloat":
                                    CustomConsole.WarningLog("Reading floats with while loops are not supported!!!");
                                    break;
                                case "readstring":
                                    CustomConsole.WarningLog("Reading strings with while loops are not supported!!!");
                                    break;
                                case "stop":
                                    CustomConsole.WarningLog("While loops are still in manufacturing and can not be operated yet sadly :(!!!");
                                    break;
                            } 
                        }
                        break;
                }
                CustomConsole.SuccessLog("Finished executing application runtime...");
                CustomConsole.WarningLog("Executing the command execution");
                ExecuteCommand(m);
            }
        }

        public static void ExecuteCommand(string command)
        {
            CommandExecutor.InitTextMode(command);
        }
    }
}
