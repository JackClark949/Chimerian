using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Gil : MonoBehaviour
{
    [SerializeField] private float Radius = 20f;

    NavMeshAgent agent;

    Vector3 next_position;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        next_position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(next_position, transform.position) <= 1.5f) 
        {
            next_position = randomPointGenerator.randomPointGen(transform.position, Radius);
            agent.SetDestination(next_position);
        }
    }
}
