using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Silhouette", menuName ="Create new silhouette")]
public class GuessBase : ScriptableObject
{
    [SerializeField] private Sprite normal;
    [SerializeField] private Sprite silhouette;
    [SerializeField] private Sprite correctAnswer;
    [SerializeField] private Sprite[] incorrectAnswers;


    public Sprite Normal => normal;
    public Sprite Silhouette => silhouette;
    public Sprite CorrectAnswer => correctAnswer;
    public Sprite[] IncorrectAnswers => incorrectAnswers;


}
