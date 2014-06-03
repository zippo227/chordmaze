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

	
	/* GuitarManager stores the current chord progression as a List of chordnames(enum)
	 * and stores a dictionary to convert from enum to chord(class)*/

	//GuitarManager also stores all the strings and toggles

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
		
	}

	public List<string> chordProgression;

	Dictionary<string, ChordObject> chordDictionary = new Dictionary<string, ChordObject> ();

	void Awake()
	{
		mInstance = this;
		setupDictionary ();

	}

	void setupDictionary()
	{
		string tempChord = "A";
		ChordObject tempChordObj = new ChordObject();
		tempChordObj.setChord(0,true,2,true,2,true,2,true,0,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "A7";
		tempChordObj.setChord(0,true,2,true,2,true,2,true,0,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Am";
		tempChordObj.setChord(0,true,1,true,2,true,2,true,0,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "B";
		tempChordObj.setChord(2,true,4,true,4,true,4,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "B7";
		tempChordObj.setChord(2,true,0,true,2,true,1,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Bm";
		tempChordObj.setChord(2,true,3,true,4,true,4,true,2,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "C";
		tempChordObj.setChord(0,true,1,true,0,true,2,true,3,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "C7";
		tempChordObj.setChord(0,true,1,true,3,true,2,true,3,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Cm";
		tempChordObj.setChord(3,true,4,true,5,true,5,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "D";
		tempChordObj.setChord(2,true,3,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "D7";
		tempChordObj.setChord(2,true,1,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Dm";
		tempChordObj.setChord(1,true,3,true,2,true,0,true,0,false,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "E";
		tempChordObj.setChord(0,true,0,true,1,true,2,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "E7";
		tempChordObj.setChord(0,true,0,true,1,true,0,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Em";
		tempChordObj.setChord(0,true,0,true,0,true,2,true,2,true,0,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "F";
		tempChordObj.setChord(1,true,1,true,2,true,3,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "F7";
		tempChordObj.setChord(1,true,4,true,2,true,3,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Fm";
		tempChordObj.setChord(1,true,1,true,3,true,0,true,0,true,0,false);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "G";
		tempChordObj.setChord(3,true,0,true,0,true,0,true,2,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "G7";
		tempChordObj.setChord(1,true,0,true,0,true,0,true,2,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);

		tempChord = "Gm";
		tempChordObj.setChord(3,true,3,true,0,true,0,true,1,true,3,true);
		chordDictionary.Add(tempChord, tempChordObj);

	}




}


