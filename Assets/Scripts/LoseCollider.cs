using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {
	private LevelManager levelManager;
	private Ball ball;
	
	// On triggering of the collider we go to the lose scense
	void OnTriggerEnter2D (Collider2D trigger){
		// Set the local level manager to the current level manager
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		ball = GameObject.FindObjectOfType<Ball>();
		
		if(Paddle.paddleLive == 0){
			// Load the lose scence
			levelManager.LoadLevel("Lose");
			Paddle.paddleLive = 2;
		}else{
		    Paddle.paddleLive--;
			ball.reBall();
			print (Paddle.paddleLive);
		}
	}
	
	void OnCollisionEnter2D (Collision2D collison){
		print ("Collison");
	}
}