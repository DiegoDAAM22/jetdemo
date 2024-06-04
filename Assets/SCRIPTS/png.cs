using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Png : MonoBehaviour
{
    private NavMeshAgent agent;
    [SerializeField] private Transform[] puntos;
    private int indice;

    // Start is called before the first frame update
    void Start()
    {
       agent = GetComponent<NavMeshAgent>();
        agent.destination = puntos[indice].position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CambiarDireccion()
    {
        indice += 1;
        agent.destination = puntos[indice % puntos.Length].position;
        Debug.Log("Me dirijo al punto: " + indice % puntos.Length);
    }
}
