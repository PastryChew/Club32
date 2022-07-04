using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private GameObject _target;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.destination = _target.transform.position;
    }
    private void Update()
    {
        
    }
}
