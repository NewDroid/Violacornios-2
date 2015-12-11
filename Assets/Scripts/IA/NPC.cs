using UnityEngine;
using System.Collections;
using System;

namespace Violacornios
{

    public class NPC : MonoBehaviour, IDañable
    {
        public int vida { get; protected set; }
        public int escudo { get; protected set; }

        protected NavMeshAgent nv;

        protected GameObject player;

        protected RaycastHit hit;

        protected Ray ray;

        public void Daño(int puntos)
        {
            if (escudo > 0)
            {
                if (escudo > puntos)
                {
                    escudo -= puntos;
                }
                else
                {
                    vida -= puntos - escudo;
                    escudo = 0;
                }
            }
            else
            {
                vida -= puntos;
            }
        }

        public void Morir()
        {
            
        }

        protected void Start()
        {
            nv = GetComponent<NavMeshAgent>();
            player = GameObject.Find("Jugador");
        }

        protected void Update()
        {

        }
    }
}
