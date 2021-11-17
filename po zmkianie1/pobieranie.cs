using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;

public class pobieranie : MonoBehaviour
{
public float czas = 4.0f;

    void Start () {
        StartCoroutine(DownloadFile());
    }

    IEnumerator DownloadFile() {
        var uwr = new UnityWebRequest("ddd.ugu.pl/Lista_graczy.json", UnityWebRequest.kHttpVerbGET);
        //pobieranie do C:\Users\TOMEK\AppData\LocalLow\DefaultCompany\projekt jeson
        //string path = Path.Combine(Application.persistentDataPath, "unity3d.txt");

        //pobieranie do katalogu gry i zapis w assets
        string path = Path.Combine( Application.dataPath + "/Resources", "Lista_graczy.json");

        //pobieranie do podanej sciezki
        //string path = Path.Combine(@"g:\archives", "unity3d.txt");

        // utworzy katalog archives na c i tam zapisze plik
        // string path = Path.Combine(@"\archives", "unity3d.txt");

        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
            Debug.Log("File successfully downloaded and saved to " + path);
    }

    void Update () {
    czas -= Time.deltaTime;
	if(czas <= 0) {
		StartCoroutine(DownloadFile());
        czas = 4.0f;
	}
     }

}
