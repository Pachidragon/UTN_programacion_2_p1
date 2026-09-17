using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class Fox : Character
{
    [SerializeField] private List<Dialogue> dialogues;
    [SerializeField] private TextMeshProUGUI needText;

    protected override void Start()
    {
        base.Start();

        if (dialogues.Count > 0)
        {
            needText.text = dialogues[0].text;
        }

        GameManager.OnFoodObtained += ChangeText;
    }

    private void OnDestroy()
    {
        GameManager.OnFoodObtained -= ChangeText;
    }

    public void ChangeText()
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if (dialogue.eventName == "food")
            {
                needText.text = dialogue.text;
                break;
            }
        }
    }
}