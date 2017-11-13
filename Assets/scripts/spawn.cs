using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class spawn : MonoBehaviour {

	// Use this for initialization
	void Start () { 
        //inital random spawn setup
        int x = Random.Range(0, 2);

        GameObject nb = Instantiate(Resources.Load((x == 0) ? "blueBalloon" : "redBalloon", typeof(GameObject))) as GameObject;
        nb.GetComponent<pop>().setColor(x);
        //init spawn object position
        nb.transform.position = gameObject.transform.position;
        nb.transform.rotation = gameObject.transform.rotation;
    }
	
	// Update is called once per frame
	void Update () {
	
	}

}
