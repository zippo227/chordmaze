using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MazemanagerScript : MonoBehaviour {
	public static MazemanagerScript instance { get; private set; }
	public GameObject MazeButton;
	public GameObject MessageWindow;
	public GameObject CurrentChoosingChord;
	public List<string> MyChordsList;
	public Vector3 CenterofScreen;
	public float MazeWidth;
	public float MazeHeight;
	public int ChordSteps;
	public int MaxUpSteps;
	public float SidelenOfButton;
	public bool[] MySteps = new bool[30];
	public bool[,] VisitMatrix = new bool[30, 30];
	public Vector2 VisitPointer = new Vector2 (0, 0);
	public int up;
	public int right;
	public int pX;
	public int pY;
	public Color DefalutColor;
	// Use this for initialization
	public string ChordToPlay;
	public bool IsShowPath;

	UIInput MessageScript;
	UIButton MazeButtonScriptRef;

	void Awake(){
		instance = this;
	}

	void Start () {

		MessageScript = (UIInput)MessageWindow.GetComponent<UIInput> ();
		MazeButtonScriptRef = (UIButton)MazeButton.GetComponent<UIButton> ();
		Init ();
	}

	public void Init(){
		SetMessage ("Click Button to Choose Next Node");
		pX = -1;
		pY = 0;
		up = 0;
		right = 0;
		MyChordsList.Clear ();
		DefalutColor = MazeButtonScriptRef.defaultColor;
		ClearMaze ();
		IsShowPath = false;
	}

	public void SetMessage(string message){
		MessageScript.value = message;
	}

	public void PlayOriginalSong(){
		GuitarManager.instance.playProgression (GuitarManager.instance.chordProgression);
	}

	public void PlayMySong(){
		GuitarManager.instance.playProgression (MyChordsList);
	}

	public void ChooseChord(GameObject NewButton){
		if (CurrentChoosingChord != null) {
			UIButton OldButtonScript = (UIButton)CurrentChoosingChord.GetComponent<UIButton> ();
			OldButtonScript.defaultColor = DefalutColor;
		}

		UIButton MyButton = (UIButton)NewButton.GetComponent<UIButton> ();
		if (MyButton.defaultColor != MyButton.pressed) {
			CurrentChoosingChord = NewButton;
			MyButton.defaultColor = MyButton.hover;
		}
	}

	public void AddChord(){
		if (CurrentChoosingChord == null) {
			SetMessage("There's no chosen chord!");
			return;
		}

		MazeButtonScript ButtonScript = (MazeButtonScript)CurrentChoosingChord.GetComponent<MazeButtonScript> ();
		UIButton MyButton = (UIButton)CurrentChoosingChord.GetComponent<UIButton> ();
		if ((ButtonScript.x == pX + 1&&ButtonScript.y==pY) || (ButtonScript.y == pY + 1&&ButtonScript.x==pX)) {
			SetMessage ("Add Chord Successfully!");
			MyChordsList.Add (ButtonScript.MyChord);
			pX = ButtonScript.x;
			pY = ButtonScript.y;
			CurrentChoosingChord = null;
			MyButton.defaultColor = MyButton.pressed;

		} else {
			SetMessage ("Cannot Forge a Path!");
			CurrentChoosingChord = null;
			MyButton.defaultColor = DefalutColor;
			return;
		}


	}

	public void CompareChords(){
		if (MyChordsList.Count != GuitarManager.instance.chordProgression.Count) {
			SetMessage("Less or More Chords!");
			MyChordsList.Clear();
			pX=-1;
			pY=0;
			ResetMazeButtonColor();
			return;
		}
		for (int i =0; i<MyChordsList.Count; i++) {
			if(MyChordsList[i]!=GuitarManager.instance.chordProgression[i]){
				SetMessage("Wrong Answer!");
				MyChordsList.Clear();
				pX=-1;
				pY=0;
				ResetMazeButtonColor();
				return;
			}
		}
		SetMessage("Congratulations!");
		MyChordsList.Clear();
		pX=-1;
		pY=0;
		PlayOriginalSong ();
	}

	public void ClearMaze(){
		GameObject MazeUI = GameObject.FindGameObjectWithTag ("MazeUI");
		foreach (Transform child in MazeUI.transform) {
			if(child.tag=="MazeButton"){
				child.GetComponent<MazeButtonScript>().DestroyMyself();
			}
		}
	}

	public void ResetMazeButtonColor(){
		GameObject MazeUI = GameObject.FindGameObjectWithTag ("MazeUI");
		foreach (Transform child in MazeUI.transform) {
			if(child.tag=="MazeButton"){
				child.GetComponent<UIButton>().defaultColor = DefalutColor;
				MyChordsList.Clear();
				pX=-1;
				pY=0;
			}
		}
	}

	public void ShowPath(){
		GameObject MazeUI = GameObject.FindGameObjectWithTag ("MazeUI");
		ResetMazeButtonColor ();
		if (IsShowPath == false) 
		{
			foreach (Transform child in MazeUI.transform) 
			{
				if (child.tag == "MazeButton") {
					MazeButtonScript MyButton = (MazeButtonScript)child.GetComponent<MazeButtonScript> ();
					if (VisitMatrix [MyButton.x, MyButton.y] == true) 
					{
						child.GetComponent<UIButton> ().defaultColor = child.GetComponent<UIButton> ().pressed;
						MyChordsList.Clear();
						pX=-1;
						pY=0;
					}
				}
			}
			IsShowPath = true;
		} 
		else 
		{
			foreach (Transform child in MazeUI.transform) 
			{
				if (child.tag == "MazeButton") {
					MazeButtonScript MyButton = (MazeButtonScript)child.GetComponent<MazeButtonScript> ();
					if (VisitMatrix [MyButton.x, MyButton.y] == true) 
					{
						child.GetComponent<UIButton> ().defaultColor = DefalutColor;
					}
				}
			}
			IsShowPath = false;
		}
	}

	public void InvokeCreateMaze(){
		for (int i =0; i<30; i++) {
			MySteps[i] =false;
			for(int j =0;j<30;j++){
				VisitMatrix[i,j] = false;
			}
		}
		ChordSteps = GuitarManager.instance.chordProgression.Count-1;
		Debug.Log (GuitarManager.instance.chordProgression.Count);
		CenterofScreen = new Vector3 (0, 0, 0);
		MazeWidth = 300.0f;
		MazeHeight = 300.0f; 
		MaxUpSteps = (int)(ChordSteps * (MazeHeight / (MazeWidth + MazeHeight)));
		RandomStep (MySteps, ref up, ref right, ChordSteps);
		GetTheLengthOfButton (up, right, ref SidelenOfButton, MazeWidth, MazeHeight);
		Debug.Log (SidelenOfButton);
		//CreateButton ("Am", CenterofScreen);
		CreateMaze ();
	}

	void RandomStep(bool[] StepArray ,ref int NumofUP, ref int NumofRight, int steps){
		int count = 0;
		NumofUP = 0;
		NumofRight = 0;
		for (int i = 0; i<steps; i++) {
			int r = Random.Range(0,2);
			if(r==0&&NumofUP<MaxUpSteps){
				StepArray[i] = true;
				NumofUP++;
				count++;

			}
			else{
				StepArray[i]=false;
				NumofRight++;
				count++;
			}
		}
	}

	void CreateMaze(){
		Vector3 Start = Vector3.zero;
		Vector3 CurrentPosition = new Vector3 ();
		VisitPointer = new Vector2 (0, 0);
		Start.x = CenterofScreen.x - MazeWidth / 2 + SidelenOfButton / 2;
		Start.y = CenterofScreen.y - MazeHeight / 2 + SidelenOfButton / 2;
		Start.z = CenterofScreen.z;

		CurrentPosition = Start;
		Debug.Log ("Start " + CurrentPosition); 
		int i = -1;
		foreach (string text in GuitarManager.instance.chordProgression) {
			if(i>=0){
				if(MySteps[i]){
					VisitPointer.y++;
					CurrentPosition.y = CurrentPosition.y+SidelenOfButton;
				}
				else{
					VisitPointer.x++;

					CurrentPosition.x = CurrentPosition.x+SidelenOfButton;
				}
			}
			CreateButton(text,CurrentPosition,(int)VisitPointer.x,(int)VisitPointer.y);
			VisitMatrix [(int)VisitPointer.x, (int)VisitPointer.y] = true;
			Debug.Log ((int)VisitPointer.x+"   "+(int)VisitPointer.y);
			i++;
		}
		CurrentPosition = Start;
		for(int j =0;j<=up;j++){
			if(j!=0){
				CurrentPosition.y= CurrentPosition.y+SidelenOfButton;
				CurrentPosition.x = Start.x;
			}
			for(int k = 0;k<=right;k++){
				if(k!=0){
				    CurrentPosition.x = CurrentPosition.x+SidelenOfButton;
				}
				if(VisitMatrix[k,j]==false){
					string s = RandomString();
					CreateButton(s,CurrentPosition,k,j);
				}
			}
		}
	}

	string RandomString(){
		int num = Random.Range (0, 21);
		string s = GetString (num);
		return s;
	}

	string GetString(int num){
		string s = "random";
		switch (num) {
		case 0:
			s = "A";
			break;
		case 1:
			s = "Am";
			break;
		case 2:
			s = "A7";
			break;
		case 3:
			s = "B";
			break;
		case 4:
			s = "Bm";
			break;
		case 5:
			s = "B7";
			break;
		case 6:
			s = "C";
			break;
		case 7:
			s = "Cm";
			break;
		case 8:
			s = "C7";
			break;
		case 9:
			s = "D";
			break;
		case 10:
			s = "Dm";
			break;
		case 11:
			s = "D7";
			break;
		case 12:
			s = "E";
			break;
		case 13:
			s = "Em";
			break;
		case 14:
			s = "E7";
			break;
		case 15:
			s = "F";
			break;
		case 16:
			s = "Fm";
			break;
		case 17:
			s = "F7";
			break;
		case 18:
			s = "G";
			break;
		case 19:
			s = "Gm";
			break;
		case 20:
			s = "G7";
			break;
		}
		return s;
	}

	void CreateButton(string myChord, Vector3 position, int x, int y){
		GameObject Clone = (GameObject)Instantiate (MazeButton, transform.position, transform.rotation);
		Clone.transform.parent = GameObject.FindGameObjectWithTag ("MazeUI").transform;
		Clone.transform.localScale = new Vector3 (1, 1, 1);
		Clone.transform.localPosition = position;
		MazeButtonScript CloneScript = (MazeButtonScript)Clone.GetComponent<MazeButtonScript> ();
		CloneScript.MyChord = myChord;
		CloneScript.x = x;
		CloneScript.y = y;
		CloneScript.GetLabel ();
		CloneScript.SideLen = SidelenOfButton;
		CloneScript.SetSize ();

	}

	void GetTheLengthOfButton(int NumofUP, int NumofRight ,ref float LenofButton , float MaxWidth, float MaxHeight){
		float MaxButtonHeight = MaxHeight / (up+1);
		float MaxButtonWidth = MaxWidth / (right+1);
		LenofButton = (MaxButtonHeight < MaxButtonWidth) ? MaxButtonHeight : MaxButtonWidth;
	}

	// Update is called once per frame
	void Update () {
	    
	}
}
