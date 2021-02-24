using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTarget : MonoBehaviour
{
    private Transform player;
    private Vector3 playerToMouse;
    public Vector3 GetCurrentMousePosition { get { return playerToMouse; } }

    public static LookAtTarget Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
            Debug.Log("Another instance of LooktAtTarget already exist");
        else
            Instance = this;
        Init();
    }

    public void Init()
    { 
        player = CharMovement.Instance.GetPlayer;
    }

    public Quaternion GetCursorPoint()
    {
        return Quaternion.LookRotation(playerToMouse);
    }

    void Update()
    {
        //TODO: correct endpoint vector3

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            playerToMouse = hit.point - transform.position;
            playerToMouse.y = 0;
            Quaternion rotation = Quaternion.LookRotation(playerToMouse);
            player.transform.rotation = rotation;
        }
    }
}
