using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BombSkillButtonUI : MonoBehaviour
{
    [SerializeField] private Image cooldownOverlay;
    [SerializeField] private BombSkill skill;

    private void Update()
    {
        cooldownOverlay.fillAmount = skill.CooldownRatio;
    }
}