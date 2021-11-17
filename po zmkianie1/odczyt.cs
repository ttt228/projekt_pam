using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Networking;

public class odczyt : MonoBehaviour
{
 public TextAsset jsonFile;
 
    void Start()
    {
        Gracze graczeeeInJson = JsonUtility.FromJson<Gracze>(jsonFile.text);
        foreach (Gracz graczzzzz in graczeeeInJson.graczeee)
        {
            Debug.Log("Znalezieni gracze: " + graczzzzz.firstName + " " + graczzzzz.lastName);
        }

        // we wczytywaniu nie podawac rozszerzenia pliku bo nie wczyta/znajdznie np. Lista_graczy.json
        // - nie znajdznie musi byc Lista_graczy samo bez rozszerzenia
        jsonFile = Resources.Load<TextAsset>("Lista_graczy");
    }

     // Update is called once per frame
     void Update () {

     }
 
[System.Serializable]
public class Miecz
{
    public string nazwa;
    public string obrazenia;
}

[System.Serializable]
public class Tarcza
{
    public string nazwa;
    public string obrona;
}


[System.Serializable]
public class Gracz
{
    public string firstName;
    public string lastName;
    public string poziom;
    public string wiek;
    public string obrazek;
    public string urll;

    public string konto;
    public string email;
    public string zloto;
    public string waga;
    public string kod;

    public Miecz mieczzzzz;
    public Tarcza tarczaaaa;
}
 
    [System.Serializable]
    public class Gracze
    {
        public Gracz[] graczeee;
    }

public float szer_przycisku = 250;
	public float wys_przycisku = 40;
	public string wybranygracz = "fasfsasfa";

	void OnGUI()
	{
            Gracze graczeeeInJson = JsonUtility.FromJson<Gracze>(jsonFile.text);
            Gracz mieczzzzzInJson = JsonUtility.FromJson<Gracz>(jsonFile.text);
            int i = 0;
            foreach (Gracz graczzzzz in graczeeeInJson.graczeee)
            {
                i++;
                Debug.Log("Znalezieni gracze: " + graczzzzz.firstName + " " + graczzzzz.lastName);


                Texture2D spr = null;
                spr = Resources.Load<Texture2D>(graczzzzz.obrazek);


                if(spr==null)
                {
                    StartCoroutine(DownloadFile(graczzzzz.obrazek,graczzzzz.urll));
                    Debug.Log("Nie znaleziono: " + graczzzzz.firstName + " " + i);
                }

                if(GUI.Button(new Rect(0, 0 + wys_przycisku*i, szer_przycisku , wys_przycisku), graczzzzz.firstName + " " + graczzzzz.lastName)) {
			        Debug.Log("Kliknoles: " + graczzzzz.firstName + " " + i);
                    wybranygracz = graczzzzz.firstName;
            }

            if(graczzzzz.firstName==wybranygracz){
            GUI.TextField (new Rect (szer_przycisku * 1.5f, 0, szer_przycisku*2, wys_przycisku*2),  graczzzzz.firstName + " " + graczzzzz.lastName
            + "   poziom" + graczzzzz.poziom +"\r\n"+ "wiek: " + graczzzzz.wiek + "     konto: " + graczzzzz.konto + "     email: " + graczzzzz.email
            +"\r\n"+ "zloto: " + graczzzzz.zloto + "     waga: " + graczzzzz.waga + "     kod: " + graczzzzz.kod
            +"\r\n"+"miecz: " + graczzzzz.mieczzzzz.nazwa + "     tarcza: " + graczzzzz.tarczaaaa.nazwa
            +"\r\n"+"miecz obrazenia: " + graczzzzz.mieczzzzz.obrazenia + "      tarcza obrona: " + graczzzzz.tarczaaaa.obrona);
                Texture2D zdjenciaa;
                zdjenciaa = Resources.Load<Texture2D>(graczzzzz.obrazek);
            GUI.DrawTexture(new Rect (szer_przycisku * 2, wys_przycisku *2, szer_przycisku, wys_przycisku*3), zdjenciaa , ScaleMode.ScaleToFit,true, 1.0F);
            }
		}
    }




     IEnumerator DownloadFile(string nazwa,string urlllll) {
        var uwr = new UnityWebRequest(urlllll, UnityWebRequest.kHttpVerbGET);
        string path = Path.Combine( Application.dataPath + "/Resources", nazwa + ".jpg");
         Debug.Log("dowlaaaand: " +urlllll);

        uwr.downloadHandler = new DownloadHandlerFile(path);
        yield return uwr.SendWebRequest();
            Debug.Log("File successfully downloaded and saved to " + path);
    }

    
}