using UnityEngine;
using System.Collections;

public class PlayNote : MonoBehaviour {
	public int note;
	AudioSource AS;
	// Use this for initialization
	void Start () {

		AS = (AudioSource)gameObject.GetComponent<AudioSource> ();
		AS.pitch = Mathf.Pow (2, (note+GameManagerScript.instance.transpose ) / 12.0f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void play(){
		AS.Play ();
	}
}
