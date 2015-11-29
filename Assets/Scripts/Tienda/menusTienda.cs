using UnityEngine;
using System.Collections;

public class menusTienda : MonoBehaviour 
{
	public GameObject armas;
	public GameObject ventajas;
	public GameObject menuArmas;
	public GameObject menuVentajas;
	public GameObject jugar;
	public GameObject atras;
	public bool esArmas;
	public bool esVentajas;
	public bool Atras;

	void OnMouseEnter()
	{
		gameObject.GetComponent<TextMesh>().color = Color.red;
	}

	void OnMouseExit()
	{
		gameObject.GetComponent<TextMesh>().color = Color.blue;
		
		if(Atras == true)
		{
			gameObject.GetComponent<TextMesh>().color = Color.black;
		}
		
	}

	void OnMouseDown()
	{
		if(esArmas)
		{
			armas.GetComponent<MeshRenderer>().enabled = false;
			ventajas.GetComponent<MeshRenderer>().enabled = false;
			jugar.SetActive(false);
			atras.SetActive(true);
			menuArmas.SetActive(true);
		}
		
		if(esVentajas)
		{
			armas.GetComponent<MeshRenderer>().enabled = false;
			ventajas.GetComponent<MeshRenderer>().enabled = false;
			jugar.SetActive(false);
			atras.SetActive(true);
			menuVentajas.SetActive(true);
		}
		
		if(Atras)
		{
			armas.GetComponent<MeshRenderer>().enabled = true;
			ventajas.GetComponent<MeshRenderer>().enabled = true;
			jugar.SetActive(true);
			atras.SetActive(false);
			menuArmas.SetActive(false);
			menuVentajas.SetActive(false);
		}
	}
}