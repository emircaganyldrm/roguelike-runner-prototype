using UnityEngine;
using UnityEngine.SceneManagement;

public class KillPlayer : MonoBehaviour
{
    public GameObject killPanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            killPanel.SetActive(true);
            Time.timeScale = 0;
        }
    }


    public void KillPanelButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("SampleScene");
    }
}
