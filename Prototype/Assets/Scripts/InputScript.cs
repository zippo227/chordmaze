using UnityEngine;
using System.Collections;

public class InputScript : MonoBehaviour {
	public GameObject ProgBar;
	public float progress;
	UISlider ProgBarScript;
	UIInput MyInput;
	public int MaxNumofChar = 147;
	// Use this for initialization
	void Start () {
		MyInput = (UIInput)gameObject.GetComponent<UIInput> ();
		ProgBarScript = (UISlider)ProgBar.GetComponent<UISlider> ();
		//MyInput.value ="";
		/*for (int i=0; i<147; i++) {
			MyInput.value = MyInput.value.Insert(0,"W");
		}*/
	}
	
	public void SetProgBar(){
		progress = (float)MyInput.value.Length / (float)MaxNumofChar;
		ProgBarScript.value = progress;
	}

	public void ResetProgBar(){
		ProgBarScript.value = 0;
	}
}
