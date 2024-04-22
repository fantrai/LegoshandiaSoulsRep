using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPan : MonoBehaviour
{
    [SerializeField] Image ico;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI nameSkillText;

    public void UpdatePan(Sprite newIco, string newDescription, string nameSkill)
    {
        ico.sprite = newIco;
        description.text = newDescription;
        nameSkillText.text = nameSkill;
    }
}
