using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Violacornios
{

    public class HUD : MonoBehaviour
    {
        public Text vida;
        public Text puntos;
        public Text dinero;

        public int cantidadVida;
        public int cantidadPuntos;
        public int cantidadDinero;

        public Color atencion1;
        public Color atencion2;

        public bool parpadeando;

        public GameObject menuMorir;
        public GameObject administreitor;
        public GameObject jugador;

        void Start()
        {
            menuMorir.SetActive(false);
            cantidadVida = 100;
            cantidadPuntos = 0;
        }

        void Update()
        {
            cantidadDinero = administreitor.GetComponent<administrador>().dinero;

            vida.text = "Vida: " + cantidadVida.ToString();
            puntos.text = "Unicornios Violados: " + cantidadPuntos.ToString();
            dinero.text = "Violacoins: " + cantidadDinero.ToString();

            if (cantidadVida <= 100 && cantidadVida >= 61)
            {
                vida.color = Color.green;
            }

            if (cantidadVida <= 60 && cantidadVida >= 41)
            {
                vida.color = Color.yellow;
            }

            if (cantidadVida <= 40 && cantidadVida >= 11)
            {
                vida.color = Color.red;
            }

            if (cantidadVida <= 10 && parpadeando == false)
            {
                StartCoroutine(parpadear());
            }

            if (cantidadVida == 0 || cantidadVida <= 0)
            {
                finDelJuego();
            }

            if (cantidadVida >= 100)
            {
                cantidadVida = 100;
            }
        }

        IEnumerator parpadear()
        {
            parpadeando = true;
            vida.color = Color.yellow;
            yield return new WaitForSeconds(0.5f);
            vida.color = Color.red;
            yield return new WaitForSeconds(0.5f);
            parpadeando = false;
        }

        void finDelJuego()
        {
            menuMorir.SetActive(true);
            jugador.SetActive(false);
        }
    }
}