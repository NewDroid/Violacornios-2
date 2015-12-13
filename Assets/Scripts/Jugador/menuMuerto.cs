using UnityEngine;
using System.Collections;

using UnityEngine.SceneManagement;

namespace Violacornios
{

    public class menuMuerto : MonoBehaviour
    {
        public GameObject administreitor;
        public GameObject jugador;
        public GameObject meniu;

        public AudioClip audioclip;

        public string reiniciarString;
        public string menuString;

        void Start()
        {
            meniu.SetActive(false);
            jugador.SetActive(true);
        }

        public void reiniciar()
        {
            SceneManager.LoadScene(reiniciarString);
        }

        public void revivir()
        {
            if (administreitor.GetComponent<administrador>().dinero <= administreitor.GetComponent<administrador>().dineroRevivir - 1)
            {
                GetComponent<AudioSource>().PlayOneShot(audioclip);
            }
            else
            {
                administreitor.GetComponent<administrador>().dinero -= administreitor.GetComponent<administrador>().dineroRevivir;
                administreitor.GetComponent<HUD>().cantidadVida = 100;
                meniu.SetActive(false);
                jugador.SetActive(true);
            }
        }

        public void menu()
        {
            SceneManager.LoadScene(menuString);
        }

        public void salir()
        {
            Application.Quit();
        }
    }
}
