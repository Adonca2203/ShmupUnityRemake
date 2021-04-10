using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoManager : MonoBehaviour
{

    [SerializeField] private GameObject ammoParent;
    [SerializeField] private GameObject bulletUI;
    [SerializeField] private List<GameObject> allBullets = new List<GameObject>();
    public Vector2 parentDefault;
    //public static event Action outOfAmmo;

    // Start is called before the first frame update
    void Start()
    { 

        RectTransform ammoRect = ammoParent.GetComponent<RectTransform>();

        parentDefault = ammoRect.localPosition;

        InitAmmo();

        PlayerStats.Instance.onAmmoChange.AddListener(SyncUI);

    }


    void InitAmmo()
    {

        DestroyAllUI();

        RectTransform ammoRect = ammoParent.GetComponent<RectTransform>();

        ammoRect.localPosition = parentDefault;

        int xoffset = 0;
        int yoffset = 0;
        bool offset = false;

        for (int i = 0; i < PlayerStats.Instance.currentAmmo; i++)
        {

            GameObject obj = Instantiate(bulletUI, ammoParent.transform);
            RectTransform objTrans = obj.GetComponent<RectTransform>();
            objTrans.localPosition = new Vector2(obj.transform.position.x + xoffset + 108, obj.transform.position.y + yoffset);

            if (i % 9 == 0 && i !=0)
            {

                offset = true;
                yoffset += 108;
                allBullets.Add(obj);
                continue;
            }

            if (offset)
            {
                xoffset -= 108;
            }

            else
            {
                xoffset += 108;
            }
            allBullets.Add(obj);

        }

        for(int i = 0; i < (PlayerStats.Instance.currentAmmo - 10 > 0? 10: PlayerStats.Instance.currentAmmo); i++)
        {

            ammoRect.localPosition = new Vector2(ammoRect.localPosition.x - 108, ammoRect.localPosition.y);

        }

    }

    void DestroyAllUI()
    {

        foreach(GameObject bullet in allBullets)
        {

            Destroy(bullet);

        }

    }

    void SyncUI()
    {

        InitAmmo();

    }
}
