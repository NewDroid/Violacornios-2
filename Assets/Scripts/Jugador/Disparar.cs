using UnityEngine;
using System.Collections;

public class Disparar : MonoBehaviour {

    //Cosos para el raycast
    RaycastHit hit;
    public Transform puntoDisparo;

    //Variables disparo
    //TODO : Encargate de cambiar los valores con tu administrador de armas
    int dañosSegundo = 1; //Cuantas veces hace el daño por segundo
    float tiempoDisparo = 1f;
    float distanciaMax = 200f; //unidades para el raycast
    int daño = 1; //En puntos de vida, ya hare la clase pambi para controlar todo eso
    bool laser = true;

    public bool arcoiris;

    float tiempoDesdeDisparo;

    float tiempoDesdeDaño;

    public ParticleSystem particulasLaser;

    public int raycast;

    void Start()
    {
        if (arcoiris)
        {
            StartCoroutine(Arcoiris());
        }
    }

    IEnumerator Arcoiris()
    {
        while (true)
        {
            Color colorRandom = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);
            Color colorRandom2 = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f), 1f);

            particulasLaser.startColor = colorRandom;
            GetComponent<LineRenderer>().SetColors(colorRandom, colorRandom2);
            yield return null;
        }
    }

    void Update ()
    {

        tiempoDesdeDisparo += Time.deltaTime;
        tiempoDesdeDaño += Time.deltaTime;

        raycast = 1 << 8;
        raycast = ~raycast;

        if (laser)
        {
                if (Input.GetMouseButton(0))
                {
                particulasLaser.transform.localPosition = new Vector3(particulasLaser.transform.localPosition.x, particulasLaser.transform.localPosition.y, 0f);
                    if (Physics.Raycast(puntoDisparo.position, puntoDisparo.forward, out hit, distanciaMax, raycast))
                    {
                    Debug.Log(hit.transform.gameObject);

                        GetComponent<LineRenderer>().SetPosition(0, puntoDisparo.position);
                        GetComponent<LineRenderer>().SetPosition(1, hit.point);

                        IDañable dañable = (IDañable)hit.transform.GetComponent(typeof(IDañable));

                    if (dañable != null && tiempoDesdeDaño > 1 / dañosSegundo)
                    {
                        dañable.Daño(daño);
                        tiempoDesdeDaño = 0;
                    }
                }
                else
                {
                    GetComponent<LineRenderer>().SetPosition(0, puntoDisparo.position);
                    GetComponent<LineRenderer>().SetPosition(1, puntoDisparo.forward * 1000000);                   
                }
                }
            else
            {
                GetComponent<LineRenderer>().SetPosition(0, Vector3.zero);
                GetComponent<LineRenderer>().SetPosition(1, Vector3.zero);
                particulasLaser.transform.localPosition = new Vector3(particulasLaser.transform.localPosition.x, particulasLaser.transform.localPosition.y, -1000f);
            }
        }
    }     
}
