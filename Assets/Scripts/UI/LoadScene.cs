using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class LoadScene : MonoBehaviour
{
    [SerializeField]
    private string scene;
    private Button button;

    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    private void OnClick()
    {
        Cursor.visible = true;
        SceneManager.LoadScene(scene);
    }
}
