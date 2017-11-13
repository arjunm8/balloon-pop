using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class colorMode : MonoBehaviour {
    public Text colorView;
    public int color;

    public Text popsView;
    public int popCount;

    int bluecount=0;

    // Use this for initialization
    void Start () {
        //init score
        popCount = 0;
        switchColor();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //move back to menu
            SceneManager.LoadScene("menu", LoadSceneMode.Single);
        }
    }

    public void switchColor() {
        //switch global color
        color = (bluecount >= 8) ? 0 : ((bluecount <= 2) ? 1 : Random.Range(0, 2));
        colorView.text = (color == 0) ? "BLUE" : "RED";
    }

    public int getColor(){
        //getter for global color
        return color;
    }

    public void popsUpdate(){
        //keep the score
        popCount++;
        popsView.text = "Pops: " + popCount;
    }

    public void colorRatio(int br, bool isPopped)
    {
        //keep a tab on the color ratio
        bluecount += (br == 0 && isPopped)? -1 : (br == 0)? 1 : 0;
        Debug.Log("blueCount:"+bluecount+ " redcount:" + (10-bluecount) );
    }

}
