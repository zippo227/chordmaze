using UnityEngine;
using System.Collections;

public class AddToProgression : MonoBehaviour 
{
	public GuitarManager manager;
	public UILabel nameBox;
	public UILabel listOfChords;
	public UIGrid newChordGrid;

	public GameObject errorWindow;
	public UILabel errorMsg;

	public void addChord()
	{
		//show error if user is trying to create a chord with no strings played
		if (!manager.stringsPlaying()) 
		{
			errorMsg.text = "Error: \n Cannot add chord with no strings being played.";
			errorWindow.SetActive(true);
		}
		else
		{

			string chordName = nameBox.text;

			//if the dictionary already has this note, but the note has been changed
			if(manager.originalChords.Contains(nameBox.text) && !manager.checkChordDifference(nameBox.text))
			{
				errorMsg.text = "Error: \n Trying to modify an original chord. Please change the chord's name.";
				errorWindow.SetActive(true);
			}
			else
			{
				//if the dictionary does not already have that note, add it
				if (!manager.originalChords.Contains(nameBox.text)) 
				{
					chordName = manager.addNewChord(nameBox.text);
				}

				manager.chordProgression.Add (chordName);

				//add chord to grid at bottom
				GameObject newChord = (GameObject)Resources.Load ("ChordButton");
				newChord.GetComponent<ChordSelectButton> ().setManager (manager.gameObject);
				newChord.GetComponent<ChordSelectButton> ().setName (nameBox, chordName);
				newChord.GetComponent<ChordSelectButton> ().setStrings ();
				newChord.GetComponent<UISprite> ().SetDimensions (84, 52);

				NGUITools.AddChild (newChordGrid.gameObject, newChord);
				//GameObject.Destroy (newChord);
				newChordGrid.Reposition ();

				//newChordGrid.GetChild (newChordGrid.GetChildList ().size - 1).GetComponent<ChordSelectButton> ().chordName = nameBox.text;

				//make more modifications to this button so it plays the correct note
			}
		}


	}

}
