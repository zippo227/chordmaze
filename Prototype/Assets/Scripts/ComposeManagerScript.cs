using UnityEngine;
using System.Collections;

public class ComposeManagerScript : MonoBehaviour {
	public static ComposeManagerScript instance { get; private set; }
	public GameObject Label;
	public GameObject LabelGrid;
	UIGrid GridScript;

	void Awake(){
		instance = this;
	}
	// Use this for initialization
	void Start () {
		GridScript = (UIGrid)LabelGrid.GetComponent<UIGrid> ();
	}

	public void CreateLabels(string content){
		GameObject Clone = NGUITools.AddChild (LabelGrid, Label);
		UILabel CloneLabel = (UILabel)Clone.GetComponent<UILabel> ();
		CloneLabel.text = content;
		GridScript.repositionNow = true;
		//Clone.transform.parent = LabelGrid.transform;
		//Clone.transform.localScale = new Vector3 (1, 1, 1);

	}
}
