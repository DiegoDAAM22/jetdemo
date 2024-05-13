using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    float rotationX = 0f;
    float rotationY = 0f;
    public float sensitivity = 15f;
    private CinemachineVirtualCamera camaraNormal;

    // Start is called before the first frame update
    void Start()
    {
        camaraNormal = GameObject.Find("CamaraPersonaje").GetComponent<CinemachineVirtualCamera>();    
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = camaraNormal.transform.position;
        this.transform.rotation = camaraNormal.transform.rotation;
        /*
         * 
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationY += Input.GetAxis("Mouse Y") * sensitivity;
        transform.localEulerAngles = new Vector3(rotationX, rotationY, 0);*/
    }
}
