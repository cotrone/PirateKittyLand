using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
public class MenuControl : MonoBehaviour {
    public void selectLevel(int level) {
        Debug.Log("I work");
        SceneManager.LoadScene(level);
    }

}