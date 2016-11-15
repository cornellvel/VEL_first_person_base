using UnityEngine;
using System.Collections;

public class DestroyBubble : MonoBehaviour {

   

    //timer for countdown
    public int i = 0;
    public float lifetime;
    // Use this for initialization
    void Start () {
        //gets the lifetime from duplicateself
        lifetime = GameObject.Find("BubbleGUI").GetComponent<DuplicateSelf>().reallifetime;
        //timer increment
        InvokeRepeating("DoSomething", 0f, 1f);

    }

    void DoSomething()
    {
        i = i + 1;
        if (i == lifetime)
            DestroyThis();   
    }

    //destroys object when timer hits lifetime
    void DestroyThis ()
    {
        Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
