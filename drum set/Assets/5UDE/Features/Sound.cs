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

public class Sound : MonoBehaviour {

	// Inspector parameters
	[Tooltip("The sound clip you want to play.")]
	public AudioClip audioClip;

	[Tooltip("Play the sound.")]
	public bool play = true;

	[Tooltip("Loop the sound.")]
	public bool loop = false;

	[Tooltip("Mute the sound.")]
	public bool mute = false;

	[Tooltip("Play the sound after delaying a number of seconds.")]
	public float delay = 0.0f;

	[Tooltip("The volume of the sound. Default is 1.0 or 100%.")]
	public float volume = 1.0f;

	[Tooltip("The minimum distance before the sound begins to fade.")]
	public float minDistance = 5.0f;

	[Tooltip("The maximum distance that the sound can be heard from.")]
	public float maxDistance = 500.0f;

	// Private variables
	protected AudioSource audioSource;

	// Called at the start of the program initialization
	void Awake () {

		// Add an audiosource to this gameobject
		audioSource = gameObject.AddComponent<AudioSource> ();
	}


	// Called at the end of the program initialization
	void Start () {

		// Call the update function to handle setting up the sound
		Update ();
	}

	// Called every graphical frame
	void Update () {

		// Set the audiosource's clip if it has changed
		if (audioSource.clip != audioClip) {
			audioSource.clip = audioClip;
		}

		// Set the audiosource's loop setting
		audioSource.loop = loop;
		// Set the audiosource's volume
		audioSource.volume = volume;
		// Set the audiosource's minimum distance
		audioSource.minDistance = minDistance;
		// Set the audiosource's maximum distance
		audioSource.maxDistance = maxDistance;
		// Set the audiosource's blend setting to 3D
		audioSource.spatialBlend = 1.0f;

		// Reduce volume to 0 if the audiosource is muted
		if (mute) {
			audioSource.volume = 0.0f;
		}

		// Play the sound when specified
		if (play) {
			play = false;
			audioSource.PlayDelayed (delay);
		}
	}
}
