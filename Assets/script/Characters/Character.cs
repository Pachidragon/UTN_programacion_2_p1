using UnityEngine;

public class Character : MonoBehaviour
{
    protected Animator anim;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
    }
}