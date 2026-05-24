using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[System.Serializable]
public class PlayerData {
    public string name;
    public int hp;
}

public class ServerTest : MonoBehaviour {
    void Start() {
        StartCoroutine(GetData());
    }

    IEnumerator GetData() {
        // player にアクセス
        UnityWebRequest request = UnityWebRequest.Get("http://localhost:3000/player");

        // 通信完了まで待つ
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success) {
            string json = request.downloadHandler.text;

            PlayerData data = JsonUtility.FromJson<PlayerData>(json);

            Debug.Log(data.name);
            Debug.Log(data.hp);
        }
    }
}