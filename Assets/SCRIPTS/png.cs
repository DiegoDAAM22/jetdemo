using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Png : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] puntos;
    private int indice;
    public AudioSource alarm;

    [SerializeField] private int rango = 10;

    public GameObject cop;

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        agent.destination = puntos[indice].position;
        alarm = GameObject.Find("alarm").GetComponent<AudioSource>();
        cop.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(gameObject.transform.position, gameObject.transform.forward, out hit, rango)) // LANZO RAYO
        {
            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Player")
            {
               alarm.Play();
               cop.SetActive(true);

            }
        }
      
    }

    public void CambiarDireccion()
    {
        indice += 1;
        if (indice == puntos.Length)
        {
            indice = 0;
            Debug.Log("llegue");
        }
        agent.destination = puntos[indice].position;
       
        Debug.Log(indice);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * rango); 
    }
}
