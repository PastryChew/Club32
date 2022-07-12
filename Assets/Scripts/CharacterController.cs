using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float _spawnRadius;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField]private Vector3 _volume;
    [SerializeField] private GameObject[] _objectsArr;
    private NavMeshAgent _agent;
    private GameObject _obj;
    private bool _isAllPoint;
    private bool _getAgentPoint;
    private bool _getCoroutine;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (!_isAllPoint)
        {
            GetNewRandomPoint();
        }
        if (!_getAgentPoint)
        {
            GetAgentPoint();
            _getCoroutine = false;
        }
        if (_agent.remainingDistance < 1 && !_getCoroutine)
        {
            _getCoroutine = true;
            StartCoroutine(WaitOnPoint());
        }
    }

    public void GetNewRandomPoint()
    {
        int spawnCount = 30;
        GameObject parent = new GameObject();
        _isAllPoint = true;
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(_spawnPoint.position.x - _volume.x, _spawnPoint.position.x + _volume.x), _spawnPoint.position.y, 
                Random.Range(_spawnPoint.position.z - _volume.z, _spawnPoint.position.z + _volume.z));
            _obj = Instantiate(_prefab, pos, Quaternion.identity, parent.transform);
            _objectsArr[i] = _obj;
        }
    }

    public void GetAgentPoint()
    {
        _agent.destination = _objectsArr[Random.Range(0, _objectsArr.Length)].transform.position;
        _getAgentPoint = true;
    }

    IEnumerator WaitOnPoint()
    {
        yield return new WaitForSeconds(3f);
        _getAgentPoint = false;
    }
}
