using UnityEngine;
using System.Collections;

public class menuMuerto : MonoBehaviour 
{
	public GameObject administreitor;
	public GameObject jugador;
	public GameObject meniu;
	
	public AudioClip audio;
	
	public string reiniciarString;
	public string menuString;
	
	void Start()
	{
		meniu.SetActive(false);
		jugador.SetActive(true);
	}
	
	public void reiniciar()
	{
		Application.LoadLevel(reiniciarString);
	}
	
	public void revivir()
	{
		if(administreitor.GetComponent<administrador>().dinero <= administreitor.GetComponent<administrador>().dineroRevivir - 1)
		{
			GetComponent<AudioSource>().PlayOneShot(audio);
		}
		else
		{
			administreitor.GetComponent<administrador>().dinero -= administreitor.GetComponent<administrador>().dineroRevivir;
			administreitor.GetComponent<HUD>().cantidadVida = 100;
			meniu.SetActive(false);
			jugador.SetActive(true);
		}
	}
	
	public void menu()
	{
		Application.LoadLevel(menuString);
	}
	
	public void salir()
	{
		Application.Quit();
	}
}
