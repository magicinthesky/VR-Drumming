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

public class CommonButton : MonoBehaviour {
	
	// Reveal button states in the Inspector
	protected bool touch;
    protected bool touchDown;
    protected bool touchUp;
    protected bool press;
    protected bool pressDown;
    protected bool pressUp;

    // Called at the end of the program initialization
    protected virtual void Start () {
		
        // Create initial states
        touch = touchDown = touchUp = press = pressDown = pressUp = false;
	}

    // Called every graphical frame
	protected virtual void Update () {
		
		// Update button states here
	}

	// Public function to retrieve the button's current touch state
	public virtual bool GetTouch () {

		// Ensure value is updated first
		Update ();
		// Return the value
		return touch;
	}

	// Public function to retrieve whether the button was touched this frame
	public virtual bool GetTouchDown () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return touchDown;
	}

	// Public function to retrieve whether the button was no longer touched this frame
	public virtual bool GetTouchUp () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return touchUp;
	}

	// Public function to retrieve the button's current press state
	public virtual bool GetPress () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return press;
	}

	// Public function to retrieve whether the button was pressed this frame
	public virtual bool GetPressDown () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return pressDown;
	}

	// Public function to retrieve whether the button was no longer pressed this frame
	public virtual bool GetPressUp () {
		
		// Ensure value is updated first
		Update ();
		// Return the value
		return pressUp;
	}
}