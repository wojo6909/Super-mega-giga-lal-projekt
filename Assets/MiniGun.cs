using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MiniGun : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        //Opóźnienie między strzałami (możesz ustawić dowolną wartość, którą lubisz)
    cooldown = 0.1f;
        //Ta broń strzela w trybie pełnego automatycznego ognia; będzie strzelać tak długo, jak trzymamy przycisk myszy (nie martw się: opóźnienie, które zdefiniowałeś powyżej, zostanie uwzględnione!
    auto = true;
    ammoCurrent = 100;
    ammoMax = 100;
    ammoBackPack = 300;



    }
    protected override void OnShoot()
    {
        Vector3 rayStartPosition = new Vector3(Screen.width / 2, Screen.height / 2, 0);
        
        Vector3 drift = new Vector3(Random.Range(-15, 15), Random.Range(-15, 15), Random.Range(-15, 15) );

        Ray ray = cam.GetComponent<Camera>().ScreenPointToRay(rayStartPosition + drift);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            GameObject gameBullet = Instantiate(particle, hit.point, hit.transform.rotation );
            if(hit.collider.CompareTag("enemy"))
{
            // Możesz zmienić liczbę 10 na dowolną, którą chcesz. To jest ilość obrażeń zadawanych przez 1 pocisk
            hit.collider.gameObject.GetComponent<Enemy>().ChangeHealth(10);
}
            Destroy(gameBullet, 1);
        }
    }

    // Update is called once per frame
    
}
