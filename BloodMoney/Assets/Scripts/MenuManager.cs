using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mainMenu, options,credits,shop,upgrades,casino,trophies;


    void Start()
    {
        HideAllPanels();
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SwitchState(GameObject ob)
    {
        ob.SetActive(!ob.activeSelf);
    }
    public void HideAllPanels()
    {
        mainMenu.SetActive(false);
        //shop.SetActive(false);
        //upgrades.SetActive(false);
        casino.SetActive(false);
        //trophies.SetActive(false);
        //options.SetActive(false);
        //credits.SetActive(false);
    }
    public void BackButtonPressed()
    {
        HideAllPanels();
        mainMenu.SetActive(true);
    }
    public void CasinoButtonPressed()
    {
        HideAllPanels();
        casino.SetActive(true);
    }
    public void PlayButtonPressed()
    {
       // HideAllPanels();
        SceneManager.LoadScene("Geimas");

    }

}
