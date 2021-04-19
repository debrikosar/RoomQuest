using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainCamera;
    public GameObject settingsMenu;
    public AudioSource catSounds;
    public GameObject fadeScreen;
    private Image fadeScreenImage;

    public GameObject menuCat;
    private Animator catAnimator;

    public float bounceAmplitude = 0.1f;
    public float bounceFrequency = 1f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();

    void Awake()
    {
        catAnimator = menuCat.GetComponent<Animator>();
        catAnimator.Play("sitting");
        posOffset = mainCamera.transform.position;
        fadeScreenImage = fadeScreen.GetComponent<Image>();
    }

    private void Start()
    {
        StartCoroutine(MenuCatMeow());
    }

    void Update()
    {
        BounceCamera();
    }

    public void BounceCamera()
    {
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * bounceFrequency) * bounceAmplitude;

        mainCamera.transform.position = tempPos;
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

        SceneManager.LoadScene("MainScene");
    }

    IEnumerator MenuCatMeow()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            catAnimator.Play("miau");
            catSounds.Play();
            catAnimator.Play("sitting");
        }
    }

    public void CloseGame() => Application.Quit();

    public void SummonSettings() => settingsMenu.SetActive(settingsMenu.activeSelf ? false : true);

    public void StartGame() => StartCoroutine(FadeScreen());
}
