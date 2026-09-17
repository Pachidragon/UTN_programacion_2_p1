using UnityEngine;
using TMPro;

public class parpadeo : MonoBehaviour
{
    public TextMeshProUGUI texto;
    float tiempo = 0f;
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= 0.5f)
        {
            texto.enabled = !texto.enabled;
            tiempo = 0f;
        }
    }
}
