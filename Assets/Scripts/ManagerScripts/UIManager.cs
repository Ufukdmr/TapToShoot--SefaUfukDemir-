using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
   [SerializeField]
   private GameObject pnl_LevelComp;
    void Update()
    {
        if(GameManager._Instance.isFinish)
        {
            StartCoroutine(FinishGame());
        }
    }

    public void GetProjectile(Sc_Button btn)
    {     
      GameManager._Instance.GetProjectile(btn.pre_Projectile);
    }

    IEnumerator FinishGame()
    {
        yield return new WaitForSeconds(1f);
        pnl_LevelComp.SetActive(true);
        Time.timeScale=0;
    }
    public void Again()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
         Time.timeScale=1;
    }

    
}
