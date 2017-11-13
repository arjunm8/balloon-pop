using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class switchScreen : MonoBehaviour {

	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        //handle backpress to quit app
        if (Input.GetKeyDown(KeyCode.Escape)) { Application.Quit(); }
    }

    public void loadscene()
    {
        //called from start button, launches the level
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
    }
}
