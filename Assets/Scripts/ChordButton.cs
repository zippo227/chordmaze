using UnityEngine;
using System.Collections;

public class ChordButton : MonoBehaviour {

	public UIToggle[] checkboxes;
	public NoteManager[] notes;

	public void playChord()
	{
		StartCoroutine ("playNotes");

	}

	IEnumerator playNotes()
	{
		for(int i = checkboxes.Length-1; i>=0; i--)
		{
			if (checkboxes[i].value)
			{
				notes[i].PlayMyNote();
				
			}
			yield return new WaitForSeconds(0.05f);
		}
	}
}
