using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoving : MonoBehaviour
{
    private Transform _playerTransform;
    private float _speed = 2;

    
    public void OnInit(Transform playerTransform)
    {
        _playerTransform = playerTransform;
    }
    
    void Update()
    {
        var newPosition = new Vector3(_playerTransform.transform.position.x, transform.position.y,
            _playerTransform.transform.position.z);
        transform.position = Vector3.MoveTowards( transform.position, newPosition, _speed * Time.deltaTime );
        transform.LookAt( newPosition, Vector3.up);
    }
}
