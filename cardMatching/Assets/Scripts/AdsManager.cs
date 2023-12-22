using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Advertisements;
public class AdsManager : MonoBehaviour
{
    public static AdsManager Instance;

    string adType;
    string gameId;

    private void Awake()
    {
        Instance = this;

        if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            adType = "Rewarded_iOS";
            gameId = "5505946";
        }
        else
        {
            adType = "Rewarded_Android";
            gameId = "5505947";
        }

        Advertisement.Initialize(gameId, true); // ����� false�� ����. ������Ʈ ���ÿ��� �׽�Ʈ��� off
    }

    public void ShowRewardAd()
    {
        if (Advertisement.IsReady())
        {
            ShowOptions options = new ShowOptions { resultCallback = ResultAds };
            Advertisement.Show(adType, options);
        }
    }

    void ResultAds(ShowResult result)
    {
        Debug.Log(result);
        switch (result)
        {
            case ShowResult.Failed:
                Debug.LogError("���� ���⿡ �����߽��ϴ�.");
                break;
            case ShowResult.Skipped:
                Debug.Log("���� ��ŵ�߽��ϴ�.");
                break;
            case ShowResult.Finished:
                // ���� ���� ���� ��� 
                GameManager.Instance.ReGame();
                break;
        }
    }
}
