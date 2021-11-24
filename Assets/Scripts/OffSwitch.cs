using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffSwitch : MonoBehaviour
{
    public GameObject target;
    public Animator anim;
    public GameObject mainMenu;

    private void Update()
    {
        if (Input.anyKey)
        {
            Debug.Log("Beep");
            mainMenu.SetActive(true);
            anim.SetTrigger("AnyKeyPressed");
        }
    }
    public void SwitchOff()
    {
        target.SetActive(false);
    }
}
