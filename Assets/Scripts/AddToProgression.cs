using UnityEngine;
using System.Collections;

public class AddToProgression : MonoBehaviour 
{
	public GuitarManager manager;
	public UILabel nameBox;
	public UILabel listOfChords;
	public UIGrid newChordGrid;

	public void addChord()
	{
		manager.chordProgression.Add (nameBox.text);
		//if chord is not in dictionary, add it

		//add chord to grid at bottom

		NGUITools.AddChild (newChordGrid.gameObject, Resources.Load ("ChordButton") as GameObject);
		newChordGrid.Reposition ();

		//GameObject newChord = newChordGrid.GetChild (newChordGrid.GetChildList ().size - 1);
		//newChordGrid.GetComponent<ChordSelectButton> ().chordName = nameBox.text;
		//make more modifications to this button so it plays the correct note


	}

}
