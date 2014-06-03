using UnityEngine;
using System.Collections;

public class InputSongScript : MonoBehaviour {

	UIInput uiInputScript;
	void Awake(){
		uiInputScript = gameObject.GetComponent<UIInput> ();

	}

	public void submitSong(){
		GameManagerScript.instance.song = uiInputScript.value;
		uiInputScript.value = null;
	}
}
