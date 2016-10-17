using UnityEngine;
using System.Collections;

public class Cat1Script : MonoBehaviour
{

    /*
     * 
     * Handle the cat actions
     * and keep track of cat
     * animations/death
     * 
     */

    // Min time to wait for cat reset
    private const int catResetMinSeconds = 3;
    // Max time to wait for cat reset
    private const int catResetMaxSeconds = 6;
    //Max cat speed
    private const int maxCatSpeed = 5;

    // Animator to call to change animations
    public Animator anim;
    // Current speed of the cat
    public float speed;
    // Transform to handle changing cat directions
    public Transform myTrans;


    // If the cat is alive or dead
    bool alive;

    // Use this for initialization
    void Start()
    {
        // Get the transform of the current cat
        // along with the animation
        myTrans = this.transform;
        anim = gameObject.GetComponent<Animator>();
        alive = true; // Cat defaults to alive
    }

    // Update is called once per frame
    void Update()
    {
        // Update the cat speed
        // direction is checked through in the update
        transform.Translate(new Vector3(speed, 0, 0) * 120 * Time.deltaTime);
    }

    // Handle clicking on the cat
    void OnMouseDown()
    {
        if (alive)
        {
            /*
             * If the cat is alive, start playing the
             * hit sound but delayed, set alive to false,
             * trigger the die animation,
             * and start the coroutine to reset the cat
             */
            this.GetComponent<AudioSource>().PlayDelayed(0.1f);
            alive = false;
            anim.SetTrigger("DieOnClick");
            StartCoroutine(SlowDown());
            StartCoroutine(ResetCat());
        }

    }

    /*
     * Reset the cat corouting
     */
    IEnumerator ResetCat()
    {
        Debug.Log("Resetting cat wait");
        /*
         * Wait a random value of time between the resets after being shot
         */
        yield return new WaitForSeconds(Random.Range(catResetMinSeconds, catResetMaxSeconds));
        Debug.Log("Returing to homescreen");

        /*
         * Run the reset animation
         * reset speed and alive status
         */
        anim.SetTrigger("Reset");
        speed = 2;
        alive = true;
    }


    /*
     * Iterate over slowing the cat down
     * in increments of 10 over the course
     * of a second
     */
    IEnumerator SlowDown()
    {
        float slowDownIncrement = speed / 10;
        for(int i = 0; i < 10; i++)
        {
            speed -= slowDownIncrement;
            yield return new WaitForSeconds(0.1f);
        }
        speed = 0;
    }

    /*
     * handle colosions with the side wall
     */
    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.tag == "block")
        {
            Vector3 currRot = myTrans.eulerAngles;
            currRot.y += 180;
            myTrans.eulerAngles = currRot;
            speed = Mathf.Min(speed + 1, maxCatSpeed);

        }

    }




}
