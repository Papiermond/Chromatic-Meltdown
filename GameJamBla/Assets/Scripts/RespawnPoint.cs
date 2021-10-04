using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPoint : MonoBehaviour
{
    public GameObject LightEffect;
    public GameObject activateEffect;
    bool Active = false;

    void Update()
    {
        if(Vector3.Distance(ReferenceManager.Instance.Player.transform.position,transform.position) < 2f && !Active)
        {
            RespawnManager.Instance.ActiveRespawns.Add(this.gameObject.transform);
            Active = true;
            LightEffect.SetActive(true);
            Instantiate(activateEffect,transform.position,transform.rotation);
        }
    }
}
