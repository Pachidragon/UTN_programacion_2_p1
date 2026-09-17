using UnityEngine;
using UnityEngine.SceneManagement;



public class Menuses : MonoBehaviour
{
     

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("start");
        }

        if (Input.GetKeyDown(KeyCode.S))
        {

            SceneManager.LoadScene("lv1");

        }



    }
}



