
using UnityEngine;

public class Shop : MonoBehaviour
{
    public BuildManager buildManager;
    // Khai bao su kien khi an vao nut

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void ChonMuaThapPhao()
    {
        Debug.Log("Thap Phao Tieu Chuan");
        buildManager.SetTurrentToBuild(buildManager.standardTurrentPrefab);
    }
    public void ChonMuaThapPhao2()
    {
        Debug.Log("Thap Phao Tieu Chuan2");
        buildManager.SetTurrentToBuild(buildManager.anotherTurrenprefab);
    }
}
