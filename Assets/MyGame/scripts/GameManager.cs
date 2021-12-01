using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private const int maxHit = 10;
    public GameObject target;
    public GameObject parentOfTargets;
    public GameObject objCounter;
    public GameObject wonObj;
    public GameObject noWoman1;
    public GameObject noWoman2;
    public GameObject couldYou1;
    public GameObject couldYou2;

    private Text textCounter;
    private bool won;
    private int score;
    private int soundrange;

    void Start()
    {
        textCounter = objCounter.GetComponent<Text>();
        won = false;
        InvokeRepeating("Spawn", 3f,4f);
        wonObj.SetActive(false);

    }

    private void Spawn()
    {
        float randomX = Random.Range(-350, 250);
        float randomY = Random.Range(-180, 180);

        Vector2 random2DPosition = new Vector2(randomX, randomY);

        GameObject myTarget = Instantiate(target, parentOfTargets.transform);
        myTarget.transform.localPosition = random2DPosition;


        Debug.Log(random2DPosition);
    }

    // Update is called once per frame
    void Update()
    {
        if(won == true)
        {
            CancelInvoke("Spawn");
            wonObj.SetActive(true);
        }
        else
        {
            Debug.Log(won);
        }

    }

    public void IncrementScore()
    {
        score++;
        Debug.Log("increment ... " + score);
        textCounter.text = score.ToString();

        if (Input.GetMouseButtonDown(0))
        {
            soundrange = Random.Range(1,5);
            Debug.Log(soundrange);
            if (soundrange == 1)
            {
                noWoman1.GetComponent<AudioSource>().Play();
            }
            if (soundrange == 2)
            {
                noWoman2.GetComponent<AudioSource>().Play();
            }
            if (soundrange == 3)
            {
                couldYou1.GetComponent<AudioSource>().Play();
            }
            if (soundrange == 4)
            {
                couldYou2.GetComponent<AudioSource>().Play();
            }

        }

        if (score == maxHit)
        {
            won = true;
        }
    }
}
