using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextLv : MonoBehaviour
{
    public void NextLevel(int index) {
        SceneManager.LoadScene(index);
    }
}
