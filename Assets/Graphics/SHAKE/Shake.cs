using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Mechanics;

public class Shake : MonoBehaviour
{
    public Animator camAnim;
    
    public void CamShake() 
    {
        camAnim.SetBool("shake2", false);
        camAnim.SetBool("shake3", false);
        camAnim.SetBool("shake", true);
    }

    public void CamShake2()
    {
        camAnim.SetBool("shake", false);
        camAnim.SetBool("shake2", true);
        camAnim.SetBool("shake3", false);
    }

    public void CamShake3()
    {
        camAnim.SetBool("shake3", true);
        camAnim.SetBool("shake2", false);
        camAnim.SetBool("shake", false);
    }


}
