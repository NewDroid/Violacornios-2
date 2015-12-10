using UnityEngine;
using System.Collections;
using System.Reflection;
using System;

public class modLoader : MonoBehaviour
{

	void Awake()
    {
        Assembly mod = Assembly.LoadFrom("c:\\Users\\oscar\\Documents\\Violacornios-2\\Assets\\PruebaMods.dll");
        Type t = mod.GetType("PruebaMods.Prueba");

        object instance = Activator.CreateInstance(t);

        Debug.Log(instance.GetType());

        MethodInfo method = t.GetMethod("Run");

        Debug.Log(method);
        method.Invoke(instance, null);
    }
}
