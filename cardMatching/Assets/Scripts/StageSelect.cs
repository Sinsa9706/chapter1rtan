using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelect : MonoBehaviour
{
    [Header("Object")]
    public GameObject[] selects;

    private void Start()
    {

        for (int i = 0; i < selects.Length; i++)
        {
            if (!PlayerPrefs.HasKey($"MaxScore_{i}"))
            {
                // �ְ����� ����� ������ �ʱ�ȭ
                PlayerPrefs.SetInt($"MaxScore_{i}", i);
            }
            selects[i].transform.Find("BestScoreText").GetComponent<Text>().text = PlayerPrefs.GetInt($"MaxScore_{i}").ToString();
        }
    }

    // �������� ���� �� �ش� ������������ ����
    public void startSelectedStage(int stageIndex)
    {
        DataManager.Instance.level = stageIndex;
        SceneManager.LoadScene("LevelTestScene");
    }
}
