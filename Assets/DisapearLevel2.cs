using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisapearLevel2 : MonoBehaviour
{
    public bool check = true;
    public GameObject platform;
    public GameObject platform2;
    public bool check2 = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (check && check2)
        {
            check2 = false;
            StartCoroutine(wait());
        }
        else if (!check && check2)
        {
            check2 = false;
            StartCoroutine(wait2());
        }
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(7f);
        platform.SetActive(false);
        platform2.SetActive(false);
        check = !check;
        check2 = true;
    }

    IEnumerator wait2()
    {
        yield return new WaitForSeconds(3f);
        platform.SetActive(true);
        platform2.SetActive(true);
        check = !check;
        check2 = true;
    }

}
