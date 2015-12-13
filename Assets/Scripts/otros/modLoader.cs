using UnityEngine;
using System.Collections;
using System.Reflection;
using System;
using System.IO;

namespace Violacornios
{
    public class modLoader : MonoBehaviour
    {

        void Awake()
        {
            try {
                string[] mods = Directory.GetFiles(Application.persistentDataPath + "\\mods");

                Debug.Log(mods[0]);

                foreach(string mod in mods)
                {
                    try {
                        Assembly modAssembly = Assembly.LoadFrom(mod);
                        string[] modSplitted = mod.Split('\\');
                        Debug.Log(modSplitted[modSplitted.Length - 1]);

                        string finalName = modSplitted[modSplitted.Length - 1].Split('.')[0];

                        Type t = modAssembly.GetType(finalName + "." + finalName);

                        Debug.Log(t);

                        try {
                            object instance = Activator.CreateInstance(t);

                            try {
                                MethodInfo method = t.GetMethod("Initialize");
                                administrador.instancia.vcconsole.cprint("Initialized mod " + modAssembly.FullName + ".");
                                method.Invoke(instance, null);
                            }
                            catch { administrador.instancia.vcconsole.cprint("Mod " + modAssembly.GetName() + " doesnt have a Initialize method"); }
                        }
                        catch { administrador.instancia.vcconsole.cprint("Mod " + modAssembly.GetName() + " has a invalid name. \n Remember that the class name must be the same that the namespace and .dll file"); }
                    }
                    catch
                    {
                        administrador.instancia.vcconsole.cprint("Mod " + mod + " cannot be loaded");
                    }
                }

            }
            catch { }
        }
    }
}