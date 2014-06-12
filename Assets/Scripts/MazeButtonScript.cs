using UnityEngine;
using System.Collections;

public class MazeButtonScript : MonoBehaviour {

	public string MyChord;
	public float SideLen;
	// Use this for initialization
	void Start () {
		GetLabel ();
		SetSize ();
	}


	public void PlayChords(){
		GuitarManager.instance.setChord (MyChord);
	}

	public void GetLabel(){
		UILabel MyLabel;
		MyLabel = (UILabel)gameObject.GetComponentInChildren<UILabel> ();
		if (MyLabel != null) {
			MyLabel.text = MyChord;
		} 
		else {
			Debug.Log ("No label");
		}
	}

	public void SetSize(){
		UISprite MySpite;
		MySpite = (UISprite)gameObject.GetComponent<UISprite> ();
		MySpite.width = (int)SideLen;
		MySpite.height = (int)SideLen;
	}

}
