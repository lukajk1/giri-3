using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbilityIcon : MonoBehaviour
{
    [SerializeField] private Image icon;
    [SerializeField] private Image radialFill;
    [SerializeField] private TMP_Text text;

    public void Init()
    {
        // pass the specific ability image here and set to icon.sourceimage or whatever
    }

    public void Countdown(float duration)
    {
        // activates coroutine that depletes linearly over the duration
    }
}