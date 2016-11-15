using UnityEngine;
using System.Collections;

public class footTarget : MonoBehaviour {
	public GameObject followedObject; 

	// Use this for initialization
	void Start () {
		transform.parent = followedObject.transform;
	}
	
	void followPosition() {
        Vector3 _tmp = followedObject.transform.position;
        //may need more tweaking to position feet perfectly
        _tmp.x = (followedObject.transform.position.x - .1f);
        _tmp.y = (followedObject.transform.position.y - .1f);
        _tmp.z = followedObject.transform.position.z;
        this.transform.position = _tmp;
    }

	void followRotation()
    {
        Vector3 _tmp2 = followedObject.transform.eulerAngles;
        Debug.Log("Rotation");
        _tmp2.x = followedObject.transform.eulerAngles.x -45;
        _tmp2.y = followedObject.transform.eulerAngles.y -90;
        _tmp2.z = followedObject.transform.eulerAngles.z -90;
        this.transform.eulerAngles = _tmp2;
        print(this.transform.eulerAngles);
    }

    // Update is called once per frame
    void Update()
    {
        followPosition();
        followRotation(); 
    }
}
