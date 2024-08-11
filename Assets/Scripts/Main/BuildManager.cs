using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    // Tạo bản lưu trữ thông tin mà mọi scrips khác có thể vào tham chiếu.
    public static BuildManager instance;
    private void Awake()
    {
        //Kiểm tra xem có bản dựng nào khác ngoài bản dựng này không, Không Nên Có Nhiều Hơn 1.
        if (instance != null)
        {
            Debug.LogError("Co Nhieu Hon 1 Ban Dung Trong Canh");
        }    
        instance = this;
    }
    // Khởi tạo các biến các lớp để tham chiếu giữa các scripts.
    // 
    public GameObject standardTurrentPrefab;
    public GameObject anotherTurrenprefab;
    private QuanLyGiaTienThap turrentToBuild;
    // Kiem tra xem viec chon gia tri da xay ra chua neu xay ra roi tra ve ket qua la no da xay ra.
    public bool CanBuild { get { return turrentToBuild != null; } }

    public void BuildTurrentOn(Node node)
    {
        if (PlayerStarts.Monneys < turrentToBuild.cost)
        {
            Debug.Log("Not Enought Monney");
            return;
        }

        PlayerStarts.Monneys -= turrentToBuild.cost;


       GameObject turrent = (GameObject) Instantiate(turrentToBuild.TurrentPrefab, node.GetBuildPosition(),Quaternion.identity);
            node.turrent = turrent; 

        Debug.Log("Turrent To Build - Monney left" + PlayerStarts.Monneys);
    }

    // Chọn đối tương nào sẽ được xây dựng
    public void LuaChonThapPhaoMuonXayDung(QuanLyGiaTienThap turrent)
    {
        turrentToBuild = turrent;
    }

}
