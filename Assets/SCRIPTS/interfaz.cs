using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class INTERFAZ : MonoBehaviour
{
    private List<Transform> CanColor = new List<Transform>();
    public GameObject canroot;
    private int canactiveindex;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < canroot.transform.childCount; i++)
        {
            CanColor.Add(canroot.transform.GetChild(i));
            Debug.Log(canroot.transform.GetChild(i).name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (canactiveindex == CanColor.Count)
            {
                canactiveindex = -1;
            }

            for (int i = 0; i < CanColor.Count; i++)
            {
                if (i == (1 + canactiveindex))
                {
                    Debug.Log("Activando:" + CanColor[i].name);
                    CanColor[i].gameObject.SetActive(true);
                }
                else
                {
                    Debug.Log("Desactivando:" + CanColor[i]);
                    CanColor[i].gameObject.SetActive(false);
                }
            }
            canactiveindex++;

        }
    }
}
