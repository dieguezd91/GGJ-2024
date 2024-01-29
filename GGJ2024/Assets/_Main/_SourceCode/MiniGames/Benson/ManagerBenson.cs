using System.Collections;
using TMPro;
using UnityEngine;
public class ManagerBenson : MonoBehaviour
{
    public static ManagerBenson instance;
    public float remainingTime;
    public TextMeshProUGUI timer;
    private int _caughtBalls;
    private float _objective;
    [SerializeField] private int pointsForVictory;
    [SerializeField] private GameObject controlsScreen;
    [SerializeField] private float controlsShowingTime;
    [SerializeField] private TextMeshProUGUI score;
    public DifficultyValuesScriptableObject difficultyValues;
    [SerializeField] GameObject ballSpawner;

    private void Start()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        foreach (DifficultyValuesScriptableObject values in GameManager.instance.minigamesDifficultyValues)
            if (values.minigameName == "Benson") difficultyValues = values;

        foreach (MultipleValueVariable val in difficultyValues.variables)
            if (val.variableName == "objective") _objective = val.value[GameManager.instance.currentRound - 1];

        foreach (MultipleValueVariable val in difficultyValues.variables)
            if (val.variableName == "movementVelocity") ballSpawner.GetComponent<BensonController>().movementVelocity = val.value[GameManager.instance.currentRound - 1];

        StartCoroutine(ShowControls());
    }

    private void Update()
    {
        if (remainingTime > 0) remainingTime -= Time.deltaTime;

        if (remainingTime <= 0)
        {
            if (EndGame()) Win();
            else Lose();
        }

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timer.text = $"{minutes}:{seconds}";
        score.text = _caughtBalls.ToString();
    }

    public void CatchBall()
    {
        _caughtBalls++;
        AudioManager.AudioInstance.PlaySFX("catchBall");
    }

    bool EndGame()
    {
        return _caughtBalls >= _objective;
    }

    private void Win()
    {
        GameManager.instance.LoadNewLevel();
        GameManager.instance.AddPoints(pointsForVictory);
        Debug.Log("Win");
    }

    public void Lose() => GameManager.instance.GameOver();



    IEnumerator ShowControls()
    {
        controlsScreen.SetActive(true);
        yield return new WaitForSeconds(controlsShowingTime);
        controlsScreen.SetActive(false);
    }
}