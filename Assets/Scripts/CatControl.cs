using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatControl : MonoBehaviour {

    public Component tail;
    float rotation;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //tail.transform.rotation.eulerAngles.Set(0, 0, 0.5f);
        //tail.transform.Rotate(Vector3.forward * 100 * Time.deltaTime);
    }
}
