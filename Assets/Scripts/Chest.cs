using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour {

    public int chest;
    public ChestControl canv;

    void OnMouseDown()
    {
        canv.GetComponent<ChestControl>().onChestClick(chest);
    }
}
