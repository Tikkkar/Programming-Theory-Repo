using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastTurrent : Turret
{
    // Start is called before the first frame update
   
    public FastTurrent() 
    {
        fireRate = 2f;
        range = 10f;
    }
    // Update is called once per frame
    void Update()
    {
        LockTaget();
    }
}
