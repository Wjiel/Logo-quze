using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class GameScr : MonoBehaviour
{
    [Header("Animation")]
    [SerializeField] Animator Fader;
    [Header("End")]
    [SerializeField] private GameObject End;
    [SerializeField] private TextMeshProUGUI ResultText;

    private int _countRightQuestion;
    [Header("Game")]
    [SerializeField] private TextMeshProUGUI Title;
    [SerializeField] private Image[] imagesButton;
    [SerializeField] private Button[] Button;
    [SerializeField] private Question[] Questions;
    private int _currentQuestion = 0;
    private bool _isRight;
    private void Start()
    {
        initQuestion(0);
    }

    private void EndGame()
    {
        imagesButton[0].enabled = false;
        imagesButton[1].enabled = false;

        Title.gameObject.SetActive(false);
        End.SetActive(true);
        ResultText.text = $"{_countRightQuestion} / {Questions.Length}";
    }
    private void initQuestion(int id)
    {
        if (Questions.Length == _currentQuestion)
        {
            EndGame();
            return;
        }


        scaleAnim(Title.transform);
        scaleAnim(imagesButton[0].transform);
        scaleAnim(imagesButton[1].transform);

        int rand = Random.Range(0, 4);

        if (rand > 2)
        {
            imagesButton[0].sprite = Questions[id].SuccessfulImage;
            imagesButton[1].sprite = Questions[id].FrongImage;
        }
        else
        {
            imagesButton[1].sprite = Questions[id].SuccessfulImage;
            imagesButton[0].sprite = Questions[id].FrongImage;
        }


    }
    private void scaleAnim(Transform transform)
    {
        transform.localScale = Vector2.zero;
        transform.DOScale(1, 1).SetEase(Ease.OutBounce);
    }

    public void GetQuestionButton(int id)
    {

        if (imagesButton[id].sprite == Questions[_currentQuestion].SuccessfulImage)
        {
            _isRight = true;
            _countRightQuestion++;
        }
        else
        {
            _isRight = false;
        }

        SwitchQuestionBt();
    }

    private void SwitchQuestionBt()
    {
        _currentQuestion++;

        StartCoroutine(fade());
    }
    private IEnumerator fade()
    {

        Fader.SetTrigger("Fade");

        if (_isRight)
            Title.color = Color.green;
        else
            Title.color = Color.red;

        enableButton(false);

        yield return new WaitForSeconds(1.5f);

        Fader.SetTrigger("Fade");

        enableButton(true);

        Title.color = Color.black;

        initQuestion(_currentQuestion);
    }
    private void enableButton(bool isEnable)
    {
        Button[0].enabled = isEnable;
        Button[1].enabled = isEnable;
    }
}
