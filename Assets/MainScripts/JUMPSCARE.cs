using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JUMPSCARE : MonoBehaviour
{
    private Animator abre;
    public float start;
    public AudioSource som;
    // Start is called before the first frame update
    void Start()
    {
        abre = GetComponent<Animator>();
    }

    public void Jumpscare() {
        
        Invoke("animationStart",start);
        som.Play();

    }
    public void animationStart() {
        abre.SetBool("ativa", true);
    }
}
