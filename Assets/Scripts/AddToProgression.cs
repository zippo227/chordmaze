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
		if (listOfChords.text == "")
						listOfChords.text = nameBox.text;
		else
			listOfChords.text = listOfChords.text + ", " + nameBox.text;

		//add chord to grid at bottom
		//GameObject newChord = (GameObject)Instantiate (Resources.Load ("ChordButton"));

		//NGUITools.AddChild (newChordGrid.gameObject, newChord);
		//newChordGrid.Reposition ();

	}

}
