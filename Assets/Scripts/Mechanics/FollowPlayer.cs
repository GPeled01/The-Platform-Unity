/**
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;
using UnityEngine.Serialization;
using Cinemachine;
using Platformer.Mechanics;

public class FollowPlayer : MonoBehaviour
{

    public GameObject tPlayer1;
    public GameObject tPlayer2;
    public Transform tFollowTarget1;
    public Transform tFollowTarget2;
    public CinemachineVirtualCamera cinemachineVirtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
            if (tPlayer1 == null)
            {
                tPlayer1 = GameObject.Find("Player");
            }
            tFollowTarget1 = tPlayer1.transform;


            if (tPlayer2 == null)
            {
                tPlayer2 = GameObject.Find("Player2");
            }
            tFollowTarget2 = tPlayer2.transform;

            cinemachineVirtualCamera.LookAt = tFollowTarget1;
            cinemachineVirtualCamera.Follow = tFollowTarget1;

            if (Input.GetKeyDown(KeyCode.P)) {
                //controlEnabled = !controlEnabled;
                //if (fol) {
                //    Debug.Log("blabla");
                    cinemachineVirtualCamera.LookAt = tFollowTarget2;
                    cinemachineVirtualCamera.Follow = tFollowTarget2;
                //}
                //else {
                //    Debug.Log("123213");
                //    cinemachineVirtualCamera.LookAt = tFollowTarget1;
                //    cinemachineVirtualCamera.Follow = tFollowTarget1;
                //}

                //fol = !fol;
            }
    }
}
**/
