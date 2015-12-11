using UnityEngine;
using System.Collections;

namespace Violacornios
{ 
    public class PruebaLuz : MonoBehaviour
    {
        public UnityEngine.UI.RawImage luz;

        public void Funciona()
        {
            luz.color = Color.green;
        }
    }
}