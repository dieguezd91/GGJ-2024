using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Guess : MonoBehaviour
{
    private GuessBase[] _base;
    [SerializeField] private int maxCorrectGuesses;
    [SerializeField] private float timerBetweenGuesses;
    [SerializeField] private Image normalImage;
    [SerializeField] private Image silhouette;
    [SerializeField] private TMP_Text correct;
    [SerializeField] private TMP_Text incorrect;
    [SerializeField] private CustomButton[] buttons;

    private GuessBase currentGuess;
    private int correctGuesses;


    private void Start()
    {
        _base = Resources.LoadAll<GuessBase>("");
        AssigningValues();
    }

    private void Update()
    {
        
    }

    public GuessBase GetRandomGuess()
    {
        var random = Random.Range(0, _base.Length);
        return _base[random];
    }

    public void CorrectGuess()
    {
        ClearListeners();
        normalImage.gameObject.SetActive(true);
        silhouette.gameObject.SetActive(false);
        correct.gameObject.SetActive(true);
        correctGuesses++;

        Invoke(nameof(NextGuess), timerBetweenGuesses);

        
    }

    public void NextGuess()
    {
        if (correctGuesses == maxCorrectGuesses)
        {
            correctGuesses = 0;
            //pasar al proximo minijuego
        }
        else
        {
            silhouette.gameObject.SetActive(true);
            normalImage.gameObject.SetActive(false);
            correct.gameObject.SetActive(false);
            AssigningValues();
        }
    }

    public void IncorrectGuess()
    {
        ClearListeners();
        normalImage.gameObject.SetActive(true);
        silhouette.gameObject.SetActive(false);
        incorrect.gameObject.SetActive(true);
        //perder una vida
        //pasar de minijuego
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
