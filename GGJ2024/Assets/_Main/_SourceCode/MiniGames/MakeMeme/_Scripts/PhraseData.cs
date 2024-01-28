using UnityEngine;


[CreateAssetMenu(fileName = "MakeMeme", menuName = "Create new Phrase")]
public class PhraseData : ScriptableObject
{
    [SerializeField] string incompletePhrase;
    [SerializeField] string originalPhrase;
    [SerializeField] string writeCorrect;
    [SerializeField] string[] incorrectWords;

    public string ChooseCorrect=> writeCorrect;
    public string OriginalPhrase => originalPhrase;
    public string[] IncorrectWords => incorrectWords;
    public string IncompletePhrase => incompletePhrase;
}
