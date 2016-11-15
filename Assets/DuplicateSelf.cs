using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DuplicateSelf : MonoBehaviour
{
    public GameObject bubble;
    public GameObject plane;
    //time the bubble is visible
    public float planeX;
    public float planeY;
    public float planeZ;
    Dictionary<GameObject, int> bubbles2 = new Dictionary<GameObject, int>();
    public UnityEngine.UI.Dropdown numBubbles;
    public UnityEngine.UI.Dropdown lifetime;
    public UnityEngine.UI.Dropdown BubbleSize;
    public UnityEngine.UI.Dropdown Frequency;
    public int i = 0;
    public float realNumBubbles;
    public float reallifetime;
    public float realBubbleSize;
    public float realFrequency;
    GameObject newObj;



    // Use this for initialization
    public void makeBubbles()
    {
        Debug.Log("HI");
        if (numBubbles.value == 0)
            realNumBubbles = 50f;
        else
            realNumBubbles = 50f + 50f * numBubbles.value;

        if (lifetime.value == 0)
            reallifetime = 5f;
        else
            reallifetime = 5 * numBubbles.value;

        realBubbleSize = BubbleSize.value + 1;

        createNewBubbles();
        Destroy(GameObject.Find("StartMenu"));
    }

    //Creates a Vector3 with random coordinates within the limitations of the plane .
    Vector3 createRandomPos()
    {
        //float randomY = Random.Range (plane.transform.position.y - plane.transform.localScale.y/2, plane.transform.position.y + plane.transform.localScale.y/2);
        float randomY = Random.Range(plane.transform.position.y - plane.transform.localScale.y / 2, (plane.transform.position.y + plane.transform.localScale.y / 2));
        float randomZ = Random.Range(plane.transform.position.z - plane.transform.localScale.z / 2, (plane.transform.position.z + plane.transform.localScale.z / 2));
        return new Vector3(plane.transform.position.x, randomY, randomZ);
    }

    //Creates a Vector3 that gives a random bubble size from 0.09 to 0.30.
    Vector3 createRandomSize()
    {
        float randomSize = Random.Range(0.09f, 0.30f);
        return new Vector3(.5f, 2f, 1f);
    }

    //Creates the number of bubbles indicated by numBubbles with a random position and size as well as the "bubble" tag. The object
    //created is attached with the DestroyBubble Script which will destroy the bubble after a 'lifetime' of seconds.
    void createNewBubbles()
    {
        StartCoroutine(makeBubblesWithDelay());
        /*
        for (; i < numBubbles.value * 5; i++)
        {
            newObj = (GameObject)Instantiate(bubble, createRandomPos(), Quaternion.identity);
            newObj.tag = "bubble";
            newObj.GetComponent<Rigidbody>().useGravity = false;
            newObj.transform.localScale = Vector3.one * realBubbleSize * .07f;
            newObj.AddComponent<DestroyBubble>();
            bubbles2.Add(newObj, 5);
        }
        */
        //}
    }

    public int getRemainingTime(GameObject obj)
    {
        return this.bubbles2[obj];
    }

    IEnumerator makeBubblesWithDelay()
    {
        for (; i < realNumBubbles ; i++)
        {
            newObj = (GameObject)Instantiate(bubble, createRandomPos(), Quaternion.identity);
            newObj.tag = "bubble";
            newObj.GetComponent<Rigidbody>().useGravity = false;
            newObj.transform.localScale = Vector3.one * realBubbleSize * .2f;
            newObj.AddComponent<DestroyBubble>();
            bubbles2.Add(newObj, 5);
            yield return new WaitForSeconds(.5f);

        }
    }

}