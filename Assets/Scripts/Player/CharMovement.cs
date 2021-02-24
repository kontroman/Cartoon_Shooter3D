using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    public static CharMovement Instance { get; private set; }
    public Transform GetPlayer { get { return transform; } }

    private float speedMove;
    private float speedMultiplier;

    public float SpeedMove
    {
        get { return speedMove; }
        set { speedMove = value; }
    }
    public float SpeedMultiplier
    {
        get { return speedMultiplier; }
        set { speedMove = value; }
    }

    private void Awake()
    {
        if (Instance != null)
            Debug.Log("Another instance of CharMovement already exist");
        else
            Instance = this;
        Init();
    }

    public void Init(float _speedMove = 2, float _speedMultiplier = 1.5f)
    {
        SpeedMove = _speedMove;
        SpeedMultiplier = _speedMultiplier;
    }
    private void Update()
    {
        Move();
    }

    void Move()
    {
        var movevector = Vector3.zero;

        movevector.x = Input.GetAxis("Horizontal") * speedMove * Time.deltaTime;
        movevector.z = Input.GetAxis("Vertical") * speedMove * Time.deltaTime;

        transform.Translate(movevector, Space.World);
    }
}
