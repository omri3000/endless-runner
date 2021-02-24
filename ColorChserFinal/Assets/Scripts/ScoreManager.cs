using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;
    public Text highScoreText;
    public Text runFinalScore;

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

        runFinalScore.gameObject.SetActive(false);
    }

    public void endOfRunDisplay(){
        runFinalScore.text = "Your Score : " + Mathf.Round(_scoreCount);
        runFinalScore.gameObject.SetActive(true);
        scoreText.enabled = false;
        highScoreText.enabled = false;
        if(Input.anyKey){
            SceneManager.LoadScene(0);
            runFinalScore.gameObject.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(scoreIncreasing){
        _scoreCount += pointsPerSecond * Time.deltaTime;
        }else{
         endOfRunDisplay();
        }

        if(_scoreCount > _hiScoreCount){
            _hiScoreCount = _scoreCount;
            PlayerPrefs.SetFloat("HighScore",_hiScoreCount);
        }

        scoreText.text = "Score : " + Mathf.Round(_scoreCount);
        highScoreText.text = "High Score : " + Mathf.Round(_hiScoreCount);
    }
}
