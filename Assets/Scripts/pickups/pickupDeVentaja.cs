using UnityEngine;
using System.Collections;

namespace Violacornios
{

    public class pickupDeVentaja : MonoBehaviour
    {
        public int ventajaActipublic;
        public int tiempoEspera;
        public int tiempoMax;
        public int tiempoMin;
        public GameObject administradorGO;

        void Start()
        {
            administradorGO = GameObject.Find("Administrador Cosas");
            tiempoEspera = Random.Range(tiempoMin, tiempoMax);
        }

        void OnTriggerEnter(Collider jugador)
        {
            if (jugador.transform.tag == "Player")
            {
                actipublic();
            }
        }

        IEnumerator actipublic()
        {
            administradorGO.GetComponent<administrador>().upgreidz[ventajaActipublic] = true;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            yield return new WaitForSeconds(tiempoEspera);
            administradorGO.GetComponent<administrador>().upgreidz[ventajaActipublic] = false;
            Destroy(gameObject);
        }
    }
}