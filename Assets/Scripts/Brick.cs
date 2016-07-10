using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {
	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;
	public GameObject smoke;
	
	private int timesHits;
	private LevelManager levelManager;
	private bool isBreakable;
	
	// Use this for initialization
	void Start () {	
		// Set the boolean for if the brick is breakable or not
		isBreakable = (this.tag == "Breakable");
		
		// Keep track of breakable bricks
		if(isBreakable){
			breakableCount++;
		}
		
		print ("Brick Count: "+breakableCount);
		
		// Initize the number of time the brick has been hit to 0
		timesHits = 0;
		
		// Get the Level Manager game object 
		levelManager = GameObject.FindObjectOfType<LevelManager>();
	}
	
	void OnCollisionEnter2D (Collision2D collison){
		// On Collision start playing the specificed sound at the brick's location
		AudioSource.PlayClipAtPoint(crack,transform.position,0.25f);
		
		// Check if the brick is breakable
		// then if breakable check if max hit has been reached
		if(isBreakable){
			Handlehits();
		}
	}
	
	// Handle how the brick reacts to hits
	void Handlehits(){
		// Increase the number of times the brick has been hit
		timesHits++;
		
		// Set the max number of hit to the number of sprites is the list of sprite 
		// for the brick
		int maxHits = hitSprites.Length+1;
		
		// Detory the brick when it has max out its hits
		if(timesHits >= maxHits){
			breakableCount--;
			levelManager.BrickDestoyed();
			PuffSmoke();
			Destroy(gameObject);
		}else {
			LoadSprites();
		}
	}
	
	// Generates the puff for the brick
	void PuffSmoke(){
		// Create new instance of the snoke at the brick's fromer location
		GameObject smokePuff = Instantiate(smoke,gameObject.transform.position,Quaternion.identity) as GameObject;
		
		// Set the starting color to the bricks color
		smokePuff.particleSystem.startColor = gameObject.GetComponent<SpriteRenderer>().color;
		
		//Destroy The Extinguished Smoke Instance
		//---------------------------------------
		//Create a variable 'smokeLife' to hold the length of time the smoke will be visible. 
		float smokeLife = smokePuff.GetComponent<ParticleSystem>().duration + smokePuff.GetComponent<ParticleSystem>().startLifetime;
		//Destroy the 'smokePuff' instance after it has finished its animation. 
		Destroy(smokePuff, smokeLife);  
	}
	
	// Move the sprite image per the number of hit - 1 (to match Sprite array)
	void LoadSprites(){
		// Set the local sprite array index handler
		int spriteIndex = timesHits - 1;
		
		// Check if array at index location has an Sprite and set the brick to that sprite
		// else it output an error log to console
		if(this.hitSprites[spriteIndex]){
			this.GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
		}else  {
			Debug.LogError("Not Sptite Object was found");
		}
	}	
}
