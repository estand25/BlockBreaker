using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	public bool autoPlay  = false;
	public float minLimit,maxLimit;
	public static int paddleLive;
	
	private Ball ball;
	
	void Start(){
		// Set the class level ball to the current ball in the game
		ball = GameObject.FindObjectOfType<Ball>();
		
		// Initialize the Paddle lives at 3 (counting the one on the board already)
		paddleLive = 2;
	}
	
	// Update is called once per frame
	void Update () {
		// Check if autoply if false then go to mouse handle paddle method
		// else let the computer handle moving the padded
		if(!autoPlay){
			MoveWithMouse();
		}else {
			AutoPlay();
		}
	}
	
	// (Computer) Automatic plays at the paddle	
	void AutoPlay(){
		// Get the currrent paddle location
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		
		// Get the ball location
		Vector3 ballPos = ball.transform.position;
		
		// Make sure the paddle doesn't go outside of the game board
		paddlePos.x = Mathf.Clamp(ballPos.x,minLimit,maxLimit);		
		
		// Move the paddle to the same location at the ball
		this.transform.position = paddlePos;
	}
	
	// Move the Paddle with the Mouse
	void MoveWithMouse(){
		// Get the current Paddle location
		Vector3 paddlePos = new Vector3(0.5f,this.transform.position.y,0f);
		
		// Get the mouth location (basically)
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width*16);	
		
		// Make sure the paddle doesn't go outside of the game board
		paddlePos.x = Mathf.Clamp(mousePosInBlocks,minLimit,maxLimit);			
		
		// Move the paddle to the same location at the ball		
		this.transform.position = paddlePos;
	}
}
