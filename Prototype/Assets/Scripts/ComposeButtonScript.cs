using UnityEngine;
using System.Collections;

public class ComposeButtonScript : MonoBehaviour {

	public GameObject InputField;
	UIInput MyInput;
	// Use this for initialization
	void Start () {
		MyInput = (UIInput)InputField.GetComponent<UIInput> ();
	}
	
	public void SubmitInput(){
		if (MyInput.value.Length != 0) {
			ComposeManagerScript.instance.CreateLabels (MyInput.value);
		MyInput.value = "";
		} 
		else {
			Debug.Log ("Empty Message!");
		}

	}
}
