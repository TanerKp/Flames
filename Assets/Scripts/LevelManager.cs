using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    [SerializeField] bool reload = false;
    [SerializeField] string sceneName;

    [Space(20)]
    [SerializeField] Animator anim;

    public void LoadScene()
    {
        if (reload == true)
        {
            if (anim != null)
            {
                StartCoroutine(WaitForAnim());
            }
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (!reload)
        {
            if (anim != null)
            {
                StartCoroutine(WaitForAnim());
            }
            SceneManager.LoadScene(sceneName);
        }
    }

    IEnumerator WaitForAnim()
    {
        anim.SetTrigger("end");
        yield return new WaitForSeconds(1);
    }

}
