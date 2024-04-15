using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillPan : MonoBehaviour
{
    [SerializeField] Image ico;
    [SerializeField] TextMeshProUGUI description;

    public void UpdatePan(Image newIco, string newDescription)
    {
        ico = newIco;
        description.text = newDescription;
    }
}
