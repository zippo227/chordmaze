using UnityEngine;
using System.Collections;

public class ReturnButtonScript : MonoBehaviour {
	public GameObject MazeCam;
	public GameObject GuitarCam;

	public void ChangeToGuitarPanel(){

		MazeCam.SetActive (false);
		GuitarCam.SetActive (true);
	}
}