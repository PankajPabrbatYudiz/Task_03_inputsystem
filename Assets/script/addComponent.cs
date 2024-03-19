using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addComponent : MonoBehaviour
{
    [SerializeField] public GameObject myGameObject;
    [SerializeField] public Canvas loginPage;
    [SerializeField] public Canvas ExitePage;
    [SerializeField] public GameObject player;
    private void Start()
    {
        
        ExitePage.GetComponent<Canvas>().enabled = false;

    }
    public void StartObjectMove()
    {
        player.transform.position = new Vector3(0, -0.11f, 0);
        loginPage.GetComponent<Canvas>().enabled = false;
       ExitePage.GetComponent<Canvas>().enabled = false;
        myGameObject.SetActive(true);
    }
    public void Loginpage()
    {
       loginPage.GetComponent<Canvas>().enabled = true;
        ExitePage.GetComponent <Canvas>().enabled = false;
        myGameObject.SetActive(false);
    }
    public void exitePage()
    {
        loginPage.GetComponent<Canvas>().enabled = true;
        ExitePage.GetComponent<Canvas>().enabled = false;
        myGameObject.SetActive(false);
    }
    public void cancleExite()
    {
        loginPage.GetComponent<Canvas>().enabled = false;
        ExitePage.GetComponent<Canvas>().enabled = false;
        myGameObject.SetActive(true);
    }
    public void showamassege()
    {
        
        loginPage.GetComponent<Canvas>().enabled = false;
        ExitePage.GetComponent<Canvas>().enabled = true;
        myGameObject.SetActive(true);
    }
}
