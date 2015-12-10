using UnityEngine;
using System.Collections;

namespace Violacornios
{

    public class Enemigo : NPC
    {
        public float distanciaDeteccion;
        public enum Estado
        {
            DandoVueltas,
            Buscando,
            Persiguiendo,
            Muerto
        }

        public Estado estado;

        protected int capaEnemigo;

        void Start()
        {
            base.Start();
            capaEnemigo = 1 << 9;
            capaEnemigo = ~capaEnemigo;
            StartCoroutine(Actualizar());
        }

        void Update()
        {

        }

        IEnumerator Actualizar()
        {
            while(estado != Estado.Muerto)
            {
                if (estado == Estado.Buscando)
                {

                }
                if (estado == Estado.DandoVueltas)
                {
                    ray.origin = transform.position;
                    ray.direction = player.transform.position.normalized;

                    Debug.Log(ray.GetPoint(player.transform.position.magnitude));

                    if (Physics.Raycast(ray, out hit, distanciaDeteccion, capaEnemigo))
                    {
                        Debug.Log("Obstaculo");
                    }
                }
                if (estado == Estado.Persiguiendo)
                {
                    nv.destination = player.transform.position;
                }
                yield return new WaitForSeconds(0.01f);
            }
            Morir();
        }

        void Morir()
        {
            StopAllCoroutines();

        }
    }

}