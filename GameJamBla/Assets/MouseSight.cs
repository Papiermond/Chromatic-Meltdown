using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSight : MonoBehaviour
{

    public float FadeSpeed;
    void Update()
    {
        transform.localScale = new Vector3(transform.localScale.x - Time.deltaTime * FadeSpeed, transform.localScale.x - Time.deltaTime * FadeSpeed, transform.localScale.x - Time.deltaTime * FadeSpeed);
        if (transform.localScale.x < 0.5f)
            gameObject.SetActive(false);
    }
}
