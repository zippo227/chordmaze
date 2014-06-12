using UnityEngine;
using System.Collections;

public class NoteManager : MonoBehaviour {

	public UISlider mySlider;
	private AudioSource audio;
	
	private float myPitch;

	void Awake()
	{
		audio = gameObject.GetComponent<AudioSource>();
	}

	public void PlayMyNote()
	{
		audio.Play ();
	}

	public void StopMyNote()
	{
		audio.Stop ();
	}

	public void ChangeMyNote()
	{
		//slider will be between 0 and 1, where 0 should be the open note (no change) 
		//and each 8.33% should shift the note up by 1/2
		float transpose;
		transpose = mySlider.value / GuitarManager.fretPerc;

		myPitch = Mathf.Pow (2f, transpose / (1.0f/GuitarManager.fretPerc));
		audio.pitch = myPitch;
	}


}
