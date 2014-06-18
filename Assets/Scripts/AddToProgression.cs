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

			if(!manager.checkChordDifference(nameBox.text))
			{
				chordName = manager.addNewChord(nameBox.text);
				nameBox.text = chordName;
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

		}


	}

}
