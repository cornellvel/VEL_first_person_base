using UnityEngine;
using System.Collections;

public class RH_Follow_LH_Mirror : MonoBehaviour
{

    public GameObject rightHand;
    public GameObject leftHand;
    public GameObject headset;
    //the coordinates (x, y, z) in output, z appears to be the variable that would be affected by mirroring in our world. 
    //when the participant is facing the balloons, with both hands at her side, RHz < Headz < LHz
    //So, when RHz > Headz, that means that the right hand has crossed the midline and the left hand will have to cross the midline the other way.

    void Update()
    {
        //Transforming position works fine:
        //if RHz < Headz
        if (leftHand.transform.position.z < headset.transform.position.z)
        {
            //set a temporary variable because you can't set one GameObject's position to the position of another GameObject 
            Vector3 _tmp = rightHand.transform.position;
            //LH(x)=RH(x)
            _tmp.x = leftHand.transform.position.x;
            //LH(y)=RH(y)
            _tmp.y = leftHand.transform.position.y;
            //LH(z)=((absolute value(Headz-RHz))+Headz)
            _tmp.z = Mathf.Abs(headset.transform.position.z - leftHand.transform.position.z) + headset.transform.position.z;
            rightHand.transform.position = _tmp;
        }
        //if RHz > Headz
        if (leftHand.transform.position.z > headset.transform.position.z)
        {
            Vector3 _tmp2 = rightHand.transform.position;
            //LH(x)=RH(x)
            _tmp2.x = leftHand.transform.position.x;
            //LH(y)=RH(y)
            _tmp2.y = leftHand.transform.position.y;
            //LH(z)=(Headz-(absolute value(RHz-Headz)))
            _tmp2.z = headset.transform.position.z - Mathf.Abs(leftHand.transform.position.z - headset.transform.position.z);
            rightHand.transform.position = _tmp2;
        }

        //set a temporary variable because you can't set one GameObject's position to the position of another GameObject 
        Vector3 _tmp4 = rightHand.transform.position;
        //For some weird reason, pitch and roll are reversed on the left hand!
        _tmp4.x = ((-1 * leftHand.transform.eulerAngles.z));
        //yaw should be opposite
        _tmp4.y = (45 - (leftHand.transform.eulerAngles.y - 45));
        //roll should be opposite
        _tmp4.z = (-1 * leftHand.transform.eulerAngles.x);
        //_tmp4.z = (rightHand.transform.eulerAngles.z - 180);
        rightHand.transform.eulerAngles = _tmp4;


        //if (rightHand.transform.eulerAngles.z > 45)
        //{
        //    //set a temporary variable because you can't set one GameObject's position to the position of another GameObject 
        //    Vector3 _tmp4 = leftHand.transform.position;
        //    //pitch should be the same for both hands
        //    _tmp4.x = (-1 * rightHand.transform.eulerAngles.z);
        //    //yaw should be opposite
        //    _tmp4.y = (45 - (rightHand.transform.eulerAngles.y - 45));
        //    //roll should be opposite
        //    _tmp4.z = (-1 * rightHand.transform.eulerAngles.x);
        //    //_tmp4.z = (rightHand.transform.eulerAngles.z - 180);
        //    leftHand.transform.eulerAngles = _tmp4;
        //}
        ////To Transform Orientation
        //if (rightHand.transform.eulerAngles.z <= 45)
        //{
        //    //set a temporary variable because you can't set one GameObject's position to the position of another GameObject 
        //    Vector3 _tmp3 = leftHand.transform.position;
        //    //pitch should be the same for both hands
        //    _tmp3.x = (-1 * rightHand.transform.eulerAngles.z);
        //    //yaw should be opposite, and left hand rotation is -180-0-180. so going counterclockwise should work for yaw
        //    _tmp3.y = (45 + (rightHand.transform.eulerAngles.y - 45));
        //    //_tmp3.y = (rightHand.transform.eulerAngles.y - 180);
        //    //roll should be opposite too, but in this case it needs to go negative
        //    _tmp3.z = (-1 * rightHand.transform.eulerAngles.z);
        //    //_tmp3.z = (rightHand.transform.eulerAngles.z + 180);
        //    Debug.Log("It's greater than 45!!");
        //    leftHand.transform.eulerAngles = _tmp3;
        //}
    }
}