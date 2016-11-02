using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class ChestControl : MonoBehaviour
{
    private const int delayToHomeScreenSeconds = 5 * 60;
    private const int chestResetSeconds = 3;

    public Component bl;
    public Component br;
    public Component tl;
    public Component tr;
    public Sprite closedSprite;
    public Sprite[] openChests;

    private bool brOpen;
    private bool blOpen;
    private bool trOpen;
    private bool tlOpen;

    private bool en;

    object chestLock = new object();


    Coroutine moveToHomeScreen;

    // Use this for initialization
    void Start()
    {
        // Initialize each chests open value
        blOpen = false;
        brOpen = false;
        trOpen = false;
        tlOpen = false;

        // Set the chests enabled to true
        en = true;

        // Start the coroutine to move to the homescreen
        moveToHomeScreen = StartCoroutine(backToHomeScreen());
        randomizePosition(bl);
        randomizePosition(br);
        randomizePosition(tr);
        randomizePosition(tl);
    }

    void randomizePosition(Component c)
    {
        Vector2 v = c.transform.position;

        c.transform.position = new Vector2(v.x + Random.Range(-120,120), v.y + Random.Range(-40,40));
    }

    // Corouting to handle moving back to the home screen
    IEnumerator backToHomeScreen()
    {
        Debug.Log("Starting move to homescreen");
        // Wait for the home screen delay
        yield return new WaitForSeconds(delayToHomeScreenSeconds);
        Debug.Log("Returing to homescreen");
        // Load the home scene
        SceneManager.LoadScene(0);

    }

    public void onChestClick(int chest)
    {
        // Check if the chests are enabled. If not, return
        if (!en)
        {
            Debug.Log("Not processing chest click, chests aren't enabled");
            return;
        }

        // Handle stopping the coroutine to go back to the home screen
        StopCoroutine(moveToHomeScreen);

        // Start a new coroutine (effectively reset the timer)
        moveToHomeScreen = StartCoroutine(backToHomeScreen());

        Debug.Log("Chest " + chest + " clicked");
        // 0 for bl
        // 1 for br
        // 2 for tl
        // 3 for tr
        if (0 == chest && !blOpen)
        {
            // Play the chests open sound
            bl.GetComponent<AudioSource>().Play();

            // Change the chests sprite to a random chest
            bl.transform.GetComponent<UnityEngine.UI.Image>().sprite = randomChest();
            blOpen = true;


        }
        else if (1 == chest && !brOpen)
        {
            // Play the chests open sound
            br.GetComponent<AudioSource>().Play();

            // Change the chests sprite to a random chest
            br.transform.GetComponent<UnityEngine.UI.Image>().sprite = randomChest();
            brOpen = true;


        }
        else if (2 == chest && !tlOpen)
        {
            // Play the chests open sound
            tl.GetComponent<AudioSource>().Play();

            // Change the chests sprite to a random chest
            tl.transform.GetComponent<UnityEngine.UI.Image>().sprite = randomChest();
            tlOpen = true;


        }
        else if (3 == chest && !trOpen)
        {
            // Play the chests open sound
            tr.GetComponent<AudioSource>().Play();

            // Change the chests sprite to a random chest
            tr.transform.GetComponent<UnityEngine.UI.Image>().sprite = randomChest();
            trOpen = true;


        }
        else
        {
            Debug.Log("Chest number "
                        + chest
                        + " is not a valid option");
        }

        // If all the chests are open, start the reset coroutine and disable chests
        if (allOpen())
        {
            en = false;
            StartCoroutine(resetChests());
        }

    }


    public IEnumerator resetChests()
    {
        /*
         * Wait for the chest reset time
         */
        Debug.Log("Waiting for all to be open");
        yield return new WaitForSeconds(chestResetSeconds);

        // Set all chests to the closedSprite
        bl.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
        br.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
        tl.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;
        tr.transform.GetComponent<UnityEngine.UI.Image>().sprite = closedSprite;

        // Set all chests to the not open state
        brOpen = false;
        blOpen = false;
        trOpen = false;
        tlOpen = false;

        en = true;
    }

    // Check if all chests are open
    bool allOpen()
    {
        return (brOpen && blOpen && trOpen && tlOpen);
    }

    // Get a random chest from the list of chests
    Sprite randomChest()
    {
        int i = (int) Random.Range(0, openChests.Length);
        return openChests[i];
    }
}
