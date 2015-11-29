using UnityEngine;
using System.Collections;

public class administrador : MonoBehaviour 
{
	public bool[] wepons;
	public bool[] upgreidz;
	public int dinero;
	public int enemigos;
	public int dineroRevivir;

	void Awake()
	{
		DontDestroyOnLoad (transform.gameObject);
	}
}