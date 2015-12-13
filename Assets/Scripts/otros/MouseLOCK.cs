using UnityEngine;
using System.Collections;

public class MouseLOCK : MonoBehaviour 
{
	void Update()
	{
		Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
}