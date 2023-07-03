using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour
    {
        private PlayerControls _playerControls;
        private CharacterController _characterController;
        private float _speed;
        private Camera _mainCam;
    
        public void OnInit(PlayerControls playerControls, float speed, Camera mainCamera)
        {
            _mainCam = mainCamera;
            _playerControls = playerControls;
            _characterController = GetComponent<CharacterController>();
            _speed = speed;
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
                var magnitude = Mathf.Clamp01(moveDirection.magnitude) * _speed;        
                //_characterController.Move(moveDirection * (_speed * Time.fixedDeltaTime));
               _characterController.SimpleMove(moveDirection * magnitude );
            }
        }
    
        private void Look()
        {
            var ray = _mainCam.ScreenPointToRay(_playerControls.LookDirection);
            var position = transform.position;
            if (Physics.Raycast(ray, out var hit, 50))
            {
                var lookPos = hit.point;
                var lookDir = lookPos - position;
                lookDir.y = 0;
                transform.LookAt(position + lookDir, Vector3.up);
            }
        }
    }
}
