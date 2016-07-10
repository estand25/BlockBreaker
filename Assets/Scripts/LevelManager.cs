using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

	// Load level for the name scence
	public void LoadLevel(string name){
		// Output the current load level
		Debug.Log("Level load requested for: "+name);
		
		// Set the initial breakableCount when the level loads
		Brick.breakableCount = 0;
		
		// Load the level
		Application.LoadLevel(name);
	}
	
	// Quit the game
	public void QuitRequest(){
		// Output the quit message
		Debug.Log("I want quit!");
		
		// Quit the application
		Application.Quit();
	}
	
	//Load the next scence based on the build numbers
	public void LoadNextLevel(){
		// Set the initial breakableCount when the level loads
		Brick.breakableCount = 0;
		
		// Load the next level based on the current load level plus 1
		Application.LoadLevel(Application.loadedLevel+1);
	}
	
	public void BrickDestoyed(){
		if(Brick.breakableCount <= 0){
			LoadNextLevel();
		}
	}
}
