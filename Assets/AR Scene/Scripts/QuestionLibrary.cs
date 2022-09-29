using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionLibrary : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;
    private int index;
    
    //[SerializeField] private Sprite answer;

    [SerializeField] private TextMeshProUGUI questionText;
    [SerializeField] private float timeBetweenQuestion = 2f;
    
    [SerializeField] private Image answerRenderer;
    [SerializeField] private Sprite falseSprite;
    [SerializeField] private Sprite trueSprite;

    private void Start() {
       
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        index = 0;
        SetCurrentQuestion();
        Debug.Log(currentQuestion.question);
        Debug.Log( currentQuestion.isTrue);
    }
    
    public void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestions[index];
        questionText.text = currentQuestion.question;
    }

    void ResetQuestions()
    {
        answerRenderer.sprite = null;
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        ResetQuestions();
        yield return  new WaitForSeconds(timeBetweenQuestion);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SetCurrentQuestion();
    }

    public void ButtonPressed()
    {
        if (currentQuestion.isTrue)
        {
            answerRenderer.sprite = trueSprite;
        }
        else
        {
            answerRenderer.sprite = falseSprite;
        }
        
        StartCoroutine(TransitionToNextQuestion());
    }
    
}
