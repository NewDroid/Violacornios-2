using UnityEngine;
using System.Collections;

namespace Violacornios
{

    public class Enemigo : NPC, IDañable
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

        protected Vector3 posicionInicial;

        void Start()
        {
            base.Start();

            vida = 100;

            capaEnemigo = 1 << 9;
            capaEnemigo = ~capaEnemigo;

             StartCoroutine(Actualizar());

            posicionInicial = transform.position;

            contadorTiempo = tiempoDecision / duracionCorutina;
        }

        protected Vector3 ultimaPosicion;

        public float rangoDarVueltas;
        public float tiempoDecision;


        private float contadorTiempo;

        protected float duracionCorutina = 0.01f;

        IEnumerator Actualizar()
        {        
            while (estado != Estado.Muerto)
            {
                Debug.Log(vida);

                if (vida <= 0)
                    Morir();

                ray.origin = transform.position;
                ray.direction = player.transform.position - transform.position;

                if (estado == Estado.Buscando)
                {
                    nv.destination = ultimaPosicion;
              
                    if (Physics.Raycast(ray, out hit, distanciaDeteccion, capaEnemigo))
                    {
                        if (hit.transform.tag == "Player")
                        {
                            estado = Estado.Persiguiendo;
                        }
                    }

                    if (transform.position.x == ultimaPosicion.x && transform.position.z == ultimaPosicion.z)
                    {
                        estado = Estado.DandoVueltas;
                    }
                }
                if (estado == Estado.DandoVueltas)
                {
                    if(contadorTiempo >= tiempoDecision/duracionCorutina || transform.position == nv.destination)
                    {
                        Vector3 aleatorio = new Vector3(Random.Range(-rangoDarVueltas, rangoDarVueltas), 0, Random.Range(-rangoDarVueltas, rangoDarVueltas));

                        nv.destination = posicionInicial + aleatorio.normalized * rangoDarVueltas * Random.Range(5, 11)/10;
                        contadorTiempo = 0;
                    }

                    contadorTiempo++;

                    if (Physics.Raycast(ray, out hit, distanciaDeteccion, capaEnemigo))
                    {
                        if(hit.transform.tag == "Player")
                        {
                            estado = Estado.Persiguiendo;
                        }
                    }
                }
                if (estado == Estado.Persiguiendo)
                {
                    nv.destination = player.transform.position;
                    ultimaPosicion = player.transform.position;

                    if (Physics.Raycast(ray, out hit, distanciaDeteccion, capaEnemigo))
                    {
                        if (hit.transform.tag == "Player")
                        {
                            estado = Estado.Persiguiendo;
                        }else estado = Estado.Buscando;
                    }
                    else estado = Estado.Buscando;
                }
                yield return new WaitForSeconds(duracionCorutina);
            }
            Morir();
        }

        new void Morir()
        {
            StopAllCoroutines();

            Invoke("Destruir", 10f);
        }

        void Destruir()
        {
            Destroy(gameObject);
        }
    }

}