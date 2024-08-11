using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerStarts : MonoBehaviour
{
    private BuildManager buildManager;
    public TextMeshProUGUI Gold;
    public static int Monneys;
    public int startMonney = 400;
    // Start is called before the first frame update
    void Start()
    {
        buildManager = GetComponent<BuildManager>();
        Monneys = startMonney;
    }

    // Update is called once per frame
    void Update()
    {
        Gold.text ="Gold: " + Monneys.ToString();
    }
}
