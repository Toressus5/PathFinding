using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SkillDisplay : MonoBehaviour
{
    public Skill skill;

    public GameObject skillPanel;

    public Text skillName;
    public Text castingDuration;
    public Text manaCost;
    public Text skillDescription;

    public Image artwork;

    void Start()
    {
        skillName.text = skill.skillName;
        castingDuration.text = skill.castDuration.ToString();
        manaCost.text = skill.manaCost.ToString();
        skillDescription.text = skill.description.ToString();

        artwork.sprite = skill.skillSprite;
    }
    private void Update()
    {
        if (IsMouseOverUI())
        {
            skillPanel.SetActive(true);
        }
        else
        {
            skillPanel.SetActive(false);
        }
        
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

}
