using System;
using System.Collections.Generic;
using System.Text;

namespace togos.API.Commands
{
    public class editreg
    {
        public void Start(string[] args)
        {
            string regValueType = args[1];
            string regKey = args[2];
            string regValue = args[3];
            if (regValueType != "")
            {
                if (regKey != "")
                {
                    if (regValue != "")
                    {
                        switch (regValueType.ToLower())
                        {
                            case "integer":
                            case "int":
                            case "number":
                                try
                                {
                                    if (API.RegistryEditor.IntegerExists(regKey))
                                    {
                                        API.RegistryEditor.RemoveRegistryInteger(regKey);
                                        CustomConsole.WarningLog("Registry point already exists deleting...");
                                        //I know i could of recalled text mode but this is easier and less error prone
                                        API.RegistryEditor.AddInteger(regKey, int.Parse(regValue));
                                        CustomConsole.SuccessLog("Registry Editor has successfully replaced the value of " + regKey + " to value" + regValue);
                                    }
                                    else
                                    {
                                        API.RegistryEditor.AddInteger(regKey, int.Parse(regValue));
                                        CustomConsole.SuccessLog("Registry Editor has successfully replaced the value of " + regKey + " to value" + regValue);
                                    }
                                }
                                catch (Exception e)
                                {
                                    CustomConsole.ErrorLog("Error in processing edits to the registry : " + e.Message);
                                }
                                break;
                            case "string":
                            case "word":
                                try
                                {
                                    if (API.RegistryEditor.StringExists(regKey))
                                    {
                                        API.RegistryEditor.RemoveRegistryString(regKey);
                                        CustomConsole.WarningLog("Registry point already exists deleting...");
                                        //I know i could of recalled text mode but this is easier and less error prone
                                        API.RegistryEditor.AddWord(regKey, regValue);
                                        CustomConsole.SuccessLog("Registry Editor has successfully replaced the value of " + regKey + " to value" + regValue);
                                    }
                                    else
                                    {
                                        API.RegistryEditor.AddWord(regKey, regValue);
                                        CustomConsole.SuccessLog("Registry Editor has successfully replaced the value of " + regKey + " to value" + regValue);
                                    }
                                }
                                catch (Exception e)
                                {
                                    CustomConsole.ErrorLog("Error in processing edits to the registry : " + e.Message);
                                }
                                break;
                            case "float":
                            case "double":
                                try
                                {
                                    if (API.RegistryEditor.FloatExists(regKey))
                                    {
                                        API.RegistryEditor.RemoveRegistryFloat(regKey);
                                        CustomConsole.WarningLog("Registry point already exists deleting...");
                                        //I know i could of recalled text mode but this is easier and less error prone
                                        API.RegistryEditor.AddFloat(regKey, float.Parse(regValue));
                                        CustomConsole.SuccessLog("Registry Editor has successfully replaced the value of " + regKey + " to value" + regValue);
                                    }
                                    else
                                    {
                                        API.RegistryEditor.AddFloat(regKey, float.Parse(regValue));
                                        CustomConsole.SuccessLog("Registry Editor has successfully replaced the value of " + regKey + " to value" + regValue);
                                    }
                                }
                                catch (Exception e)
                                {
                                    CustomConsole.ErrorLog("Error in processing edits to the registry : " + e.Message);
                                }
                                break;
                            default:
                                CustomConsole.ErrorLog("Incorrect command args");
                                break;
                        }
                    }
                    else
                    {
                        CustomConsole.ErrorLog("Registry Value is empty");
                        CustomConsole.WarningLog("Aborting! or well skipping...");
                    }
                }
                else
                {
                    CustomConsole.ErrorLog("Registry Key is empty");
                    CustomConsole.WarningLog("Aborting! or well skipping...");
                }
            }
            else
            {
                CustomConsole.ErrorLog("Registry Value type is empty");
                CustomConsole.WarningLog("Aborting! or well skipping...");
            }
        }
    }
}
