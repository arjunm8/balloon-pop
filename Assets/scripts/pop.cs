using UnityEngine;
using System.Collections;

public class pop : MonoBehaviour
{
    private Vector3 spawn_v;
    private int balloon_color;

    void Start()
    {
        //holds the current spawn position
        spawn_v = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseDown()
    {
        //current global poppable color
        colorMode globalColorMode = GameObject.FindWithTag("currentColor").GetComponent<colorMode>();

        //pop condition
        if ( globalColorMode.getColor() == balloon_color) {

            Debug.Log("popped");
            //play the pop sound
            GetComponent<AudioSource>().Play();
            //display pop animation
            GameObject pop = Instantiate(Resources.Load( (balloon_color==0)?"blue_pop_0":"red_pop_0", typeof(GameObject))) as GameObject;
            pop.transform.position = gameObject.transform.position + new Vector3(0,1.4f);
            pop.transform.rotation = gameObject.transform.rotation;

            //score update
            globalColorMode.popsUpdate();

            //maintain color ratio between blue and red
            globalColorMode.colorRatio(balloon_color, true);
            
            // spawn new random colored balloon
            int x = Random.Range(0, 2);
            GameObject nb = Instantiate(Resources.Load( (x==0)?"blueBalloon":"redBalloon" , typeof(GameObject))) as GameObject;
            nb.transform.position = spawn_v;
            nb.transform.rotation = gameObject.transform.rotation;

            //push new random color to spawned object
            nb.GetComponent<pop>().setColor(x);

            //reroll the global poppable color
            globalColorMode.switchColor();
            
            //destroy pop animation and balloon objects
            Destroy(pop, 0.3f);
            Destroy(gameObject);
        }
    }

    public void setColor(int x) {
        this.balloon_color = x;
        //pass new color value to ration maintainer
        GameObject.FindWithTag("currentColor").GetComponent<colorMode>().colorRatio(x,false);
    }

}