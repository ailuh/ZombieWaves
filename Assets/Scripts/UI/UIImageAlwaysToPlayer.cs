using UnityEngine;

namespace UI
{
    public class UIImageAlwaysToPlayer : MonoBehaviour
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
