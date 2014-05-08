using UnityEngine;
using System.Collections;

public class enemySummon : MonoBehaviour {

	public GameObject[] enemy;
	public GameObject SCORE;
	public GameObject TIMER;
	public GameObject textGameOver;
	public GameObject shade;

	public float minTimeSpan;
	public float maxTimeSpan;
	public float time;

	[HideInInspector]
	public float baseTime;
	[HideInInspector]
	public bool gameOver = false;
	[HideInInspector]
	public bool increaseDiff = false;

	[HideInInspector]
	public static int score;

	private bool sekali = true;
	private float countdown;
	//private TextMesh textMeshTimer;

	void Start () {
		baseTime=time;
		StartCoroutine(Timer());
		StartCoroutine(Summon());
		shade.SetActive(false);
	}

	IEnumerator Timer()
	{
		yield return new WaitForSeconds(1);
		time-=1;
		if(time<=0)
		{
			TIMER.GetComponent<TextMesh>().text = time.ToString();
			gameOver=true;
			textGameOver.GetComponent<MeshRenderer>().enabled=true;
		}
		else
		{
			TIMER.GetComponent<TextMesh>().text = time.ToString();
			StartCoroutine(Timer ());
		}
	}


	IEnumerator Summon()
	{
		if(gameOver==false)
		{
			countdown = Random.Range(minTimeSpan, maxTimeSpan);
			yield return new WaitForSeconds(countdown);
			summon();
			if(maxTimeSpan>minTimeSpan){
				maxTimeSpan-=0.3f;
			}
			StartCoroutine(Summon());
		}

	}

	// Update is called once per frame
	void Update () {
		SCORE.GetComponent<TextMesh>().text = score+"";
		if(gameOver==true)
		{
			shade.SetActive(true);
			if(Input.GetMouseButton(0))
			{
				Application.LoadLevel("whack");
				score=0;
			}
		}

		if(time<baseTime/4){

			increaseDiff = true;
		}
		if(increaseDiff==true)
		{
			if(sekali==true)
			{
				Debug.Log("jalan");	
				StartCoroutine(Summon());
				sekali = false;
			}
		}
	}

	void summon(){
		int enemyActive = Random.Range(0,9);
		enemy[enemyActive].SetActive(true);
	}
}

