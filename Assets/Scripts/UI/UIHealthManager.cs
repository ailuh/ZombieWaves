using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealthManager : MonoBehaviour
    {
        [SerializeField] 
        private Image image;
        
        public void UpdateHealth(float fillAmount)
        {
            image.fillAmount = fillAmount;
        }

    }
}
