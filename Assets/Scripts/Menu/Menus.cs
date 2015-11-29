using UnityEngine;
using System.Collections;

public class Menus : MonoBehaviour 
{
	//menus
	public GameObject principal;
	public GameObject jugar;
	public GameObject opciones;
	public GameObject salir;
	
	void Start()
	{
		Atras();
	}
	
	public void Atras()
	{
		principal.SetActive(true);
		jugar.SetActive(false);
		opciones.SetActive(false);
		salir.SetActive(false);
	}
	
	public void Juego()
	{
		principal.SetActive(false);
		jugar.SetActive(true);
		opciones.SetActive(false);
		salir.SetActive(false);
	}
	
	public void Opchons()
	{
		principal.SetActive(false);
		jugar.SetActive(false);
		opciones.SetActive(true);
		salir.SetActive(false);
	}
	
	public void Etztit()
	{
		principal.SetActive(false);
		jugar.SetActive(false);
		opciones.SetActive(false);
		salir.SetActive(true);
	}
	
	public void salirDelJuego()
	{
		Application.Quit();
	}
	
}
