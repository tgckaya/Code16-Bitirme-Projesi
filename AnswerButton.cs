using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    public Text answerText;
    private AnswerData answerData;
    private GameController gameController;
    private Button btn;
       void Start()
    {
        gameController = FindObjectOfType<GameController>();
        btn = GetComponent<Button>();
        btn.onClick.AddListener(HandleClick);
        
    }

   public void Setup(AnswerData data)
    {
        answerData = data;
        answerText.text = answerData.answerText;
    }
    public void HandleClick()
    {
        gameController.AnswerButtonClicked(answerData.isCorrect);
    }
}
