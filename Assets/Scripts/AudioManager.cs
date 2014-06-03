using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
	AudioSource AS;
	// Use this for initialization
	void Start () {
		AS = (AudioSource)(gameObject.GetComponent<AudioSource> ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
