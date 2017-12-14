/*
Copyright ©2017. The University of Texas at Dallas. All Rights Reserved. 

Permission to use, copy, modify, and distribute this software and its documentation for 
educational, research, and not-for-profit purposes, without fee and without a signed 
licensing agreement, is hereby granted, provided that the above copyright notice, this 
paragraph and the following two paragraphs appear in all copies, modifications, and 
distributions. 

Contact The Office of Technology Commercialization, The University of Texas at Dallas, 
800 W. Campbell Road (AD15), Richardson, Texas 75080-3021, (972) 883-4558, 
otc@utdallas.edu, https://research.utdallas.edu/otc for commercial licensing opportunities.

IN NO EVENT SHALL THE UNIVERSITY OF TEXAS AT DALLAS BE LIABLE TO ANY PARTY FOR DIRECT, 
INDIRECT, SPECIAL, INCIDENTAL, OR CONSEQUENTIAL DAMAGES, INCLUDING LOST PROFITS, ARISING 
OUT OF THE USE OF THIS SOFTWARE AND ITS DOCUMENTATION, EVEN IF THE UNIVERSITY OF TEXAS AT 
DALLAS HAS BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

THE UNIVERSITY OF TEXAS AT DALLAS SPECIFICALLY DISCLAIMS ANY WARRANTIES, INCLUDING, BUT 
NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR 
PURPOSE. THE SOFTWARE AND ACCOMPANYING DOCUMENTATION, IF ANY, PROVIDED HEREUNDER IS 
PROVIDED "AS IS". THE UNIVERSITY OF TEXAS AT DALLAS HAS NO OBLIGATION TO PROVIDE 
MAINTENANCE, SUPPORT, UPDATES, ENHANCEMENTS, OR MODIFICATIONS.
*/

using UnityEngine;
using System.Collections;

public class CommonVibration : MonoBehaviour {
	
    // Reveal vibration info in the Inspector
    protected bool vibrate;
    protected float intensity;
    protected float duration;

    // Called at the end of the program initialization
	protected virtual void Start () {
		
        // Create initial vibration values
        vibrate = false;
        intensity = 0.5f;
        duration = 0.0f;
    }

    // Called every graphical frame
	protected virtual void Update () {
		
        // Determine if vibration is on and some duration exists
		if (vibrate && duration > 0.0f) {
			
            // Vibrate at current intensity
            Vibrate (intensity);
            // Reduce duration
            duration -= Time.deltaTime;
        }
        // Vibration is off or duration is up
		else {
			
            // Ensure vibration is off
            vibrate = false;
            // Ensure duration is zero
            duration = 0.0f;
        }
	}

	// Public function to retrieve the vibration's current state
	public virtual bool GetVibration () {

		// Ensure vibration is updated first
		Update ();
		// Return the vibration
		return vibrate;
	}

    // Public function to turn on vibration motor for current frame
	public virtual void Vibrate (float vibrationIntensity) {
		
        // Turn vibration motor on for one frame
    }

    // Public function to turn and keep on vibration motor
	public virtual void VibrateOn (float vibrationIntensity = 0.5f, float seconds = 1.0f) {
		
        // Turn vibration on
        vibrate = true;
        // Set intensity
        intensity = vibrationIntensity;
        // Set duration
        duration = seconds;
        // Call Update to start vibration
        Update ();
    }

    // Public function to turn and keep off vibration motor
	public virtual void VibrateOff () {
		
        // Turn vibration off
        vibrate = false;
        // End duration
        duration = 0.0f;
        // Call Update to end vibration
        Update ();
    }
}