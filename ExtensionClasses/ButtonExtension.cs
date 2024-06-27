using TMPro;
using UnityEngine.UI;

namespace Extensions
{
    public static class ButtonExtension
    {
        public static bool IsActiveInHierachyAndInteractable(this Button button)
        {
            return button.gameObject.activeInHierarchy && button.interactable;
        }
        public static TMP_Text GetButtonTextComponent(this Button button)
        {
            return button.GetComponentInChildren<TMP_Text>();
        }
    }
}