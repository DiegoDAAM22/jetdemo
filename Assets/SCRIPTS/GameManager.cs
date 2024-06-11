using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private bool CamaraOn = false;
    private CinemachineVirtualCamera camaraPintar;
    private CinemachineVirtualCamera camaraNormal;
    public int points = 0;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI texto2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public static GameManager Instance { get; private set; }

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            camaraNormal = GameObject.Find("CamaraPersonaje").GetComponent<CinemachineVirtualCamera>();
            camaraPintar = GameObject.Find("CamaraPintar").GetComponent<CinemachineVirtualCamera>();
            camaraPintar.enabled = false;
            camaraNormal.enabled = true;
            //camaraPintar =  GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        }
    }

    public void CambiarCamara()
    {
        if (CamaraOn == true)
        {
            // gestion camaras
            camaraPintar.enabled = false;
            camaraNormal.enabled = true;
            // gestion del modo
            CamaraOn = false;
        }
        else
        {
            camaraPintar.enabled = true;
            camaraNormal.enabled = false;
            CamaraOn = true;
        }

    }

    public bool ModoCamara()
    {
        return CamaraOn;
    }

    private void Update()
    {
        texto.text = points.ToString();
        texto2.text = points.ToString();
    }

}
