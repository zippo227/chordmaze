using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GuitarManager : MonoBehaviour {
	public static MazemanagerScript instance { get; private set; }

	/* GuitarManager stores the current chord progression as a List of chordnames(enum)
	 * and stores a dictionary to convert from enum to chord(class)*/

	public List<MazemanagerScript.Chords> chordProgression;

	Dictionary<MazemanagerScript.Chords, ChordObject> chordDictionary = new Dictionary<MazemanagerScript.Chords, ChordObject> ();


}

public class ChordObject 
{
	private int[] stringSettings = new int[6] {};
	private bool[] playStringSettings = new bool[6] {};

	public ChordObject(int s0, bool b0, int s1, bool b1, int s2, bool b2, int s3, bool b3, int s4, bool b4, int s5, bool b5)
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
