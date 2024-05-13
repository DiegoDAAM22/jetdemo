using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool CamaraOn = true;
    private CinemachineVirtualCamera camaraPintar;
    private CinemachineVirtualCamera camaraNormal;

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
            camaraPintar =  GameObject.Find("Virtual Camera").GetComponent<CinemachineVirtualCamera>();
        }
    }

    public void CambiarCamara()
    {
        //¿ue camara edsta activa?
        // si camaraon es verdadesro
        if (CamaraOn == true)
        {
            camaraPintar.enabled = false;
            camaraNormal.enabled = true;
        }
        else
        {
            camaraPintar.enabled = true;
            camaraNormal.enabled = false;
        }

        // en el caso contrario

    }
}
