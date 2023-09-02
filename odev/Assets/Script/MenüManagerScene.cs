using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenüManagerScene : MonoBehaviour
{
    public GameObject dataBoard;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void playButton()
    {
        SceneManager.LoadScene(1);
    }
    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();

        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Totol Bullet Shot : " + DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Totol Enenmy Killed : " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }
    public void XBUtton()
    {
        dataBoard.SetActive(false);
    }
}
