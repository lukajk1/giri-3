using TMPro;
using UnityEngine;

public class StateDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;

    public void SetText(string text)
    {
        this.text.text = text;
    }
}
