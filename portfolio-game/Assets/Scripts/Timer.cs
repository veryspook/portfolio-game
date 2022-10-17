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

    [SerializeField] private int turnsPassed;

    // Start is called before the first frame update
    private void Start()
    {
        Being(Duration);
        turnsPassed = 0;
        keepArtifact = true;
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
                        uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                        remainingDuration -= 0.1f;
                        yield return new WaitForSeconds(0.1f);
                        text.text = $"{(int)(remainingDuration)}";
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
            GameManager.instance.OnRoundStart();
            
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
}
