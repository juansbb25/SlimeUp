using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
public class retry : MonoBehaviour
{

    string gameId = "1234567";
    bool testMode = true;
    private void Start()
    {
        Advertisement.Initialize(gameId, testMode);
    }
    public void retrylevel()

    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        // Initialize the Ads service:
        
        // Show an ad:

        float random = Random.Range(0, 1f);

        if(random < 0.33f)  Advertisement.Show();
    }

   
}
