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
    private int score;
    
    private int quizLength;
    //[SerializeField] private Sprite answer;

    private TextMeshProUGUI questionText;
    [SerializeField] private float timeBetweenQuestion = 2f;
    
    [SerializeField] private Image answerRenderer;
    [SerializeField] private Sprite falseSprite;
    [SerializeField] private Sprite trueSprite;
    
    [SerializeField] private GameObject answerImage;
    [SerializeField] private GameObject trueButton;
    [SerializeField] private GameObject falseButton;
    [SerializeField] private GameObject resetButton;

    private void Start()
    {
        questionText = GameObject.FindGameObjectWithTag("questionText").GetComponent<TextMeshProUGUI>();
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            quizLength = unansweredQuestions.Count;
        }

        index = 0;
        score = 0;
        SetCurrentQuestion();
    }

    public void SetCurrentQuestion()
    {
        currentQuestion = unansweredQuestions[index];
        questionText.text = currentQuestion.question;
    }

    IEnumerator TransitionToNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);
        answerImage.SetActive(false);
        
        if (unansweredQuestions.Count == 0)
        {
            EndQuiz();
        }
        else
        {
            SetCurrentQuestion();
            Canvas.ForceUpdateCanvases();
        }
    }
    
    public void TruePressed()
    {
        if (currentQuestion.isTrue)
        {
            score++;
        }

        ButtonPressed();
    }
    
    public void FalsePressed()
    {
        if (!currentQuestion.isTrue)
        {
            score++;
        }
        ButtonPressed();
    }

    public void ButtonPressed()
    {
        answerRenderer.sprite = currentQuestion.isTrue ? trueSprite : falseSprite;
        answerImage.SetActive(true);

        StartCoroutine(TransitionToNextQuestion());
    }

    public void EndQuiz()
    {
        trueButton.SetActive(false);
        falseButton.SetActive(false);
        resetButton.SetActive(true);
        questionText.text = score + "/" + quizLength;
    }

    public void ResetPressed()
    {
        resetButton.SetActive(false);
        trueButton.SetActive(true);
        falseButton.SetActive(true);
        Canvas.ForceUpdateCanvases();
        Start();
    }

}
