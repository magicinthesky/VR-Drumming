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

public class Movement : MonoBehaviour {

	// Inspector parameters
	public Route route;
	public bool play = true;
	public bool loop = false;
	public float speed = 1.0f;

	// Private variables
	private int target = 0;
	
	// Called every graphical frame
	void Update () {

		// If movement is playing and there's a valid route
		if (play && route.Length () > 0) {

			// Determine the object's distance to the target position in the route
			float distance = Vector3.Distance (transform.position, route.points [target].position);
			// Determine the object's direction to the target position in the route
			Vector3 direction = Vector3.Normalize (route.points [target].position - transform.position);

			// Move the object toward the target if speed is less than distance
			if ((speed * Time.deltaTime) < distance) {
				transform.position += direction * speed * Time.deltaTime;
			}

			// Otherwise move the object to the target and update target
			else {
				transform.position = route.points [target].position;
				// Move to next target
				target++;

				// Reset target if end is passed
				if (target >= route.Length ()) {
					target = 0;

					// Stop playing if not looping
					if (!loop) {
						play = false;
					}
				}
			}
		}
	}
}
