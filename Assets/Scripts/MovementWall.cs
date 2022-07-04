using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWall : MonoBehaviour
{
    private Vector3 _targetPoint1;
    private Vector3 _targetPoint2;
    private float _speed;
    private bool _checkPoint;

    private void Start()
    {
       _targetPoint1 = new Vector3(0.5f,1.5f, 5f);
       _targetPoint2 = new Vector3(0.5f, 1.5f, -5.5f);
       _speed = 0.09f;
    }
    private void FixedUpdate()
    {
        MoveWall();
    }

    private void MoveWall()
    {
        if (!_checkPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint2, _speed);
            if (transform.position == _targetPoint2)
            {
                _checkPoint = true;
            } 
        }
        if(_checkPoint)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPoint1, _speed);
            if (transform.position == _targetPoint1)
            {
                _checkPoint = false;
            }
        }
    }
}
