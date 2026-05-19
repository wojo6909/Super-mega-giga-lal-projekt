using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        //Nie ma opóźnienia między strzałami
    cooldown = 0;

    //To nie jest broń automatyczna, co oznacza, że musimy kliknąć przycisk ognia za każdym razem, gdy chcemy z niej strzelać
    auto = false;
    ammoCurrent = 15;
    ammoMax = 15;
    ammoBackPack = 60;
    }
   
    protected override void OnShoot()
    {
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);        
        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation);
            if(hit.collider.CompareTag("enemy"))
            {
    // Możesz zmienić liczbę 10 na dowolną, którą chcesz. To jest ilość obrażeń zadawanych przez 1 pocisk
                hit.collider.gameObject.GetComponent<Enemy>().ChangeHealth(10);
            }
            Destroy(gameBullet, 1);

        }

    }
}
