using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterController : MonoBehaviour
{
    private NavMeshAgent _agent;

    [SerializeField] private GameObject _target;
    [SerializeField] private float _spawnRadius;
    [SerializeField] private GameObject _prefab;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField]private Vector3 _volume;
    private GameObject _obj;
    [SerializeField] private GameObject[] _objectsArr;
    private bool _isAllPoint;
    private bool _getAgentPoint;
    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        //_agent.destination = _target.transform.position;
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
        }
    }

    public void GetNewRandomPoint()
    {
        int spawnCount = 6;
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
        
        if (_agent.remainingDistance < 1)
        {
            _agent.destination = _objectsArr[Random.Range(0, _objectsArr.Length)].transform.position;
            
        }
    }
}
