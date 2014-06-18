using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {
	public GameObject ProgBar;
	public GameObject BarOverLay;
	public GameObject Counter;
	public float progress;
	UISlider ProgBarScript;
	UIInput MyInput;
	UISprite OverLaySprite;
	UILabel CounterScript;
	public int MaxNumofChar = 147;
	// Use this for initialization
	void Start () {
		MyInput = (UIInput)gameObject.GetComponent<UIInput> ();
		ProgBarScript = (UISlider)ProgBar.GetComponent<UISlider> ();
		OverLaySprite = (UISprite)BarOverLay.GetComponent<UISprite> ();
		OverLaySprite.color = Color.blue;
		CounterScript = (UILabel)Counter.GetComponent<UILabel> ();
		//MyInput.value ="";
		/*for (int i=0; i<147; i++) {
			MyInput.value = MyInput.value.Insert(0,"W");
		}*/
	}
	
	public void SetProgBar(){
		progress = (float)MyInput.value.Length / (float)MaxNumofChar;
		ProgBarScript.value = progress;
		if (progress >= 1.0f) {
			OverLaySprite.color = Color.red;
		} else {
			OverLaySprite.color = Color.blue;
		}
		CounterScript.text = MyInput.value.Length.ToString ();
	}

	public void ResetProgBar(){
		ProgBarScript.value = 0;
	}
}
