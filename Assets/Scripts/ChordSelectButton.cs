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

	public GuitarManager playChordButton;

	public void setToChord()
	{
		playChordButton.setChord (chordName);
		nameBox.text = chordName;
//		playChordButton.stopPlay ();
//
//		for (int i = 0; i<myStrings.Length; i++) //for each string
//		{
//			//set string to the value designated by this chord
//			myStrings[i].value = .0833f * stringSettings[i];
//
//			//set Toggle to the value designated by this chord
//			myToggles[i].value = playString[i];
//		}
//
//		nameBox.text = chordName;
//
//		playChordButton.playChord ();
	}

	void Awake()
	{
		gameObject.GetComponentInChildren<UILabel> ().text = chordName;
	}

	public void setName(string text)
	{
		chordName = text;
		//gameObject.GetComponentInChildren<UILabel> ().text = name;
	}

	public void setManager(GameObject go)
	{
		playChordButton = go.GetComponent<GuitarManager>();
	}

	public void setStrings()
	{
		//if (playChordButton.chordDictionary [chordName])
			//			Debug.Log ("chord is in dict");
		GuitarManager.ChordObject myChord = playChordButton.chordDictionary[chordName];
		stringSettings = myChord.getStrings();
		playString = myChord.getStringSettings();
		myToggles = playChordButton.guitarStringsToPlay;
		myStrings = playChordButton.strings;
	}
}
