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
		ComposeManagerScript.instance.CreateLabels (MyInput.value);
		MyInput.value = "";
	}
}
