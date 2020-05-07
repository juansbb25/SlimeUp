using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class levelselector : MonoBehaviour
{
    public Button[] btn;
    public Sprite[] locksprite;
    int unlock ;
    public int numberlvls = 15;
    public Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        player.LoadPlayer();
        btn = gameObject.GetComponentsInChildren<Button>();
        
    }

    private void Update()
    {
        unlock = player.unlock;
        for (int i = unlock+1; i < numberlvls; i++)
        {
            btn[i].GetComponent<Image>().sprite = locksprite[0];
            btn[i].GetComponentInChildren<Text>().text = "";
            btn[i].GetComponent<Button>().interactable = false;
        }
    }


    public void selectlevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
