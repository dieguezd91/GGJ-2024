using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static UnityEditor.Progress;

public class LevelManager : MonoBehaviour
{
    private PhraseData[] phraseData;
    private TMP_Text[] _options;
    private PhraseData _base;
    private Button[] options;

    private void Start()
    {
        GetRandomGuess();
        InitializeButtons();
    }
    public PhraseData GetRandomGuess()
    {
        var random = Random.Range(0, _options.Length);
        return phraseData[random];
    }
    public void InitializeButtons()
    {

        var indexRandom = Random.Range(0, 4);
        var stack = new Stack(_base.IncorrectWords);
        for (int i = 0; i < 4; i++)
        {
            if (_options[i] == _options[indexRandom])
            {
                _options[i].text = _base.ChooseCorrect;
            }
            options[i].text = (string)stack.Pop();      
        }
      

    }
}
