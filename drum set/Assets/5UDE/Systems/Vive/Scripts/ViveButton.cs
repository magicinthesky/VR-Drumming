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

public class ViveButton : CommonButton {
	
    // Enumerate Vive button names
	public enum ViveButtonName {
        Grip,
        Menu,
        System,
        Touchpad,
        Trigger
    };

    // Reveal button name in the Inspector
    public ViveButtonName buttonName;

    // Private variables
    SteamVR_TrackedObject trackedObject = null;
	bool simulatedPress;

    // Called at the end of the program initialization
    protected override void Start () {
		
		// Get the Vive Controller from parent
		trackedObject = GetComponentInParent<SteamVR_TrackedObject> ();
		// Track simulated press events
		simulatedPress = false;
    }

    // Called every graphical frame
    protected override void Update ()
	{
		// Check that tracked object is valid
		if (trackedObject != null && trackedObject.isActiveAndEnabled) {
			
			// Get the Vive Controller's input
			var device = SteamVR_Controller.Input ((int)trackedObject.index);
			// Determine which button to check
			ulong buttonMask;

			// Get grip button
			if (buttonName == ViveButtonName.Grip) {
				buttonMask = SteamVR_Controller.ButtonMask.Grip;
			}

			// Get menu button
			else if (buttonName == ViveButtonName.Menu) {
				buttonMask = SteamVR_Controller.ButtonMask.ApplicationMenu;
			}

			// Get system button
			else if (buttonName == ViveButtonName.System) {
				buttonMask = SteamVR_Controller.ButtonMask.System;
			}

			// Get touchpad button
			else if (buttonName == ViveButtonName.Touchpad) {
				buttonMask = SteamVR_Controller.ButtonMask.Touchpad;
			}

			// Get trigger button by default
			else {
				buttonMask = SteamVR_Controller.ButtonMask.Trigger;
			}

			// Get the Vive Controller's button touch state
			touch = device.GetTouch (buttonMask);
			// Get the Vive Controller's button touch down state
			touchDown = device.GetTouchDown (buttonMask);
			// Get the Vive Controller's button touch up state
			touchUp = device.GetTouchUp (buttonMask);
			// Get the Vive Controller's button press state
			press = device.GetPress (buttonMask);
			// Get the Vive Controller's button press down state
			pressDown = device.GetPressDown (buttonMask);
			// Get the Vive Controller's button press up state
			pressUp = device.GetPressUp (buttonMask);
		}
	}

	// Called by the Vive Simulator to simulate pressing button
	public void simulatePressDown () {
		
		// If press state has changed
		if (!simulatedPress) {
			
			// Down states are true
			touchDown = pressDown = true;
		}

		// Touch and press states are true
		touch = press = true;
		// Simulated press state is true
		simulatedPress = true;
		// Up states are false
		touchUp = pressUp = false;
	}

	// Called by the Vive Simulator to simulate releasing button
	public void simulatePressUp () {
		
		// If press state has changed
		if (simulatedPress) {
			
			// Up states are true
			touchUp = pressUp = true;
		}

		// Touch and press states are false
		touch = press = false;
		// Simulated press state is false
		simulatedPress = false;
		// Down states are false
		touchDown = pressDown = false;
	}
}