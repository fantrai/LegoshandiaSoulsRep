using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] List<GameObject> allSkills = new List<GameObject>();
    [SerializeField] GameObject panForNewSkills;
    [SerializeField] SkillPan[] skillPans;
    List<AbstractSkill> availableSkills = new List<AbstractSkill>();
    List<int> skillForChoises = new List<int>(); 

    private void Start()
    {
        for (int i = 0; i < allSkills.Count; i++)
        {
            if (allSkills[i] == player.skills[0])
            {
                allSkills[i] = 
            }
            allSkills[i] = Instantiate(allSkills[i], transform);
            availableSkills.Add(allSkills[i].GetComponent<AbstractSkill>());
        }
    }

    private void OnEnable()
    {
        Player.onNewLvl += PrintNewSkills;
    }

    private void OnDisable()
    {
        Player.onNewLvl -= PrintNewSkills;
    }

    public void AddSkillPlayer(int num)
    {
        foreach(var pan in skillPans)
        {
            pan.gameObject.SetActive(false);
        }
        if (availableSkills[skillForChoises[num]].Lvl == 0)
        {
            player.AddNewSkill(availableSkills[skillForChoises[num]].gameObject);
        }
        else
        {
            availableSkills[skillForChoises[num]].NewLvl();
        }
    }

    public void PrintNewSkills()
    {
        for (int i = 0; i < availableSkills.Count; i++)
        {
            if (availableSkills[i].Lvl >= availableSkills[i].MaxLvl)
            {
                availableSkills.Remove(availableSkills[i]);
            }
        }
        for (int i = 0; i < availableSkills.Count && i < skillPans.Length; i++)
        {
            int numPrint;
            do
            {
                numPrint = Random.Range(0, availableSkills.Count);
            } while (skillForChoises.Contains(numPrint));
            skillForChoises.Add(numPrint);
            availableSkills[numPrint].PrintPan(skillPans[i]);
            skillPans[i].gameObject.SetActive(true);
        }
    }
}
