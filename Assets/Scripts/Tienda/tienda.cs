using UnityEngine;
using System.Collections;

namespace Violacornios
{

    public class tienda : MonoBehaviour
    {
        public int precio;
        public int armaActivar;
        public int ventajaActivar;
        public string sinDinero;
        public string nombreCosa;
        public bool arma;
        public bool comprar;
        public bool abrirMenu;
        public bool ventaja;
        public bool comprado;
        public bool atras;
        public GameObject administradorGO;
        public GameObject[] menus;

        void Start()
        {
            nombreCosa = GetComponent<TextMesh>().text;
        }

        void OnMouseDown()
        {
            if (comprar)
            {
                if (administradorGO.GetComponent<administrador>().dinero == precio && comprado == false || administradorGO.GetComponent<administrador>().dinero >= precio && comprado == false)
                {
                    if (arma)
                    {
                        administradorGO.GetComponent<administrador>().wepons[armaActivar] = true;
                        administradorGO.GetComponent<administrador>().dinero -= precio;
                    }

                    if (ventaja)
                    {
                        administradorGO.GetComponent<administrador>().upgreidz[ventajaActivar] = true;
                        administradorGO.GetComponent<administrador>().dinero -= precio;
                    }
                }
            }

            if (abrirMenu)
            {
                menus[0].SetActive(false);
                menus[1].SetActive(false);
                menus[2].SetActive(false);
                menus[3].SetActive(false);
                menus[4].SetActive(false);
                menus[armaActivar].SetActive(true);
            }
        }

        void OnMouseOver()
        {
            if (administradorGO.GetComponent<administrador>().dinero == precio || administradorGO.GetComponent<administrador>().dinero >= precio)
            {
                GetComponent<TextMesh>().color = Color.green;
            }

            else if (administradorGO.GetComponent<administrador>().dinero <= precio && comprado == false && comprar)
            {
                GetComponent<TextMesh>().color = Color.red;
                GetComponent<TextMesh>().text = sinDinero;
            }
        }

        void OnMouseExit()
        {
            GetComponent<TextMesh>().color = Color.black;
            GetComponent<TextMesh>().text = nombreCosa;
        }

        void Update()
        {
            if (administradorGO.GetComponent<administrador>().wepons[armaActivar] == true && arma)
            {
                comprado = true;
            }

            if (administradorGO.GetComponent<administrador>().upgreidz[ventajaActivar] == true && ventaja)
            {
                comprado = true;
            }

            if (comprado)
            {
                GetComponent<TextMesh>().color = Color.gray;
            }
        }
    }
}