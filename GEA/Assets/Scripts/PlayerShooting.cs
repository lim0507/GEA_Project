using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GameObject projectilePrefab2;
    public Transform firePoint;
    Camera cam;
    bool isSpecial = false;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Shoot();
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            isSpecial = !isSpecial;
        }
    }
    void Shoot()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Vector3 targetPoint;
        targetPoint = ray.GetPoint(50f);
        Vector3 direction = (targetPoint - firePoint.position).normalized;

        if(isSpecial)
        {

            GameObject proj = Instantiate(projectilePrefab2, firePoint.position, Quaternion.LookRotation(direction));
             proj.GetComponent<Projectile>().damage = 3;
        }
        else
        {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));
            proj.GetComponent<Projectile>().damage = 1;
        }
    }
}
