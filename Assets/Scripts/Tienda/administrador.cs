using UnityEngine;
using System.Collections;

namespace Violacornios
{

    public class administrador : MonoBehaviour
    {
        public bool[] wepons;
        public bool[] upgreidz;
        public int dinero;

        public GameObject[] enemigosGO;
        public Enemigo[] enemigos;

        public int dineroRevivir;

        public static administrador instancia;

        void Awake()
        {
            if (instancia == null)
            {
                instancia = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                if (instancia != this)
                {
                    Destroy(gameObject);
                }
            }

            enemigosGO = GameObject.FindGameObjectsWithTag("Enemigo");

            for(int i = 0; i < enemigosGO.Length; i++)
            {
                enemigos[i] = enemigosGO[i].GetComponent<Enemigo>();
            }
        }
    }
}