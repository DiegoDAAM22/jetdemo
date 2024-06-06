using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Cop : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject player;
    private Animator _animatorController;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.Find("JET.SEPARACION");
        _animatorController = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
       agent.SetDestination(player.transform.position); 
    }
}
