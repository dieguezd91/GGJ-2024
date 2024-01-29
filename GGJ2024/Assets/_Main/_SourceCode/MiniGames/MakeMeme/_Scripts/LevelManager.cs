using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private float scoreIncrease;
    [SerializeField] private float minigameTimer;
    [SerializeField] private float timerBetweenPhrases;
    [SerializeField] private float incorrectTimer;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text minigameTimerText;
    [SerializeField] private TMP_Text originalPhrase;
    [SerializeField] private TMP_Text correct;
    [SerializeField] private TMP_Text incorrect;
    [SerializeField] private TMP_Text incompletePhrase;
    [SerializeField] private Image memeImage;
    [SerializeField] private CustomButton[] buttons;
    [SerializeField] private TMP_Text[] buttonsText;
    private PhraseData[] phraseData;
    private PhraseData currentPhrase;
    private float makeMemeScore;
    private float correctAnswers;
    private void Start()
    {
        phraseData = Resources.LoadAll<PhraseData>("Frases");
        InitializeValues();
    }

    private void Update()
    {
        minigameTimer -= Time.deltaTime;
        minigameTimerText.text = minigameTimer.ToString();
        if (minigameTimer <= 0)
        {
            DisableButtons();
        }
    }

    public PhraseData GetRandomPhrase()
    {
        var random = Random.Range(0, phraseData.Length);
        return phraseData[random];
    }

    public void CorrectPhrase()
    {
        ClearListeners();
        makeMemeScore += scoreIncrease;
        scoreText.text = makeMemeScore.ToString();
        incompletePhrase.gameObject.SetActive(false);
        originalPhrase.gameObject.SetActive(true);
        correct.gameObject.SetActive(true);
        DisableButtons();
        correctAnswers++;

        Invoke(nameof(NextPhrase), timerBetweenPhrases);
    }

    public void IncorrectPhrase()
    {
        ClearListeners();
        incompletePhrase.gameObject.SetActive(false);
        originalPhrase.gameObject.SetActive(true);
        incorrect.gameObject.SetActive(true);
        DisableButtons();

        Invoke(nameof(NextPhrase), incorrectTimer);
    }

    public void NextPhrase()
    {
        EnableButtons();
        correct.gameObject.SetActive(false);
        incorrect.gameObject.SetActive(false);
        originalPhrase.gameObject.SetActive(false);
        incompletePhrase.gameObject.SetActive(true);
        InitializeValues();
    }

    public void InitializeValues()
    {
        currentPhrase = GetRandomPhrase();
        memeImage.sprite = currentPhrase.MemeImage;
        incompletePhrase.text = currentPhrase.IncompletePhrase;
        var indexRandom = Random.Range(0, 4);
        var stack = new Stack(currentPhrase.IncorrectWords);
        for (int i = 0; i < 4; i++)
        {
            if (buttons[i] == buttons[indexRandom])
            {
                buttons[i].OnMouseClick.AddListener(CorrectPhrase);
                originalPhrase.text = currentPhrase.OriginalPhrase;
                buttonsText[i].text = currentPhrase.ChooseCorrect;
                continue;

            }

            buttons[i].OnMouseClick.AddListener(IncorrectPhrase);
            buttonsText[i].text = (string)stack.Pop();      
        }

    }
    public void ClearListeners()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].OnMouseClick.RemoveAllListeners();
        }
    }

    public void DisableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(false);
        }
    }

    public void EnableButtons()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].gameObject.SetActive(true);
        }
    }
}
