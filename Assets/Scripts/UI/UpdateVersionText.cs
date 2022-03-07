using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateVersionText : MonoBehaviour
{

    private Text versionText;

    // Start is called before the first frame update
    void Start()
    {
        versionText = gameObject.GetComponentInChildren<Text>() as Text;
        versionText.text = "v" + Application.version;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
