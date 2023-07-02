using UnityEngine;

namespace UI
{
    public class UIAlwaysToCamera : MonoBehaviour
    {
        [SerializeField] 
        private GameObject healthSprite;
        private Camera _mainCamera;

        private void Start()
        {           
            _mainCamera = Camera.main;
        }

        void Update()
        {
            healthSprite.transform.rotation = _mainCamera.transform.rotation;
        }
    }
}
