using UnityEngine;
using System.Collections;

public class ChangeCameras : MonoBehaviour 
{
	public GameObject guitarCam, mazeCam, errorWindow;

	void Awake()
	{
		errorWindow.SetActive (false);
	}
	
	public void changeToMazeView()
	{
		if (GuitarManager.instance.chordProgression.Count >= 5) 
		{
			guitarCam.GetComponent<Camera> ().enabled = false;
			mazeCam.GetComponent<Camera> ().enabled = true;
			SubmitStrings ();
		} else 
		{
			errorWindow.SetActive(true);
		}
	}

	public void changeToGuitarView()
	{
		guitarCam.GetComponent<Camera> ().enabled = true;
		mazeCam.GetComponent<Camera> ().enabled = false;
	}

	public void SubmitStrings(){
		MazemanagerScript.instance.InvokeCreateMaze ();
	}

	public void closeErrorWindow()
	{
		errorWindow.SetActive (false);
	}

}
