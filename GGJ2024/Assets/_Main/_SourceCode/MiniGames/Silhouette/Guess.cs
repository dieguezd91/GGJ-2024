using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Guess : MonoBehaviour
{
    private GuessBase[] _base;
    [SerializeField] private int maxCorrectGuesses;
    [SerializeField] private float minigameTimer;
    [SerializeField] private float timerBetweenGuesses;
    [SerializeField] private float incorrectTimer;
    [SerializeField] private float questionTimer;
    [SerializeField] private float scoreIncrease;
    [SerializeField] private Image normalImage;
    [SerializeField] private Image silhouette;
    [SerializeField] private TMP_Text question;
    [SerializeField] private TMP_Text correct;
    [SerializeField] private TMP_Text incorrect;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text minigameTimerText;
    [SerializeField] private CustomButton[] buttons;

    private GuessBase currentGuess;
    private int correctGuesses;
    private float provisionalScore;


    private void Start()
    {
        _base = Resources.LoadAll<GuessBase>("");
        AssigningValues();
        Invoke(nameof(RemoveQuestion), questionTimer);
    }

    private void Update()
    {
        minigameTimer -= Time.deltaTime;
        minigameTimerText.text = minigameTimer.ToString();
        if(minigameTimer <= 0)
        {
            DisableButtons();
        }
    }

    public void RemoveQuestion()
    {
        question.gameObject.SetActive(false);
    }

    public GuessBase GetRandomGuess()
    {
        var random = Random.Range(0, _base.Length);
        return _base[random];
    }

    public void CorrectGuess()
    {
        ClearListeners();
        //Reproducir sonido de acierto
        provisionalScore += scoreIncrease;
        scoreText.text = provisionalScore.ToString();
        normalImage.gameObject.SetActive(true);
        silhouette.gameObject.SetActive(false);
        correct.gameObject.SetActive(true);
        DisableButtons();
        //correctGuesses++;

        Invoke(nameof(NextGuess), timerBetweenGuesses);

        
    }

    public void NextGuess()
    {
        //if (correctGuesses == maxCorrectGuesses)
        //{
        //    correctGuesses = 0;
        //    //pasar al proximo minijuego
        //}
        //else
        //{
        //    silhouette.gameObject.SetActive(true);
        //    normalImage.gameObject.SetActive(false);
        //    correct.gameObject.SetActive(false);
        //    AssigningValues();
        //}
        EnableButtons();
        silhouette.gameObject.SetActive(true);
        normalImage.gameObject.SetActive(false);
        correct.gameObject.SetActive(false);
        incorrect.gameObject.SetActive(false);
        AssigningValues();
    }

    public void IncorrectGuess()
    {
        ClearListeners();
        //Reproducir sonido de incorrecto
        normalImage.gameObject.SetActive(true);
        silhouette.gameObject.SetActive(false);
        incorrect.gameObject.SetActive(true);
        DisableButtons();

        Invoke(nameof(NextGuess), incorrectTimer);

        
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

    public void AssigningValues()
    {
        
        currentGuess = GetRandomGuess();
        normalImage.sprite = currentGuess.Normal;
        silhouette.sprite = currentGuess.Silhouette;

        var randomButton = Random.Range(0, 4);
        var stack = new Stack(currentGuess.IncorrectAnswers);

        for (int i = 0; i < 4; i++)
        {
            if (buttons[i] == buttons[randomButton])
            {
                buttons[i].OnMouseClick.AddListener(CorrectGuess);
                buttons[i].SpriteRenderer.sprite = currentGuess.CorrectAnswer;
 
                continue;
            }

            buttons[i].OnMouseClick.AddListener(IncorrectGuess);
            buttons[i].SpriteRenderer.sprite = (Sprite)stack.Pop();
        }
    }

    public void ClearListeners()
    {
        for (int i = 0; i < 4; i++)
        {
            buttons[i].OnMouseClick.RemoveAllListeners();
        }
    }
}
