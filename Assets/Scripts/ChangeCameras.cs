using UnityEngine;
using System.Collections;

public class ChangeCameras : MonoBehaviour 
{
	public GameObject guitarCam, mazeCam, errorWindow;
	public UILabel errorMsg;

	void Awake()
	{
		errorWindow.SetActive (false);
	}
	
	public void changeToMazeView()
	{

		if (GuitarManager.instance.chordProgression.Count >= 5) 
		{
			guitarCam.SetActive(false);
			mazeCam.SetActive(true);
			SubmitStrings ();
		} else 
		{
			errorMsg.text = "Error: \n Progression needs to be at least 5 chords long to continue.";
			errorWindow.SetActive(true);
		}

	}

	public void changeToGuitarView()
	{

		guitarCam.SetActive (true);
		mazeCam.SetActive (false);

	}

	public void SubmitStrings(){
		MazemanagerScript.instance.InvokeCreateMaze ();
	}

	public void closeErrorWindow()
	{
		errorWindow.SetActive (false);
	}

}
