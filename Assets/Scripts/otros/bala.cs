using UnityEngine;
using System.Collections;

public class bala : MonoBehaviour {

    public float velocidad;

    void Start()
    {
        Invoke("Desaparecer", 5f);
    }

    void Desaparecer()
    {
        Destroy(gameObject);
    }

	void Update ()
    {
        transform.Translate(Vector3.forward * velocidad);
	}
}
