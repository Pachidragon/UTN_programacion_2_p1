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

        GameManager.OnFoodObtained += ChangeText;
    }

    private void OnDestroy()
    {
        GameManager.OnFoodObtained -= ChangeText;
    }

    public void ChangeText()
    {
       
    }
}