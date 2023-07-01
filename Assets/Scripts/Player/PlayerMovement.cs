using System;
using System.Collections;
using System.Collections.Generic;
using Player;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private PlayerControls _playerControls;
    private CharacterController _characterController;
    private float _speed = 2f;
    private Camera _mainCam;
    
    public void OnInit(PlayerControls playerControls)
    {
        _mainCam = Camera.main;
        _playerControls = playerControls;
        _characterController = GetComponent<CharacterController>();
    }
    
    private void FixedUpdate()
    {
        Move();
        Look();
    }

    private void Move()
    {
        if (_playerControls.MoveDirection != Vector2.zero)
        {
            var moveDirection = new Vector3(_playerControls.MoveDirection.x, 0, _playerControls.MoveDirection.y);
            _characterController.Move(moveDirection * (_speed * Time.fixedDeltaTime));
        }
    }
    
    private void Look()
    {
        var ray = _mainCam.ScreenPointToRay(_playerControls.LookDirection);
        if (Physics.Raycast(ray, out var hit, 100))
        {
            var lookPos = hit.point;
            var lookDir = lookPos - transform.position;
            lookDir.y = 0;
            transform.LookAt(transform.position + lookDir, Vector3.up);
        }
    }
}
