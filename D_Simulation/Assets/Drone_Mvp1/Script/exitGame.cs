using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class exitGame : MonoBehaviour
{
    private Button exitBtn;
    // Start is called before the first frame update
    void Start()
    {
        exitBtn = this.GetComponent<Button>();
        exitBtn.onClick.AddListener(exit);
    }

    public void exit()
    {
        Application.Quit();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
