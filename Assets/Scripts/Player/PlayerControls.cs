using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerControls : MonoBehaviour
    {
        private ButtonInput _buttonInput;
        private Vector2 _moveDirection;
        private Vector2 _lookDirection;
        private PlayerAttack _playerAttack;
        public Vector2 MoveDirection => _moveDirection;
        public Vector2 LookDirection => _lookDirection;

        public void OnInit(PlayerAttack playerAttack)
        {
            _playerAttack = playerAttack;
            _buttonInput = new ButtonInput();
        }

        public void Enable()
        {
            _buttonInput.Enable();
            _buttonInput.PlayerInputs.Move.performed += OnMove;
            _buttonInput.PlayerInputs.Move.canceled += OnMoveCanceled;
            _buttonInput.PlayerInputs.Look.performed += OnLook;
            _buttonInput.PlayerInputs.Shoot.performed += _playerAttack.OnAttack;
            _buttonInput.PlayerInputs.Shoot.canceled += _playerAttack.OnAttackCancelled;

        }

        public void Disable()
        {
            _buttonInput.Disable();
            _buttonInput.PlayerInputs.Move.performed -= OnMove;
            _buttonInput.PlayerInputs.Move.canceled -= OnMoveCanceled;
            _buttonInput.PlayerInputs.Look.performed -= OnLook;
            _buttonInput.PlayerInputs.Shoot.performed -= _playerAttack.OnAttack;
            _buttonInput.PlayerInputs.Shoot.canceled -= _playerAttack.OnAttackCancelled;
        }

        private void OnMove(InputAction.CallbackContext value)
        {
            _moveDirection = value.ReadValue<Vector2>();
        }

        private void OnMoveCanceled(InputAction.CallbackContext value)
        {
            _moveDirection = Vector2.zero;
        }
    
        private void OnLook(InputAction.CallbackContext value)
        {
            _lookDirection = value.ReadValue<Vector2>();
        }
        
    }
}
