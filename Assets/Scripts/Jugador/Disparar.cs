using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour, IDañable {

    //Cosos para el raycast
    RaycastHit hit;
    public Transform puntoDisparo;

    //Variables disparo constantes(dependen del arma pero una vez estableciadas no cambian a no ser que se cambie de arma)
    //TODO : Encargate de cambiar los valores con tu administrador de armas
    float dañosSegundo = 8; //Cuantas veces hace el daño por segundo
    float tiempoDisparo = 0.3f;
    float distanciaMax = 200f; //unidades para el raycast
    int daño = 1; //En puntos de vida, ya hare la clase pambi para controlar todo eso
    bool laser = true;//Es un laser o son balas?
    bool arcoiris = true; //El laser sera arcoiris? :3
    public GameObject bala;
    bool auto;//Es automatica?
    int balasPorCargador = 5;//Cuantas balas caben en un cargador
    float tiempoRecarga = 2.5f;//Cuanto tarda en recargar
    float maximoSobrecalentamiento = 10f; //El maximo antes de que haga bum

    float dañosSegundoActual;
    float tiempoDesdeDisparo;
    float tiempoDesdeDaño;
    int balasEnCargador;

    float sobrecalentamiento, tsobrecalentamiento;

    public ParticleSystem particulasLaser;

    private int raycast;

    private LineRenderer lineRenderer; //El renderer de los disparos

    public ParticleSystem explosion;

    void Start()
    {

        lineRenderer = GetComponent<LineRenderer>();

        if (arcoiris && laser)
        {
            StartCoroutine(Arcoiris());
        }

        if (laser)
        {
            StartCoroutine(Emit());
        }

        balasEnCargador = balasPorCargador;
    }

    IEnumerator Emit()
    {
        while (true)
        {
            particulasLaser.Play();
            yield return new WaitForSeconds(25f);
        }
    }

    IEnumerator Recargar()
    {
        Debug.Log("Recargando...");

        yield return new WaitForSeconds(tiempoRecarga);
        balasEnCargador = balasPorCargador;
    }

    IEnumerator Arcoiris()
    {
        while (true)
        {
            Color[] coloresRandom = { new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f), new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f) , new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f) , new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f) };
            particulasLaser.startColor = coloresRandom[Random.Range(0, 4)];
            lineRenderer.SetColors(coloresRandom[Random.Range(0, 4)], coloresRandom[Random.Range(0, 4)]);
            yield return null;
        }
    }

    void Update()
    {
        tiempoDesdeDaño += Time.deltaTime;

        raycast = 1 << 8;
        raycast = ~raycast;

        if (laser)
        {
            particulasLaser.enableEmission = true;
            if (Input.GetMouseButton(0))
            {
                particulasLaser.transform.localPosition = new Vector3(0.412f, particulasLaser.transform.localPosition.y, particulasLaser.transform.localPosition.z);

                dañosSegundoActual = dañosSegundo - (dañosSegundo * (1 + (tsobrecalentamiento - maximoSobrecalentamiento)/maximoSobrecalentamiento));

                tsobrecalentamiento += Time.deltaTime;
                sobrecalentamiento = tsobrecalentamiento / maximoSobrecalentamiento;

                Debug.Log("Sobrecalentamiento : " + sobrecalentamiento + " | D/s : " + dañosSegundoActual);

                if(sobrecalentamiento >= 1)
                {
                    Debug.Log("BOOOOOM");
                    Morir();
                }

                if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit, distanciaMax, raycast))
                {

                    lineRenderer.SetPosition(0, puntoDisparo.position);
                    lineRenderer.SetPosition(1, hit.point);

                    IDañable dañable = hit.transform.GetComponent<IDañable>();

                    if (dañable != null && tiempoDesdeDaño > 1 / dañosSegundoActual)
                    {
                        dañable.Daño(daño);
                        tiempoDesdeDaño = 0;
                    }
                }
                else
                {
                    lineRenderer.SetPosition(0, puntoDisparo.position);
                    lineRenderer.SetPosition(1, puntoDisparo.forward * 1000000);
                }
            }
            else
            {
                tsobrecalentamiento -= Time.deltaTime * 2;

                if (tsobrecalentamiento < 0)
                    tsobrecalentamiento = 0;

                sobrecalentamiento = tsobrecalentamiento / maximoSobrecalentamiento;

                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);
                particulasLaser.transform.localPosition = new Vector3(-10000f, particulasLaser.transform.localPosition.y, particulasLaser.transform.localPosition.z);
            }
        }
        else
        {
            particulasLaser.enableEmission = false;
            if (balasEnCargador > 0)
            {

                tiempoDesdeDisparo += Time.deltaTime;

                if (auto)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (tiempoDesdeDisparo >= tiempoDisparo)
                        {
                            tiempoDesdeDisparo = 0f;
                            Instantiate(bala, puntoDisparo.position, puntoDisparo.transform.rotation);

                            balasEnCargador--;

                            if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit, distanciaMax, raycast))
                            {
                                IDañable dañable = (IDañable)hit.transform.GetComponent(typeof(IDañable));

                                if (dañable != null)
                                {
                                    dañable.Daño(daño);
                                }
                            }
                        }
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        if (tiempoDesdeDisparo >= tiempoDisparo)
                        {
                            tiempoDesdeDisparo = 0f;
                            Instantiate(bala, puntoDisparo.position, puntoDisparo.transform.rotation);

                            balasEnCargador--;

                            if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit, distanciaMax, raycast))
                            {
                                IDañable dañable = (IDañable)hit.transform.GetComponent(typeof(IDañable));

                                if (dañable != null)
                                {
                                    dañable.Daño(daño);
                                }
                            }
                        }
                    }
                }
                if (balasEnCargador == 0)
                    StartCoroutine(Recargar());
            }
        }
    }

    public void Daño(int puntos)
    {
        
    }

    public void Morir()
    {
        explosion.Play();
    }
}
