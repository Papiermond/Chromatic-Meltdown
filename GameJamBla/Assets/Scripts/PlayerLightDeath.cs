using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLightDeath : MonoBehaviour
{
    public AnimationCurve LightEffect;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime / 2;
        transform.localScale = new Vector3(LightEffect.Evaluate(timer) * 10, LightEffect.Evaluate(timer) * 10,1);

        if (timer > 1)
            Destroy(this.gameObject);
    }
}
