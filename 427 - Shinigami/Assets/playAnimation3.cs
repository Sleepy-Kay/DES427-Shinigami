using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimation3 : MonoBehaviour
{

    public GameObject myCube;

    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = myCube.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.Play("Character3_Animation", 0, 0.0f);
        }
    }
}
