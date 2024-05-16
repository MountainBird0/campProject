using UnityEngine;
using UnityEngine.UI;

public class EnergyDashboardC : MonoBehaviour
{
    [SerializeField] private EnergySystemC energySystem;
    [SerializeField] private Image fillBar;
    private void Start()
    {
        energySystem.OnEnergyChanged += SetFillBar;
        // 에너지시스템의 에너지 사용에 대해 fillBar가 변경되도록 수정
    }

    private void SetFillBar(float amount)
    {
        var fill = energySystem.Fuel / energySystem.MaxFuel;
        fillBar.fillAmount = fill;
    }

}