using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour {
	
	#region Fields
	
	// timer duration
	float totalSeconds = 0;
	
	// timer execution
	float elapsedSeconds = 0;
	bool running = false;
	
	// support for Finished property
	bool started = false;
	
	#endregion
	
	#region Properties
	
	/// <value>duration</value>
	public float Duration {
		set {
			if (!running) {
				totalSeconds = value;
			}
		}
	}
	
	/// <value>true if finished; otherwise, false.</value>
	public bool Finished {
		get { return started && !running; } 
	}
	
	/// <value>true if running; otherwise, false.</value>
	public bool Running {
		get { return running; }
	}
	
	#endregion
	
	#region Methods
	
	// Update is called once per frame
	void Update () {
		
		// update timer and check for finished
		if (running) {
			elapsedSeconds += Time.deltaTime;
			if (elapsedSeconds >= totalSeconds) {
				running = false;
			}
		}
	}
	
	public void Run () {
		
		if (totalSeconds > 0) {
			started = true;
			running = true;
            elapsedSeconds = 0;
		}
	}
	
	#endregion
}
