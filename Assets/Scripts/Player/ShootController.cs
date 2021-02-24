using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootController : MonoBehaviour
{
    public static ShootController Instance { get; private set; }

    private GameObject bullet;
    private float timeAfterShoot = 0.1f;
    private float waitTime;
    private int maxAmmo = 30;
    private int currentAmmo;
    private bool canShoot = true;

    public bool CanShoot { set { canShoot = value; } }

    public int CurrentAmmo
    { 
        get { return currentAmmo; } 
        set { currentAmmo = value; } }

    private void Awake()
    {
        if (Instance != null)
            Debug.Log("Another instance of ShootController already exist");
        else
            Instance = this;
        Init();
    }

    public void Init()
    {
        bullet = Resources.Load<GameObject>("Prefabs/Bullet");
        CurrentAmmo = maxAmmo;
    }

    private void Update()
    {
        waitTime -= Time.deltaTime;
        if(waitTime <= 0)
        {
            if (Input.GetMouseButton(0))
                TryShoot();
        }

        if(CurrentAmmo == 0)
        {
            //TODO: call reload animation

            CurrentAmmo = 30;
            waitTime = 1.5f;
        }
    }

    private void TryShoot()
    {
        if (canShoot)
        {
            Instantiate(bullet, transform.position, Quaternion.Euler(90, 0, 0));
            CurrentAmmo = -1;
            waitTime = timeAfterShoot;
        }
    }
}
