using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundChange : MonoBehaviour {

    private const int bgChangeTimeSeconds = 5 * 60;

    IEnumerator BGChangeRoutine()
    {
        yield return new WaitForSeconds(bgChangeTimeSeconds);
        this.GetComponent<SpriteRenderer>().sortingOrder = 0;
        yield return new WaitForSeconds(bgChangeTimeSeconds);
        this.GetComponent<SpriteRenderer>().sortingOrder = -1;
        BGChangeRoutine();

    }
	// Update is called once per frame
	void Update () {
		
	}

    void Start()
    {
        StartCoroutine(BGChangeRoutine());
    }
}
