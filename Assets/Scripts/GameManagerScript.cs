using UnityEngine;
using System.Collections;

public class GameManagerScript : MonoBehaviour {
	public static GameManagerScript instance { get; private set; }
	public AudioSource AS;
	public AudioSource FormerAS;
	public AudioSource SampleAudio;
	public float volume;
	public int transpose;
	public string song;
	public int SolutionCount;

	public GameObject ScrollBar;
	public UIScrollBar ScrollBarScript;

	void Awake(){
		instance = this;
		SampleAudio = gameObject.GetComponent<AudioSource> ();
		SolutionCount = 0;
	}

	// Use this for initialization
	void Start () {
		ScrollBarScript = (UIScrollBar)(ScrollBar.GetComponent<UIScrollBar>());
		volume = ScrollBarScript.value;
	
	}

	public void ChangeVolume(){
		volume = ScrollBarScript.value;
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetMouseButton(0)) {
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if(Physics.Raycast(ray,out hit,Mathf.Infinity)){
				if(hit.collider.transform.tag == "key"){
					FormerAS = AS;
					AS = (AudioSource)hit.collider.gameObject.GetComponent<AudioSource>();
					if(FormerAS !=AS&&FormerAS!=null){
						FormerAS.Stop ();
					}
					if(!AS.isPlaying){
					    AS.volume = volume;
					    AS.Play();
						SolutionTest(AS.gameObject.name[0]);
					}
				}
			}
		}
		if (AS!=null&&Input.GetMouseButtonUp (0)) {
			AS.Stop();
		}
	}

	void SolutionTest(char c){
		if (song.Length == 0) {
			return;
		}
		if (c != song [SolutionCount]) {
			Debug.Log ("wrong path");
			SolutionCount = 0;
		} 
		else {
			if(SolutionCount<song.Length-1){
			    Debug.Log ("so far so good");
			    SolutionCount++;
			}
			else{
				Debug.Log ("Congratulation!");
				SolutionCount = 0;
			}
		}


	}

	public void StartToPlaySong(){
		StartCoroutine ("PlaySong");
	}

	public IEnumerator PlaySong(){
		int count = 0;
		while (count<song.Length) {
			var note = -1;
			switch (song [count]) {
			case 'C':
					note = 0;
					break;
			case 'D':
					note = 2;
					break;
			case 'E':
					note = 4;
					break;
			case 'F':
					note = 5;
					break;
			case 'G':
					note = 7;
					break;
			case 'A':
					note = 9;
					break;
			case 'B':
					note = 11;
					break;
			}
			if(note>=0){
				SampleAudio.pitch = Mathf.Pow(2,(note+transpose)/12.0f);
				SampleAudio.Play ();
				count++;
				yield return new WaitForSeconds(1.0f);
			}
			else{
				Debug.Log ("Invalid Song notes");
				yield break;
			}
		}

	}
	
}
