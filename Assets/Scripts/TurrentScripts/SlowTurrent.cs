using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTurrent : Turret
{
    // Start is called before the first frame update
    public SlowTurrent()
    {
        fireRate = 0.5f;
        range = 20f;
    }

       
   

    // Update is called once per frame
    void Update()
    {
        LockTaget();
    }
}
