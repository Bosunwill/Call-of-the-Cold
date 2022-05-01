using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerDoorController : MonoBehaviour
{
	[SerializeField] private Animator Door = null;

	[SerializeField] private bool openTrigger = false;
	[SerializeField] private bool closeTrigger = false;

    [SerializeField] private string DoorOpen = "DoorOpen";
    [SerializeField] private string DoorClose = "DoorClose";
    [SerializeField] private string DoorOpen2 = "DoorOpen";
    [SerializeField] private string DoorClose2 = "DoorClose";
    [SerializeField] private string OpenLeftDoorExit = "DoorOpen";
    [SerializeField] private string CloseLeftDoorExit = "DoorClose";
    [SerializeField] private string OpenRightDoorExit = "DoorOpen";
    [SerializeField] private string  CloseRightDoorExit= "DoorClose";
    [SerializeField] private string OpenFreezerDoor = "DoorOpen";
    [SerializeField] private string  CloseFreezerDoor = "DoorClose";
    [SerializeField] private string OpenFreezerDoor2 = "DoorOpen";
    [SerializeField] private string  CloseFreezerDoor2 = "DoorClose";


	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Player"))
		{
			if(openTrigger)
			{
				Door.Play(DoorOpen, 0, 0.0f);
				gameObject.SetActive(false);
			}

			else if(closeTrigger)
			{
				Door.Play(DoorClose, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(openTrigger)
			{
				Door.Play(DoorOpen2, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(closeTrigger)
			{
				Door.Play(DoorClose2, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(openTrigger)
			{
				Door.Play(OpenLeftDoorExit, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(closeTrigger)
			{
				Door.Play(CloseLeftDoorExit, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(openTrigger)
			{
				Door.Play(OpenRightDoorExit, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(closeTrigger)
			{
				Door.Play(CloseRightDoorExit, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(openTrigger)
			{
				Door.Play(OpenFreezerDoor, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(closeTrigger)
			{
				Door.Play(CloseFreezerDoor, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(openTrigger)
			{
				Door.Play(OpenFreezerDoor2, 0, 0.0f);
				gameObject.SetActive(false);	
			}

            else if(closeTrigger)
			{
				Door.Play(CloseFreezerDoor2, 0, 0.0f);
				gameObject.SetActive(false);	
			}
		}
	}
}
