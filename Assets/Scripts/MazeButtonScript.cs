using UnityEngine;
using System.Collections;

public class MazeButtonScript : MonoBehaviour {

	public string MyChord;
	public float SideLen;
	public int x;
	public int y;
	UIButton MyButton;
	// Use this for initialization
	void Start () {
		GetLabel ();
		SetSize ();
		MyButton = (UIButton)gameObject.GetComponent<UIButton> ();
	}


	public void PlayChords(){
		GuitarManager.instance.setChord (MyChord);
	}

	public void Choose(){
		MazemanagerScript.instance.ChooseChord (gameObject);
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

	public void DestroyMyself(){
		Destroy (gameObject);
	}

}
