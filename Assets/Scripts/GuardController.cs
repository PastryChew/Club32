using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GuardController : MonoBehaviour
{
    [SerializeField] private GameObject _zone;
    private NavMeshAgent _guard;
    private List<GameObject> _agents = new List<GameObject>();
    private bool _getPoint;
    private bool _getCoroutine;

    private void Start()
    {
        _guard = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!_getPoint)
        {
            GetGuardPoint();
            _getCoroutine = false;
        }
        if (_guard.remainingDistance < 3 && !_getCoroutine)
        {
            _getCoroutine = true;
            StartCoroutine(WaitOnPoint());
        }
    }

    public void GetGuardPoint()
    {
        if (_agents.Count > 0)
        {
        _guard.destination = _agents[Random.Range(0, _agents.Count - 1)].transform.position;
        _getPoint = true;
        }
    }

    public void AddToList(GameObject gameObject)
    {
        _agents.Add(gameObject);
    }
    public void RemoveFromList(GameObject gameObject)
    {
        _agents.Remove(gameObject);
    }

    IEnumerator WaitOnPoint()
    {
        yield return new WaitForSeconds(3f);
        _getPoint = false;
    }
}
