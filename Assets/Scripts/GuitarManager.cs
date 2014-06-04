using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuitarManager : MonoBehaviour {

	private static GuitarManager mInstance;
	public static GuitarManager instance 
	{ 
		get 
		{ 
			if (mInstance == null) 
			{
				Debug.LogError ("Set this script execution order higher is in the editor");
			}

			return mInstance;
		}
	}

	[System.Serializable]
	public class ChordObject
	{
		private int[] stringSettings = new int[6];
		private bool[] playStringSettings = new bool[6];

		public ChordObject() {}
		public void setChord(int s0, bool b0, int s1, bool b1, int s2, bool b2, int s3, bool b3, int s4, bool b4, int s5, bool b5)
		{
			stringSettings[0] = s0;
			playStringSettings[0] = b0;
			stringSettings[1] = s1;
			playStringSettings[1] = b1;
			stringSettings[2] = s2; 
			playStringSettings[2] = b2;
			stringSettings[3] = s3;
			playStringSettings[3] = b3;
			stringSettings[4] = s4;
			playStringSettings[4] = b4;
			stringSettings[5] = s5; 
			playStringSettings[5] = b5;
		}

		public int[] getStrings()
		{
			return stringSettings;
		}

		public bool[] getStringSettings()
		{
			return playStringSettings;
		}
		
	}

	/* GuitarManager stores the current chord progression as a List of chordnames(enum)
	 * and stores a dictionary to convert from enum to chord(class)*/
	
	//GuitarManager also stores all the strings and toggles

	public List<string> chordProgression;
	public Dictionary<string, ChordObject> chordDictionary = new Dictionary<string, ChordObject> ();

	//these are references to the toggles and sliders that make up the guitar.
	public UIToggle[] guitarStringsToPlay;
	public UISlider[] strings;

	void Awake()
	{
		mInstance = this;
		setupDictionary ();
	}

	void setupDictionary()
	{
		ChordObject tempChordObj;
		string tempChord = "A";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,2,true,2,true,2,true,0,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "A7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,2,true,2,true,2,true,0,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Am";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,1,true,2,true,2,true,0,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "B";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,4,true,4,true,4,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "B7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,0,true,2,true,1,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Bm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,3,true,4,true,4,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "C";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,1,true,0,true,2,true,3,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "C7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,1,true,3,true,2,true,3,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Cm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(3,true,4,true,5,true,5,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "D";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,3,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "D7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,1,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Dm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,3,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "E";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,0,true,1,true,2,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "E7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,0,true,1,true,0,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Em";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,0,true,0,true,2,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "F";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,1,true,2,true,3,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "F7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,4,true,2,true,3,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Fm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,1,true,3,true,0,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "G";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(3,true,0,true,0,true,0,true,2,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "G7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,0,true,0,true,0,true,2,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Gm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(3,true,3,true,0,true,0,true,1,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);

	}

	public void addNewChord(string chordName)
	//adds a new chord with name 'chordName' and chord value equal to the current state of the strings to the dictionary
	{
		ChordObject tempChordObj = new ChordObject();
		tempChordObj.setChord((int)strings[0].value, guitarStringsToPlay[0].value,
		                      (int)strings[1].value, guitarStringsToPlay[1].value,
		                      (int)strings[2].value, guitarStringsToPlay[2].value,
		                      (int)strings[3].value, guitarStringsToPlay[3].value,
		                      (int)strings[4].value, guitarStringsToPlay[4].value,
		                      (int)strings[5].value, guitarStringsToPlay[5].value);
		chordDictionary.Add(chordName, tempChordObj);
	}

	public void playChord()
	{
		StartCoroutine ("playNotes");
		
	}
	
	IEnumerator playNotes()
	{
		for(int i = guitarStringsToPlay.Length-1; i>=0; i--)
		{
			if (guitarStringsToPlay[i].value)
			{
				strings[i].transform.parent.GetComponentInChildren<NoteManager>().PlayMyNote();
				
			}
			yield return new WaitForSeconds(0.05f);
		}
	}

	public void stopPlay()
	{
		for( int i = 0; i<guitarStringsToPlay.Length; i++)
			strings[i].transform.parent.GetComponentInChildren<AudioSource> ().Stop ();

	}




}


