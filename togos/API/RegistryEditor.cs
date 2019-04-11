using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API
{
    public class RegistryEditor
    {
        public static Dictionary<string, int> Integers = new Dictionary<string, int>();
        public static Dictionary<string, string> Strings = new Dictionary<string, string>();
        public static Dictionary<string, float> floats = new Dictionary<string, float>();

        public static bool AddWord(string wordIdentifier, string Word)
        {
            bool result = false;
            try
            {
                if (string.IsNullOrEmpty(Strings[wordIdentifier]))
                {
                    if (Strings[wordIdentifier] != Word)
                    {
                        Strings.Add(wordIdentifier, Word);
                        CustomConsole.SuccessLog("The registry value " + Word + " has been added to " + wordIdentifier);
                        result = true;
                    }
                    else
                    {
                        CustomConsole.ErrorLog("That registry string already contains the same variable given.");
                        result = false;
                    }
                }
                else
                {
                    CustomConsole.WarningLog("Overwriting registry string");
                    Strings.Add(wordIdentifier, Word);
                    result = true;
                }
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog("Registry has encountered an error while adding a string: " + e.Message);
                result = false;
            }
            return result;
        }

        public static bool AddInteger(string integerIdentifier, int replacement)
        {
            bool result = false;
            try
            {
                if (Integers[integerIdentifier] == 0 || !Integers.ContainsKey(integerIdentifier))
                {
                    if (Integers[integerIdentifier] != replacement)
                    {
                        Integers.Add(integerIdentifier, replacement);
                        CustomConsole.SuccessLog("The registry value " + replacement + " has been added to " + integerIdentifier);
                        result = true;
                    }
                    else
                    {
                        CustomConsole.ErrorLog("That registry string already contains the same variable given.");
                        result = false;
                    }
                }
                else
                {
                    CustomConsole.WarningLog("Overwriting registry string");
                    Integers.Add(integerIdentifier, replacement);
                    result = true;
                }
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog("Registry has encountered an error while adding a string: " + e.Message);
                result = false;
            }
            return result;
        }

        public static bool AddFloat(string floatIdentifier, float replacement)
        {
            bool result = false;
            try
            {
                if (floats[floatIdentifier] == 0 || !floats.ContainsKey(floatIdentifier))
                {
                    if (floats[floatIdentifier] != replacement)
                    {
                        floats.Add(floatIdentifier, replacement);
                        CustomConsole.SuccessLog("The registry value " + replacement + " has been added to " + floatIdentifier);
                        result = true;
                    }
                    else
                    {
                        CustomConsole.ErrorLog("That registry string already contains the same variable given.");
                        result = false;
                    }
                }
                else
                {
                    CustomConsole.WarningLog("Overwriting registry string");
                    floats.Add(floatIdentifier, replacement);
                    result = true;
                }
            }
            catch (Exception e)
            {
                CustomConsole.ErrorLog("Registry has encountered an error while adding a string: " + e.Message);
                result = false;
            }
            return result;
        }

        public static int returnInteger(string wordIdentifier)
        {
            return Integers[wordIdentifier];
        }

        public static string returnString(string wordIdentifier)
        {
            return Strings[wordIdentifier];
        }

        public static float returnFloat(string wordIdentifier)
        {
            return floats[wordIdentifier];
        }

        public static bool IntegerExists(string wordIdentifier)
        {
            if (Integers.ContainsKey(wordIdentifier))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool StringExists(string wordIdentifier)
        {
            if (Strings.ContainsKey(wordIdentifier))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool FloatExists(string wordIdentifier)
        {
            if (floats.ContainsKey(wordIdentifier))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool RemoveRegistryString(string wordIdentifier)
        {
            if (string.IsNullOrEmpty(Strings[wordIdentifier]))
            {
                CustomConsole.ErrorLog("That registry value doesnt exist.");
                return false;
            }
            else
            {
                Strings.Remove(wordIdentifier);
                CustomConsole.SuccessLog("Removed registry value from " + wordIdentifier);
                return true;
            }
        }

        public static bool RemoveRegistryInteger(string wordIdentifier)
        {
            if (!Integers.ContainsKey(wordIdentifier))
            {
                CustomConsole.ErrorLog("That registry value doesnt exist.");
                return false;
            }
            else
            {
                Integers.Remove(wordIdentifier);
                CustomConsole.SuccessLog("Removed registry value from " + wordIdentifier);
                return true;
            }
        }

        public static bool RemoveRegistryFloat(string wordIdentifier)
        {
            if (!floats.ContainsKey(wordIdentifier))
            {
                CustomConsole.ErrorLog("That registry value doesnt exist.");
                return false;
            }
            else
            {
                floats.Remove(wordIdentifier);
                CustomConsole.SuccessLog("Removed registry value from " + wordIdentifier);
                return true;
            }
        }
    }
}
