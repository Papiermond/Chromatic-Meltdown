using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class GameManager : MonoSingleton<GameManager>
{
    public TilemapRenderer[] illusionTilemapRenderers;/// <summary>
                                                      /// All Tilemaps that should be Invisible Ingame need to be In this Array; Convenience change so we can work with them While visible
                                                      /// </summary>
    public List<GameObject> Crystals;

    public TextMeshProUGUI TMP_Crystals;
    public int MaxNum = 33;
    public GameObject WinObject;
    bool win = false;
    void Start()
    {
        foreach (var TMP_Render in illusionTilemapRenderers)
        {
            TMP_Render.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TMP_Crystals.text = Crystals.Count + " / " + MaxNum;
        foreach (var item in Crystals)
        {
            if (item == null)
            {
                Crystals.Remove(item);
                return;
            }
        }

        if (Crystals.Count == 0 && !win)
        {
            win = !win;
            Instantiate(WinObject, ReferenceManager.Instance.Player.transform.position, transform.rotation);

            if(SceneManager.GetActiveScene().buildIndex == 1)
                Invoke("LoadRealLevel",2f);
        }
    }

    void LoadRealLevel()
    {
        SceneManager.LoadScene(2);
    }
}
