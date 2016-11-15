using UnityEngine;
using System.Collections;

public class MimicHead : MonoBehaviour {
	public GameObject followedObject;

    // Use this for initialization
    void Start()
    {
        transform.parent = followedObject.transform;
    }

    void followPosition()
    {
        Vector3 _tmp = followedObject.transform.position;
        _tmp.x = (followedObject.transform.position.x - .14f);
        _tmp.y = followedObject.transform.position.y + .035f;
        _tmp.z = followedObject.transform.position.z;
        this.transform.position = _tmp;
    }

    void followRotation() {
        Vector3 _tmp2 = followedObject.transform.eulerAngles;
        _tmp2.x = followedObject.transform.eulerAngles.x;
        _tmp2.y = followedObject.transform.eulerAngles.y;
        _tmp2.z = followedObject.transform.eulerAngles.z;
        this.transform.eulerAngles = _tmp2;
    }

    // Update is called once per frame
    void Update()
    {
        followPosition();
        followRotation (); 
    }
}
