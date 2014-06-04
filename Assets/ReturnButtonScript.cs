using UnityEngine;
using System.Collections;

public class ReturnButtonScript : MonoBehaviour {
	public GameObject MazeCam;
	public GameObject GuitarCam;

	public void ChangeToGuitarPanel(){

		MazeCam.GetComponent<Camera> ().enabled = false;
		GuitarCam.GetComponent<Camera> ().enabled = true;
	}
}