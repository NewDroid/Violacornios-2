using UnityEngine;
using System.Collections;

public class dinero : MonoBehaviour 
{
	public int dineroRestante;
	public GameObject administreitor;

	void Start()
	{
		administreitor = GameObject.Find("Administrador Cosas");
	}

	void Update () 
	{
		dineroRestante = administreitor.GetComponent<administrador>().dinero;
		GetComponent<TextMesh>().text = "Violacoins: " + dineroRestante; 
	}
}