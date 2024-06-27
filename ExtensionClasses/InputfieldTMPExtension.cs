using TMPro;

namespace Extensions
{
    public static class InputfieldTMPExtension
    {
        public static void ClearInputfield(this TMP_InputField inputfield)
        {
            inputfield.Select();
            inputfield.text = "";
        }
        public static void SetInteractable(this TMP_InputField inputfield, bool status)
        {
            inputfield.interactable = status;
        }
    }
}
