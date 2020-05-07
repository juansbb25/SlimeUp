using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class mainmenu : MonoBehaviour
{
    // Facebook AD Banner

    string gameId = "1234567";
    bool testMode = true;
    
    // Player UI Settings

    Player player;
    private void Start() {
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
        // Show an ad:
        Advertisement.Show();
        string appId = "ca-app-pub-9237701372755598~9594939056";
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
        //admob
    }
 
    public void loadmenu(string scene)
    {
        SceneManager.LoadScene(scene);
    }
  public void openwebpage(string url)
    {
        Application.OpenURL(url);

    }

}
