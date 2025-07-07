using UnityEngine;
using TMPro;
public class GetVersionNum : MonoBehaviour
{
    private TMP_Text version;

    private void Awake()
    {
        version = GetComponent<TMP_Text>();
        version.text = "v" + Application.version;
    }
}