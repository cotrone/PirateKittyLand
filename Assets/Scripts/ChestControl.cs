using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour {

    public Component bl;
    public Component br;
    public Component tl;
    public Component tr;
    public Sprite closedSprite;
    public Sprite openSprite;

    private bool brOpen;
    private bool blOpen;
    private bool trOpen;
    private bool tlOpen;
    // Use this for initialization
    void Start () {
        blOpen = false;
        brOpen = false;
        trOpen = false;
        tlOpen = false;

	}
	// Update is called once per frame
	void Update () {

    }

    public void onChestClick(int chest)
    {
 
        StartCoroutine(handleChestClick(chest));
    }


    public IEnumerator handleChestClick(int chest)
    {
        Debug.Log("Chest " + chest + " clicked");
        // 0 for bl
        // 1 for br
        // 2 for tl
        // 3 for tr
        if(0 == chest && !blOpen)
        {
            bl.transform.GetComponent<UnityEngine.UI.Image>().sprite = openSprite;
            blOpen = true;
        }else if(1 == chest && !brOpen)
        {
            br.transform.GetComponent<UnityEngine.UI.Image>().sprite = openSprite;
            brOpen = true;

        }
        else if (2 == chest && !tlOpen)
        {
            tl.transform.GetComponent<UnityEngine.UI.Image>().sprite = openSprite;
            tlOpen = true;

        }
        else if (3 == chest && !trOpen)
        {
            tr.transform.GetComponent<UnityEngine.UI.Image>().sprite = openSprite;
            trOpen = true;

        }
        else
        {
            Debug.Log("Chest number " 
                        + chest 
                        + " is not a valid option");
        }

        if (allOpen())
        {
            Debug.Log("Waiting for all to be open");
            yield return new WaitForSeconds(5);
            bl.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
            br.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
            tl.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
            tr.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;

            brOpen = false;
            blOpen = false;
            trOpen = false;
            tlOpen = false;
        }
    }

    bool allOpen()
    {
        return (brOpen && blOpen && trOpen && tlOpen);
    }
}
