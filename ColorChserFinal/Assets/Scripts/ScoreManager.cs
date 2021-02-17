using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;

    private float _scoreCount;
    private float _hiScoreCount;


    public float pointsPerSecond;
    public bool scoreIncreasing;



    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetFloat("HighScore") != 0){
         _hiScoreCount = PlayerPrefs.GetFloat("HighScore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing){
        _scoreCount += pointsPerSecond * Time.deltaTime;
        }

        if(_scoreCount > _hiScoreCount){
            _hiScoreCount = _scoreCount;
            PlayerPrefs.SetFloat("HighScore",_hiScoreCount);
        }

        scoreText.text = "Score : " + Mathf.Round(_scoreCount);
        highScoreText.text = "High Score : " + Mathf.Round(_hiScoreCount);
    }
}
