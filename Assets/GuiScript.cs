using UnityEngine;
using System.Collections;

public class GuiScript : MonoBehaviour {
    // Use this for initialization
    DuplicateSelf startingScript; 
	void start () {
        startingScript =  GameObject.FindObjectOfType(typeof(DuplicateSelf)) as DuplicateSelf;
        Debug.Log("hi");
       
	}

    void onClick()
    {
        Debug.Log("start is being clicked");
        startingScript.makeBubbles();
        Destroy(GameObject.Find("Info"));
        Destroy(this.transform.parent.gameObject);
    }
	
	
}
