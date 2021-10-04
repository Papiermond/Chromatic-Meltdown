using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSightSpawner : MonoBehaviour
{
    private float timer;
    public float SightInterval;


    void Update()
    {
        timer += Time.deltaTime;

        if(SightInterval < timer)
        {
            timer = 0;
            var sight = PoolManager.Instance.GetSight();
            sight.SetActive(true);
            sight.transform.localScale = new Vector3(8,8,8);
            sight.transform.position = transform.position;
        }

        var tempVec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        tempVec.z = 0;
        transform.position = tempVec;
    }
}
