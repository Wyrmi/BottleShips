using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Pickable[] parts;
    public SailToggle[] sails;
    bool win = false;
    public GameObject winScreen;
    // Start is called before the first frame update
    void Start()
    {
        winScreen.SetActive(false);
        parts = FindObjectsOfType<Pickable>();
        sails = FindObjectsOfType<SailToggle>();
    }

    // Update is called once per frame
    void Update()
    {
        win = true;
        foreach (Pickable p in parts)
        {
            if (!p.inPlace)
                win = false;
        }
        foreach (SailToggle s in sails)
        {
            if (!s.sailOpen)
                win = false;
        }
        if (win)
        {
            winScreen.SetActive(true);
            foreach (Pickable p in parts)
            {
                p.EndDrop();
            }
        }

    }
}
