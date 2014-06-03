using UnityEngine;
using System.Collections;

public class ChordSelectButton : MonoBehaviour 
{
	public UISlider[] myStrings;
	public int[] stringSettings;

	public UIToggle[] myToggles;
	public bool[] playString;

	public UILabel nameBox;
	public string chordName;

	public ChordButton playChordButton;

	public void setToChord()
	{
		for (int i = 0; i<myStrings.Length; i++)
				myStrings [i].gameObject.transform.parent.GetComponentInChildren<AudioSource> ().Stop ();

		for (int i = 0; i<myStrings.Length; i++) //for each string
		{
			//set string to the value designated by this chord
			myStrings[i].value = .0833f * stringSettings[i];

			//set Toggle to the value designated by this chord
			myToggles[i].value = playString[i];
		}

		nameBox.text = chordName;

		playChordButton.playChord ();
	}

}
