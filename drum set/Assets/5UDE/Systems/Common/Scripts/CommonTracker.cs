﻿/*
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

public class CommonTracker : MonoBehaviour 
{
	// Reveal validity of tracking info in the Inspector
    protected bool valid;

    // Called at the end of the program initialization
	protected virtual void Start () {
		
		// Create initial tracking info
        valid = false;
	}

    // Called every graphical frame
	protected virtual void Update () {
		
		// Update virtual and physical tracking info here
	}

	// Public function to retrieve the tracker's position in the virtual environment
	public virtual Vector3 GetVirtualPosition () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return transform.position;
	}

	// Public function to retrieve the tracker's rotation in the virtual environment
	public virtual Quaternion GetVirtualRotation () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return transform.rotation;
	}	

	// Public function to retrieve the tracker's position in the physical tracking space
	public virtual Vector3 GetPhysicalPosition () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return transform.localPosition;
	}

	// Public function to retrieve the tracker's rotation in the physical tracking space
	public virtual Quaternion GetPhysicalRotation () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return transform.localRotation;
	}	

    // Public function to retrieve the tracker's validity
	public virtual bool IsValid () {
		
        // Ensure value is updated first
        Update ();
        // Return the value
        return valid;
    }
}