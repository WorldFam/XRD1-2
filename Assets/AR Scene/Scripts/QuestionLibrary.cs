using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class QuestionLibrary : MonoBehaviour
{
    public Question[] questions;
    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField] private Text questionText;
    [SerializeField] private float timeBetweenQuestion = 2f;
    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
        Debug.Log(currentQuestion.question + "is" + currentQuestion.isTrue);
    }

    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;
        
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return  new WaitForSeconds(timeBetweenQuestion);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void UserSelectTrue()
    {
        if (currentQuestion.isTrue)
        {
            Debug.Log("Correct");
        }
        else Debug.Log("Incorrect");

        StartCoroutine(TransitionToNextQuestion());
    }
    
    public void UserSelectFalse()
    {
        if (!currentQuestion.isTrue)
        {
            Debug.Log("Correct");
        }
        else Debug.Log("Incorrect");
        
        StartCoroutine(TransitionToNextQuestion());
    }

    
}
