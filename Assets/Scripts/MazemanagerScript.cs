using UnityEngine;
using System.Collections;


public class MazemanagerScript : MonoBehaviour {
	public static MazemanagerScript instance { get; private set; }

	public GameObject MazeButton;
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
	// Use this for initialization
	public string ChordToPlay;
	void Awake(){
		instance = this;
	}

	void Start () {


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
		MazeHeight = 200.0f; 
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
		Vector3 Start = new Vector3 ();
		Vector3 CurrentPosition = new Vector3 ();
		VisitPointer = new Vector2 (0, 0);
		Start = CenterofScreen;
		Start.x = CenterofScreen.x - MazeWidth / 2 + SidelenOfButton / 2;
		Start.y = CenterofScreen.y - MazeHeight / 2 + SidelenOfButton / 2;
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
			CreateButton(text,CurrentPosition);
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
					CreateButton("random",CurrentPosition);
				}
			}
		}
	}

	void CreateButton(string myChord, Vector3 position){
		GameObject Clone = (GameObject)Instantiate (MazeButton, transform.position, transform.rotation);
		Clone.transform.parent = GameObject.FindGameObjectWithTag ("MazeUI").transform;
		Clone.transform.localScale = new Vector3 (1, 1, 1);
		Clone.transform.localPosition = position;
		MazeButtonScript CloneScript = (MazeButtonScript)Clone.GetComponent<MazeButtonScript> ();
		CloneScript.MyChord = myChord;
		CloneScript.GetLabel ();
		CloneScript.SideLen = SidelenOfButton;
		CloneScript.SetSize ();

	}

	void GetTheLengthOfButton(int NumofUP, int NumofRight ,ref float LenofButton , float MaxWidth, float MaxHeight){
		float MaxButtonHeight = MaxHeight / up;
		float MaxButtonWidth = MaxWidth / right;
		LenofButton = (MaxButtonHeight < MaxButtonWidth) ? MaxButtonHeight : MaxButtonWidth;
	}

	// Update is called once per frame
	void Update () {
	    
	}
}
