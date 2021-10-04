using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouse : MonoBehaviour
{

    void Update()
    {
        var tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tempVec.z = 0;
        transform.position = tempVec; 
    }
}
