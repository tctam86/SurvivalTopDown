using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DashSkillButtonUI : MonoBehaviour
{
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private DashSkill skill;

    private void Update()
    {
        cooldownOverlay.fillAmount = skill.CooldownRatio;


    }
}