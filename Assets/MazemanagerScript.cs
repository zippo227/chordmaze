using UnityEngine;
using System.Collections;

enum Chords{
	A,
	Am,
	A7,
	B,
	Bm,
	B7,
	C,
	Cm,
	C7,
	D,
	Dm,
	D7,
	E,
	Em,
	E7,
	F,
	Fm,
	F7,
	G,
	Gm,
	G7,
}

public class MazemanagerScript : MonoBehaviour {
	public static MazemanagerScript instance { get; private set; }
	// Use this for initialization
	public Chords ChordToPlay;
	void Awake(){
		instance = this;
	}
	 
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
