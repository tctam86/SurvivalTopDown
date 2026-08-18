using TMPro;
using UnityEngine;

public class LevelUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private ExperienceSystem experience;

    private void Update()
    {
        levelText.text = $"Level {experience.Level}";
    }
}
