using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private TextMeshProUGUI text;

    public float Duration;

    public float remainingDuration;

    private bool Pause;

    private bool keepArtifact;

    private bool timerStop;

    [SerializeField] private int turnsPassed;

    public GameObject hostessTextObject;
    public TextMeshProUGUI hostessText;

    // Start is called before the first frame update
    private void Start()
    {
        Being(Duration);
        turnsPassed = 0;
        keepArtifact = true;
        timerStop = false;
    }

    private IEnumerator OnRoundStart()
    {
        Pause = true;
        yield return new WaitForSeconds(5.0f);
        remainingDuration = 10.0f;
        Pause = false;
    }

    // Update is called once per frame
    private void Being(float Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while (remainingDuration >= 0)
        {
            text.text = $"{(int)(remainingDuration)}";
            if (!Pause)
            {
                if (timerStop == true)
                {
                    //update this later to print which player won the round
                    hostessTextObject.SetActive(true);
                    hostessText.text = "Round Over.";
                    //
                    yield return new WaitForSeconds(5f);
                    hostessTextObject.SetActive(false);
                    uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration -= 0.1f;
                    yield return new WaitForSeconds(0.1f);
                    text.text = $"{(int)(remainingDuration)}";
                    timerStop = false;
                }
                if (timerStop == false)
                {
                    uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                    remainingDuration -= 0.1f;
                    yield return new WaitForSeconds(0.1f);
                    text.text = $"{(int)(remainingDuration)}";
                }
            }

        }
        yield return null;
        OnEnd();
    }

    private void OnEnd()
    {
        uiFill.fillAmount = Mathf.InverseLerp(0, 0, 0);
        //End turn when timer is done
        //StartCoroutine(OnRoundStart());
        if (keepArtifact == false)
        {
            timerStop = true;
            Invoke("AfterRoundDialogue", 5f);
        }
        else
        {
            GameManager.instance.OnTurnStart();
            
        }
        turnsPassed += 1;
        if (turnsPassed != 3)
        {
            keepArtifact = true;
        }
        else
        {
            keepArtifact = false;
            turnsPassed = 0;
        }
        Being(Duration);
    }

    public void AfterRoundDialogue()
    {
        GameManager.instance.OnRoundStart();
    }
}
