using UnityEngine;
using System.Collections;

public class NoteLabel : MonoBehaviour {
	
	public UISlider slider;
	public UILabel chordLabel;
	public enum noteValue
		{
			A, B, C, D, E, F, G
		}

	public noteValue initialValue;

	private UILabel label;
	private string[] LabelValues = new string[12] {"A", "A# / Bb", "B", "C", "C# / Db", "D", "D# / Eb", "E", "F", "F# / Gb", "G", "G# / Ab"};
	private float initialNoteValue;

	void Awake()
	{
		label = gameObject.GetComponent<UILabel> ();
		setupInitVal ();
	}

	public void changeLabelNote()
	{
		int newLabelValue = (int)(initialNoteValue + slider.value / .0833f);

		if (newLabelValue > 11)
				newLabelValue -= 12;

		label.text = LabelValues [newLabelValue];

		chordLabel.text = "new chord";

	}

	void setupInitVal()
	{
		switch (initialValue) 
		{
		case noteValue.A:
			initialNoteValue = 0f;
			break;
		case noteValue.B:
			initialNoteValue = 2f;
			break;
		case noteValue.C:
			initialNoteValue = 3f;
			break;
		case noteValue.D:
			initialNoteValue = 5f;
			break;
		case noteValue.E:
			initialNoteValue = 7f;
			break;
		case noteValue.F:
			initialNoteValue = 8f;
			break;
		case noteValue.G:
			initialNoteValue = 10f;
			break;
		}
	}

}
