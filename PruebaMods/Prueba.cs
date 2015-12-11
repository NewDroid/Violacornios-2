using System;
using UnityEngine;

using Violacornios;

namespace PruebaMods
{
    public class Prueba : MonoBehaviour
    {
        public void Run()
        {
            Debug.Log("Funciono! :D");
            PruebaLuz pruebaLuz = GameObject.Find("modLoader").GetComponent<PruebaLuz>();
            
            pruebaLuz.Funciona();
        }
    }
}
