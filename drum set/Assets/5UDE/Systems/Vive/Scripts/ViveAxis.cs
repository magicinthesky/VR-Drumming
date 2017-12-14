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

public class ViveAxis : CommonAxis {
	
    // Enumerate Vive axis names
    public enum ViveAxisName
    {
        Touchpad,
        Trigger
    };

    // Reveal button name in the Inspector
    public ViveAxisName axisName;

    // Private variables
    SteamVR_TrackedObject trackedObject = null;

    // Called at the end of the program initialization
    protected override void Start () {
		
        // Get the Vive Controller from parent
        trackedObject = GetComponentInParent<SteamVR_TrackedObject> ();
    }

    // Called every graphical frame
    protected override void Update () {
		
		// Check that tracked object is valid
		if (trackedObject != null && trackedObject.isActiveAndEnabled) {
			
			// Get the Vive Controller's input 
			var device = SteamVR_Controller.Input ((int)trackedObject.index);

			// Determine which axis to check
			Valve.VR.EVRButtonId axisMask;

			// Get trigger axis
			if (axisName == ViveAxisName.Trigger) {
				axisMask = Valve.VR.EVRButtonId.k_EButton_Axis1;
			} 

			// Get touchpad axis by default
			else {
				axisMask = Valve.VR.EVRButtonId.k_EButton_Axis0;
			}

			// Get the Vive Controller's axis values
			axis = device.GetAxis (axisMask);
		}
	}

	// Called by the Vive Simulator
	public void Simulate (Vector2 setAxis) {
		
		// Ensure the simulated X axis is valid
		if (setAxis.x < -1.0f) {
			setAxis.x = -1.0f;
		} 
		else if (setAxis.x > 1.0f) {
			setAxis.x = 1.0f;
		}

		// Ensure the simulated Y axis is valid
		if (setAxis.y < -1.0f) {
			setAxis.y = -1.0f;
		} 
		else if (setAxis.y > 1.0f) {
			setAxis.y = 1.0f;
		}

		// Set axis to simulated values
		axis = setAxis;
	}
}