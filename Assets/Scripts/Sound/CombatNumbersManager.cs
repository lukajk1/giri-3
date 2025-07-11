using UnityEngine;
using UnityEngine.Audio;


public class CombatNumbersManager : MonoBehaviour
{
    [SerializeField] GameObject CombatNumbersCanvas;
    public static CombatNumbersManager i;

    private void Awake()
    {
        if (i == null) i = this;
    }

    private void OnEnable()
    {
        CombatEventBus.OnCombatDataResolved += ShowCombatNumber;
    }

    private void OnDisable()
    {
        CombatEventBus.OnCombatDataResolved -= ShowCombatNumber;
    }

    private void ShowCombatNumber(CombatData data)
    {
        Vector3 pos = data.pos + (-Vector3.Normalize(Camera.main.transform.forward) * 1.5f);
        GameObject canvas = Instantiate(CombatNumbersCanvas, pos, Quaternion.identity);
        canvas.GetComponentInChildren<CombatNumbersAnimator>().Init(data);
    }
}