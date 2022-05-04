using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button start;
    public Button options;
    public Button back;
    public GameObject startingPanel;
    public GameObject optionsPanel;



    // Start is called before the first frame update
    void Start()
    {
        start.onClick.AddListener(Starts);
        options.onClick.AddListener(Options);
        back.onClick.AddListener(Back);



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Starts()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void Options()
    {

        optionsPanel.SetActive(true);
        startingPanel.SetActive(false);

    }
    public void Back()
    {
        startingPanel.SetActive(true);
        optionsPanel.SetActive(false);
    }
}