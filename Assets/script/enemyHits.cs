using UnityEngine;
using System.Collections;

public class enemyHits : MonoBehaviour
{


	// Use this for initialization
	public Sprite spriteDefault;
	public Sprite spriteHit;
	//public GameObject Summon;
	public bool hit;
	
	public float minhealth;
	public float maxhealth;

	private float healthStart;
	private int myScore;
	private float health;


	private SpriteRenderer spriteRenderer;
	void Start ()
	{
		health = Random.Range(minhealth,maxhealth);
		spriteRenderer = gameObject.GetComponent<SpriteRenderer> ();
	}

	void OnMouseUp()
	{
		spriteRenderer.sprite = spriteHit;

		Invoke ("hitted", 0.5f);
	}

	void hitted(){
		hit = true;
		enemySummon.score++;
		spriteRenderer.sprite = spriteDefault;
		gameObject.SetActive(false);
		health = Random.Range(minhealth,maxhealth);
		if(maxhealth>minhealth){
			maxhealth-=0.2f;
		}
	}

	// Update is called once per frame
	void Update ()
	{
		if(health>0){
			health-=Time.deltaTime;
		}else{
			gameObject.SetActive(false);
			health = Random.Range(minhealth,maxhealth);
		}
	}
}

