using UnityEngine;
using System.Collections;

public class MouseLOCK : MonoBehaviour 
{
	void Update()
	{
		Cursor.visible = false;
		Screen.lockCursor = true;
	}
}