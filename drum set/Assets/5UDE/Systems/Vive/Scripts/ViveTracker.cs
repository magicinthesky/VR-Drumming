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

public class ViveTracker : CommonTracker {
	
    // Private variables
    SteamVR_TrackedObject trackedObject = null;

    // Called at the end of the program initialization
    protected override void Start () {
		
        // Get the Vive Controller from parent
        trackedObject = GetComponent<SteamVR_TrackedObject> ();
    }

    // Called every graphical frame
    protected override void Update () {
		
        // Check that tracked object is valid
		if (trackedObject != null && trackedObject.isActiveAndEnabled) {
			
			// Get the Vive Controller's input
			var device = SteamVR_Controller.Input ((int)trackedObject.index);
			// Check if it is valid
			valid = device.valid && device.connected && device.hasTracking && !device.outOfRange;
		}
	}

	// Public function to retrieve the tracker's position in the physical tracking space
	public override Vector3 GetPhysicalPosition () {

		// Ensure value is updated first
		Update ();
		// Return the local position relative to the Vive tracking space
		return transform.parent.parent.parent.InverseTransformPoint(transform.parent.position);
	}

	// Public function to retrieve the tracker's rotation in the physical tracking space
	public override Quaternion GetPhysicalRotation () {

		// Ensure value is updated first
		Update ();
		// Return the local rotation relative to the Vive tracking space
		return transform.parent.localRotation * transform.parent.parent.localRotation;
	}	

	// Called by the Vive Simulator
	public void Simulate (bool setValid, Vector3 physicalPosition, Quaternion physicalRotation) {
		
		// Simulate validity
		valid = setValid;

		// If valid, update simulated position and rotation
		if (valid) {
			transform.localPosition = physicalPosition;
			transform.localRotation = physicalRotation;
		}
	}
}