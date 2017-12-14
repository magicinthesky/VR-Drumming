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

public class SimViveTracker : MonoBehaviour {

	// Tracker to simulate
	[HideInInspector]
	public ViveTracker viveTracker;

	// Private variable
	bool valid = true;

	// Called every graphical frame
	void Update () {

		// Validate the tracker
		ValidateTracker ();
		// Simulate the tracker
		viveTracker.Simulate(valid, transform.localPosition, transform.localRotation);
	}

	// Check that the tracker is within the expected physical range
	void ValidateTracker () {

		// Validate physical tracked position
		Vector3 physicalPosition = transform.localPosition;

		// Invalid if out of lateral range
		if (physicalPosition.x < -2.5f || 2.5f < physicalPosition.x) {
			valid = false;
		}
		// Invalid if out of longitudinal range
		else if (physicalPosition.z < -2.5f || 2.5f < physicalPosition.z) {
			valid = false;
		}
		// Otherwise validate within range and fix camera
		else {
			valid = true;
		}
	}
}
