using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using TMPro;

public class pinta : MonoBehaviour
{
    public GameObject pincel;
    private int rango = 3;
    private int points = 0;
    public TextMeshProUGUI texto;
    public TextMeshProUGUI texto2;
    public AudioSource paint;


    // Start is called before the first frame update
    void Start()
    {
        paint = GameObject.Find("LATA").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       
         if(!PAUSEMENU.isPaused)
        if (Input.GetMouseButton(0))// PULSO EL RATON
              {
            
            if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, rango)) // LANZO RAYO
                {
                
                if (hit.collider.gameObject.layer == 3)
                    
                //if (hit.collider.tag == "pintable") // HE CHOCADO CON ALGO PINTABLE?
                {
                    GameObject pintado = Instantiate(pincel, hit.point, Quaternion.LookRotation(-hit.normal));
                    pintado.transform.parent = hit.collider.transform;
                        paint.Play();
                        points++;
                        texto.text = points.ToString();
                        texto2.text = points.ToString();

                    }
            }
        }
    }
}
