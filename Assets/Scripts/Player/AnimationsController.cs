using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationsController : MonoBehaviour
{
    public static AnimationsController Instance { get; private set; }

    private Animator _ac;

    private Vector3 gunPoint;
    private Vector3 upVector;

    private void Awake()
    {
        if(Instance != null)
            Debug.Log("Another instance of AnimationsController already exist");
        else
            Instance = this;
        Init();
    }

    public void Init()
    {
        _ac = GetComponent<Animator>();
    }

    private void Update()
    {
        gunPoint = ShootController.Instance.GetComponent<Transform>().transform.position;
        upVector = gunPoint + new Vector3(-0.5f, 0f, 0f);
        var resultVector = Vector3.Angle(upVector, gunPoint);

        Debug.Log(resultVector);

        if(resultVector > 0 && resultVector <= 90)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                ResetAllBools();
                SetTrue("Left");
            }
        }
        if (resultVector <= 0 && resultVector >= -90)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                ResetAllBools();
                SetTrue("Forward");
            }
        }
        if (resultVector < -90)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                ResetAllBools();
                SetTrue("Right");
            }
        }
        if (resultVector > 90)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                ResetAllBools();
                SetTrue("Back");
            }
        }

        if (!Input.anyKey)
            ResetAllBools();
    }

    void SetTrue(string _bool)
    {
        _ac.SetBool(_bool, true);
    }

    void SetFalse(string _bool)
    {
        _ac.SetBool(_bool, false);
    }

    void ResetAllBools()
    {
        SetFalse("Forward");
        SetFalse("Back");
        SetFalse("Left");
        SetFalse("Right");
    }
}
