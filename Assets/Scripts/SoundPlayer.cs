using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour {

    /*
     * 
     * Play a sound clip from on mouse down
     * 
     */

    public AudioSource clip;
	
    void OnMouseDown()
    {
        clip.Play();
    }
}
