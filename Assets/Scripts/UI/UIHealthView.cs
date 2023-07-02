using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIHealthView : MonoBehaviour
    {
        [SerializeField] 
        private Image healthBar;
        
        public void UpdateHealth(float fillAmount)
        {
            healthBar.fillAmount = fillAmount;
        }

    }
}
