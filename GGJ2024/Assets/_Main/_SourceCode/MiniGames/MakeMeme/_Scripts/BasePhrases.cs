using UnityEngine;


[CreateAssetMenu(fileName = "MakeMeme", menuName = "Create new Phrase")]
public class BasePhrases : ScriptableObject
{
    [SerializeField] string chooseCorrect;
    [SerializeField] string choosePhrase;
    [SerializeField] string[] incorrectWord;

    public string ChooseCorrect=> chooseCorrect;
    public string ChoosePhrase => choosePhrase;
    public string[] IncorrectWord => incorrectWord;
}
