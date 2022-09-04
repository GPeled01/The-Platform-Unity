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

public class FollowerControl : MonoBehaviour
{

	public GameObject tPlayer1;
    public GameObject tPlayer2;
    public Transform tFollowTarget1;
    public Transform tFollowTarget2;
	public CinemachineVirtualCamera cinemachineVirtualCamera;

	public GameObject vcam1;
    public GameObject vcam2;

    public bool fol = true;

    // Start is called before the first frame update
    void Start()
    {
    	vcam1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
    	if (Input.GetKeyDown(KeyCode.P)) {
			if (fol) {
	            vcam1.SetActive(false);
	            vcam2.SetActive(true);
	        }
	        else {
	            vcam1.SetActive(true);
	            vcam2.SetActive(false);
	        }
	        fol = !fol;
	    }
    }
}
