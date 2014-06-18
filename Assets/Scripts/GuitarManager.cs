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

	public List<string> chordProgression; //the user's chord Progression as set in the guitar mode
	public Dictionary<string, ChordObject> chordDictionary = new Dictionary<string, ChordObject> ();
	public List<string> originalChords; //used to check if user is trying to make a new chord or use an original chord when adding to the progression

	//these are references to the toggles and sliders that make up the guitar.
	public UIToggle[] guitarStringsToPlay;
	public UISlider[] strings;
	public NoteManager[] notes;

	//these are used when resetting the guitar
	public UILabel chordLabel;
	public UIGrid progressionGrid;

	//used to determine the % distance between frets.
	public const float fretPerc = 1.0f / 12.0f;

	//the time to wait between notes; set to zero when playing a chord progression
	float noteWait = 0.05f;

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
		tempChordObj.setChord(0,true,2,true,2,true,2,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "A7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,2,true,0,true,2,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Am";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,1,true,2,true,2,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "B";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,4,true,4,true,4,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "B7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,0,true,2,true,1,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Bm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,3,true,4,true,4,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "C";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,1,true,0,true,2,true,3,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "C7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,1,true,3,true,2,true,3,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Cm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(3,true,4,true,5,true,5,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "D";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,3,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "D7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(2,true,1,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Dm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,3,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "E";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,0,true,1,true,2,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "E7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,0,true,1,true,0,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Em";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,0,true,0,true,2,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "F";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,1,true,2,true,3,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "F7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,4,true,2,true,3,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Fm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,1,true,3,true,0,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "G";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(3,true,0,true,0,true,0,true,2,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "G7";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(1,true,0,true,0,true,0,true,2,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "Gm";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(3,true,3,true,0,true,0,true,1,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);
		originalChords.Add (tempChord);

		tempChord = "reset";
		tempChordObj = new ChordObject();
		tempChordObj.setChord(0,false,0,false,0,false,0,false,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);


	}

	public string addNewChord(string chordName)
	//adds a new chord with name 'chordName' and chord value equal to the current state of the strings to the dictionary
	{
		ChordObject tempChordObj = new ChordObject();
		tempChordObj.setChord((int)(strings[0].value*(1/fretPerc)), guitarStringsToPlay[0].value,
		                      (int)(strings[1].value*(1/fretPerc)), guitarStringsToPlay[1].value,
		                      (int)(strings[2].value*(1/fretPerc)), guitarStringsToPlay[2].value,
		                      (int)(strings[3].value*(1/fretPerc)), guitarStringsToPlay[3].value,
		                      (int)(strings[4].value*(1/fretPerc)), guitarStringsToPlay[4].value,
		                      (int)(strings[5].value*(1/fretPerc)), guitarStringsToPlay[5].value);
		int i = 1;
		string newChordName = chordName;
		while (chordDictionary.ContainsKey(newChordName)) 
		{
			newChordName = chordName + i;
			i++;
		}

		chordDictionary.Add(newChordName, tempChordObj);

		return(newChordName);
	}

	public void setChord(string name)
	{
		//public UIToggle[] guitarStringsToPlay;
		//public UISlider[] strings;

		stopPlay ();

		ChordObject cObj = new ChordObject ();
		cObj = chordDictionary [name];
		int[] chordStrings = cObj.getStrings ();
		bool[] stringSettings = cObj.getStringSettings ();
		
		for (int i = 0; i<strings.Length; i++) //for each string
		{
			//set string to the value designated by this chord
			strings[i].value = fretPerc * chordStrings[i];
			//set Toggle to the value designated by this chord
			guitarStringsToPlay[i].value = stringSettings[i];

		}
		
		playChord ();
	}

	public void playChord()
	{
		if(noteWait>0)
		{
			StartCoroutine ("playNotes");
		}
		else
		{
			for(int i = guitarStringsToPlay.Length-1; i>=0; i--)
			{
				if (guitarStringsToPlay[i].value)
				{
					notes[i].PlayMyNote();
				}
			}
		}
	}
	
	IEnumerator playNotes()
	{
		for(int i = guitarStringsToPlay.Length-1; i>=0; i--)
		{
			if (guitarStringsToPlay[i].value)
			{
				notes[i].PlayMyNote();
			}
			yield return new WaitForSeconds(noteWait);
		}
	}

	public void stopPlay()
	{
		for( int i = 0; i<guitarStringsToPlay.Length; i++)
		{
			notes[i].StopMyNote();
		}
	}
	
	public void playProgression(List<string> progression)
	{
		StopAllCoroutines ();
		noteWait = 0.0f;

		stopPlay ();
		StartCoroutine (playChords(progression));
	}

	IEnumerator playChords(List<string> tempProgression)
	{

		//for each chord in the given progression, play that chord and wait .3 seconds
		for (int i = 0; i<tempProgression.Count; i++) 
		{
			setChord(tempProgression[i]);
			yield return new WaitForSeconds(0.65f);
		}
		noteWait = 0.05f;
	}

	public void resetGuitar()
	{
		stopPlay ();
		StopAllCoroutines ();
		//clear all progressions
		chordProgression.Clear ();

		//clear all strings and set toggles to zero
		setChord ("reset");

		chordLabel.text = "Name this chord";
		BetterList<Transform> gridItems = new BetterList<Transform> ();
		gridItems = progressionGrid.GetChildList ();

		for (int i = gridItems.size - 1; i >= 0; i--)
		{
			gridItems[i].parent = null;
			NGUITools.Destroy(gridItems[i].gameObject);
			gridItems[i] = null;
		}

	}

	public bool stringsPlaying()
	{
		foreach(UIToggle toggle in guitarStringsToPlay)
		{
			if(toggle.value)
				return true;
		}

		return false;
	}

	//checkChordDifference returns false if the chord with key chordName in the dictionary is not equal to the 
	//current string settings, and true if it is
	public bool checkChordDifference(string chordName)
	{
		/* Guitar is currently set to:
		 * public UIToggle[] guitarStringsToPlay;
		 * public UISlider[] strings;
		 *
		 * Dictionary entry:
		 * int[] chordDictionary[chordName].getStrings()
		 * bool[] chordDictionary[chordName].getStringSettings()
		 */

		if (!chordDictionary.ContainsKey (chordName))
						return false;
		for (int i = 0; i<6; i++)
		{
			if(guitarStringsToPlay[i].value != chordDictionary[chordName].getStringSettings()[i])
			{
				return false;
			}
			if((int)(strings[i].value*(1/fretPerc)) != chordDictionary[chordName].getStrings()[i])
			{
				return false;
			}
		}

		return true;
	}



}


