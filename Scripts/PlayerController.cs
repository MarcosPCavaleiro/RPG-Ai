using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{

    public Interactable focus;
    public LayerMask movementMask;
    Camera cam;
    PlayerMotor motor;
    public PlayerStats stats;

    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stats.isDeath != true)
        {
            if (Input.GetMouseButtonDown(0) && !IsMouseOverUI())
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    motor.MovetoPoint(hit.point);

                    RemoveFocus();
                }
            }

            if (Input.GetMouseButtonDown(1) && !IsMouseOverUI())
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
    }

    private bool IsMouseOverUI()
    {
        return EventSystem.current.IsPointerOverGameObject();
    }

    void SetFocus(Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.onDefocused();
            }

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        newFocus.onFocused(transform);
    }

    void RemoveFocus()
    {
        if (focus != null)
        {
            focus.onDefocused();
        }

        focus = null;
        motor.StopFollowingTarget();
    }
}
