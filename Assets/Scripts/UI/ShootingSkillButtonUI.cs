using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShootingSkillButtonUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI chargeText;
    [SerializeField] private ShootingSkill skill;
    [SerializeField] private Image cooldownOverlay;


    private void Update()
    {
        chargeText.text = skill.Charge + "/" + skill.MaxCharge;

        float spent = (float)(skill.MaxCharge - skill.Charge) / skill.MaxCharge;
        cooldownOverlay.fillAmount = spent;
    }
}
