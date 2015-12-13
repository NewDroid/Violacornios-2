using UnityEngine;
using System.Collections;

public class admistradorArmas : MonoBehaviour 
{
	public GameObject[] armas;
	public AudioClip audioclip;
	public bool[] armasActivas;
	public string animacionCambiar;
	public int armaActal;
	
	void Update()
	{
		if(Input.GetKeyDown("1") && armasActivas[0] == true)
		{
			GetComponent<Animation>().Play(animacionCambiar);
			armaActal = 0;
			StartCoroutine(cambio());
		}
		if(Input.GetKeyDown("2") && armasActivas[1] == true)
		{
			GetComponent<Animation>().Play(animacionCambiar);
			armaActal = 1;
			StartCoroutine(cambio());
		}
		if(Input.GetKeyDown("3") && armasActivas[2] == true)
		{
			GetComponent<Animation>().Play(animacionCambiar);
			armaActal = 2;
			StartCoroutine(cambio());
		}
		if(Input.GetKeyDown("4") && armasActivas[3] == true)
		{
			GetComponent<Animation>().Play(animacionCambiar);
			armaActal = 3;
			StartCoroutine(cambio());
		}
		if(Input.GetKeyDown("5") && armasActivas[4] == true)
		{
			GetComponent<Animation>().Play(animacionCambiar);
			armaActal = 4;
			StartCoroutine(cambio());
		}
	}
	
	IEnumerator cambio()
	{
		GetComponent<AudioSource>().PlayOneShot(audioclip);
		yield return new WaitForSeconds(0.5f);
		armas[0].SetActive(false);
		armas[1].SetActive(false);
		armas[2].SetActive(false);
		armas[3].SetActive(false);
		armas[4].SetActive(false);
		armas[armaActal].SetActive(true);
	}
}