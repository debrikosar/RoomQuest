using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainCamera;

    public GameObject mainMenu;
    public GameObject settingsMenu;

    public GameObject bedroomMenu;
    public GameObject bathroomMenu;

    public GameObject fadeScreen;
    private Image fadeScreenImage;

    public AudioSource catSounds;
    public GameObject menuCat;
    private Animator catAnimator;
    private bool isMeowing;

    public float bounceAmplitude = 0.1f;
    public float bounceFrequency = 1f;

    private Vector3 posOffset;
    private Vector3 tempPos;

    void Awake()
    {
        SetUpMainMenu();
    }

    private void Start()
    {
        StartCoroutine("MenuCatMeow");
    }

    void Update()
    {
        BounceCamera();
    }

    public void SetUpMainMenu()
    {
        catAnimator = menuCat.GetComponent<Animator>();
        catAnimator.Play("sitting");      

        fadeScreenImage = fadeScreen.GetComponent<Image>();

        posOffset = mainCamera.transform.position;
    }

    public void BounceCamera()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * bounceFrequency) * bounceAmplitude;

        mainCamera.transform.position = tempPos;
    }

    IEnumerator SwitchSceneToMain()
    {
        yield return StartCoroutine("FadeScreen");

        SceneManager.LoadScene("MainScene");
    }

    IEnumerator SwitchMenus()
    {
        yield return StartCoroutine("FadeScreen");

        settingsMenu.SetActive(settingsMenu.activeSelf ? false : true);
        mainMenu.SetActive(settingsMenu.activeSelf ? false : true);
        bathroomMenu.SetActive(settingsMenu.activeSelf ? true : false);
        bedroomMenu.SetActive(settingsMenu.activeSelf ? false : true);

        if (isMeowing)
        {
            StopCoroutine("MenuCatMeow");
            isMeowing = false;
        }
        else
        {
            StartCoroutine("MenuCatMeow");
            catAnimator.Play("sitting");
        }

        StartCoroutine("UnFadeScreen");
    }

    IEnumerator FadeScreen()
    {
        fadeScreen.SetActive(true);
        for (float alpha = 0f; alpha < 1.0f; alpha += Time.deltaTime)
        {
            fadeScreenImage.color = new Color(
                fadeScreenImage.color.r,
                fadeScreenImage.color.b,
                fadeScreenImage.color.g,
                alpha);

            yield return null;
        }
    }

    IEnumerator UnFadeScreen()
    {       
        for (float alpha = 1.0f; alpha > 0f; alpha -= Time.deltaTime)
        {
            fadeScreenImage.color = new Color(
                fadeScreenImage.color.r,
                fadeScreenImage.color.b,
                fadeScreenImage.color.g,
                alpha);

            yield return null;
        }

        fadeScreen.SetActive(false);
    }

    IEnumerator MenuCatMeow()
    {
        isMeowing = true;

        while (true)
        {
            yield return new WaitForSeconds(5f);
            catAnimator.Play("miau");
            catSounds.Play();
            catAnimator.Play("sitting");
        }
    }

    public void CloseGame() => Application.Quit();

    public void SummonSettings() => StartCoroutine(SwitchMenus());

    public void StartGame() => StartCoroutine(SwitchSceneToMain());
}
