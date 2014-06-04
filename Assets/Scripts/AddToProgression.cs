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

		//if the dictionary does not already have that note, add it
		if (!manager.chordDictionary.ContainsKey (nameBox.text)) 
		{
			manager.addNewChord(nameBox.text);
		}

		//add chord to grid at bottom
		GameObject newChord = (GameObject)Resources.Load ("ChordButton");
		newChord.GetComponent<ChordSelectButton> ().setManager (manager.gameObject);
		newChord.GetComponent<ChordSelectButton> ().setName (nameBox);
		newChord.GetComponent<ChordSelectButton> ().setStrings ();

		NGUITools.AddChild (newChordGrid.gameObject, newChord);
		//GameObject.Destroy (newChord);
		newChordGrid.Reposition ();

		//newChordGrid.GetChild (newChordGrid.GetChildList ().size - 1).GetComponent<ChordSelectButton> ().chordName = nameBox.text;

		//make more modifications to this button so it plays the correct note


	}

}
