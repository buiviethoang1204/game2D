using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Vector3 destination;
    private bool isShooting = true;

    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawnPoint;

    public AudioSource shootSFX;
   

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0)  )
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector3.Lerp(transform.position, new Vector3(destination.x, destination.y, transform.position.z), 0.1f);


            if (isShooting)
            {
                StartCoroutine(Shoot());
            }
        }
    }

    IEnumerator Shoot()
    {
        //khoi tao 1 vien dan o vi tri cua bulletSpawnPoint, goc (Quaternion) mac dinh theo goc cua bulletPrefab
        Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        //phat am thanh
        shootSFX.Play();

        //sau khi spawn dan, se dung ban trong thoi gian #fireRate
        isShooting = false;
        yield return new WaitForSeconds(fireRate);

        //sau khi cho du khoang thoi gian #fireRate, se bat dau ban tro lai
        isShooting = true;
    }
}
