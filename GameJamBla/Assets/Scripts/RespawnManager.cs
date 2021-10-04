using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoSingleton<RespawnManager>
{

    private GameObject Player;
    public float RespawnTime;
    private float timer;

    public List<Transform> ActiveRespawns;

    private void Start()
    {
        Player = ReferenceManager.Instance.Player;
    }

    private void Update()
    {
        timer += Time.deltaTime;

        if (Player.activeInHierarchy)
            timer = 0;
        else if (timer > RespawnTime)
        {
            Vector3 ClosestRespawn = new Vector3(999,999,999);
            for (int i = 0; i < ActiveRespawns.Count; i++)
            {
                if (Vector3.Distance(ActiveRespawns[i].transform.position, Player.transform.position) < Vector3.Distance(ClosestRespawn, Player.transform.position))
                    ClosestRespawn = ActiveRespawns[i].transform.position;
            }

            Player.transform.position = ClosestRespawn;
            ReferenceManager.Instance.PlayerMitCam.SetActive(true);
        }
    }
}
