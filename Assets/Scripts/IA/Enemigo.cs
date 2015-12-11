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

        protected Vector3 ultimaPosicion, ultimaPosicionIA;

        public float rangoDarVueltas;
        public float tiempoDecision;


        private float contadorTiempo;

        protected float duracionCorutina = 0.01f;

        IEnumerator Actualizar()
        {        
            while (estado != Estado.Muerto)
            {
                if (vida <= 0)
                    Morir();

                ray.origin = transform.position;
                ray.direction = player.transform.position - transform.position;

                if (estado == Estado.Buscando)
                {
                    nv.Resume();

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
                        DarVueltas();
                    }
                }
                if (estado == Estado.DandoVueltas)
                {
                    nv.Resume();

                    if (contadorTiempo >= tiempoDecision/duracionCorutina || transform.position == nv.destination)
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
                    nv.SetDestination(player.transform.position);
                    ultimaPosicion = player.transform.position;

                    if (Physics.Raycast(ray, out hit, distanciaDeteccion, capaEnemigo))
                    {
                        if (hit.transform.tag != "Player")
                        {
                            nv.Stop();
                            estado = Estado.Buscando;
                        }
                    }
                    else estado = Estado.Buscando;
                }
                ultimaPosicionIA = transform.position;
                yield return new WaitForSeconds(duracionCorutina);
            }
            Morir();
        }

        void DarVueltas()
        {
            nv.Stop();

            Vector3 aleatorio = new Vector3(Random.Range(-rangoDarVueltas, rangoDarVueltas), 0, Random.Range(-rangoDarVueltas, rangoDarVueltas));

            nv.destination = posicionInicial + aleatorio.normalized * rangoDarVueltas * Random.Range(5, 11) / 10;
            contadorTiempo = 0;

            estado = Estado.DandoVueltas;
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