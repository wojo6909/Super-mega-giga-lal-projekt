using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rifle : Pistol
{
    // Start is called before the first frame update
    void Start()
    {
        //Opóźnienie między strzałami (możesz ustawić dowolną wartość)
        cooldown = 0.2f;
        //Ta broń strzela w pełnym automacie; będzie kontynuowała strzelanie, dopóki trzymamy przycisk myszy (nie martw się: powyżej zdefiniowane opóźnienie zostanie uwzględnione!
        auto = true;
        ammoCurrent = 35;
        ammoMax = 35;
        ammoBackPack = 90;
    }



    
 
}
