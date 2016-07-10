using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	
	// Use this for initialization
	void Start () {
		// Set the local paddle to the current game paddle
		paddle = GameObject.FindObjectOfType<Paddle>();
		
		// Get the outside location of the ball on the paddle
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			reBall();
		}
	}
	
	void OnCollisionEnter2D (Collision2D collison){
		// Ball does not trigger sound when brick is destroyed.
		// Not 100% sure why, possibly because brick isn't there
		Vector2 tweak = new Vector2(Random.Range(0f,0.3f),Random.Range(0f,0.3f));
		
		if(hasStarted){
			audio.Play();
			rigidbody2D.velocity += tweak;
			rigidbody2D.drag = Random.Range(-0f,-0.1f);
			print ("Velocity: "+rigidbody2D.velocity+" Drag: "+rigidbody2D.drag);
			
		}
	}
	
	// Set the ball on the Paddle ready for launch
	public void reBall(){
		// Lock the ball relative to the paddle
		this.transform.position = paddle.transform.position + paddleToBallVector;
		
		// Wait for a mouse press to launch
		if(Input.GetMouseButtonDown(0)){
			print("Mouse Clicked, launch ball!!");
			hasStarted = true;		
			this.rigidbody2D.velocity = new Vector2(2f,10f);
		}
	}
}
