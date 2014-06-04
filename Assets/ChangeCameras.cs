using UnityEngine;
using System.Collections;

public class ChangeCameras : MonoBehaviour 
{
	public GameObject guitarCam, mazeCam;

	public void changeToMazeView()
	{
		guitarCam.GetComponent<Camera> ().enabled = false;
		mazeCam.GetComponent<Camera> ().enabled = true;
	}

	public void changeToGuitarView()
	{
		guitarCam.GetComponent<Camera> ().enabled = true;
		mazeCam.GetComponent<Camera> ().enabled = false;
	}

}
