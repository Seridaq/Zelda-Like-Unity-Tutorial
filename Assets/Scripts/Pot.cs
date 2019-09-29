using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void OnBreak()
    {
        anim.SetBool("isBroken", true);
        //StartCoroutine(OnBreakCo());
    }

    public void OnAnimationComplete()
    {
        gameObject.SetActive(false);
    }
    //This was old code. As long as events work not need for this.
    /*IEnumerator OnBreakCo()
    {
        yield return new WaitForSeconds(.3f);
        gameObject.SetActive(false);
    }*/
}
