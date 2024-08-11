
using UnityEngine;

public class Shop : MonoBehaviour
{
    public QuanLyGiaTienThap FastTurrent;
    public QuanLyGiaTienThap SlowTurrent;
    public BuildManager buildManager;
    // Khai bao su kien khi an vao nut

    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    public void ChonMuaThapPhao()
    {
        Debug.Log("Thap Phao Tieu Chuan");
        buildManager.LuaChonThapPhaoMuonXayDung(FastTurrent);
   }
    public void ChonMuaThapPhao2()
    {
        Debug.Log("Thap Phao Tieu Chuan2");
        buildManager.LuaChonThapPhaoMuonXayDung(SlowTurrent);
    }
}
