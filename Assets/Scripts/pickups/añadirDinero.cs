using UnityEngine;
using System.Collections;

public class añadirDinero : MonoBehaviour 
{
	public int dineroAnadir;
	public int max;
	public int min;
	public GameObject administreitor;

	void Start()
	{
		dineroAnadir = Random.Range(min, max);
		administreitor = GameObject.Find("Administrador Cosas");
	}

	void OnTriggerEnter(Collider jugador) 
	{	
		if(jugador.gameObject.tag == "Player")
		{
			if(administreitor.GetComponent<administrador>().upgreidz[0] == true)
			{
				administreitor.GetComponent<administrador>().dinero += dineroAnadir * 2;
				Destroy(gameObject);
			}
			
			if(administreitor.GetComponent<administrador>().upgreidz[0] == false)
			{
				administreitor.GetComponent<administrador>().dinero += dineroAnadir;
				Destroy(gameObject);
			}
		}
	}
}