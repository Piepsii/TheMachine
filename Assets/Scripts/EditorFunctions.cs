using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EditorFunctions : MonoBehaviour
{
#if UNITY_EDITOR
    // Update is called once per frame
    void Update()
    {
        if (EditorApplication.isPlaying)
        {
            if (Input.GetKeyDown(KeyCode.F5))
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            if(Input.GetKeyDown(KeyCode.F11))
                EditorWindow.focusedWindow.maximized = !EditorWindow.focusedWindow.maximized;
        }
    }
#endif
}
