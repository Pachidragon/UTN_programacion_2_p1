using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public static event Action OnFoodObtained;

    private float remainingTime = 30f;
    private bool timerActive = false;

    public float RemainingTime
    {
        get { return remainingTime; }
        private set { remainingTime = value; }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
                    }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (timerActive && remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }
    }

    public void StartTimer()
    {
        timerActive = true;
        OnFoodObtained?.Invoke();
    }
}