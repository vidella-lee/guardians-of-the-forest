using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestTrigger : MonoBehaviour
{
    private QuestManager theQM;
    public int questNumber;
    public bool startQuest;
    public bool endQuest;

    // Start is called before the first frame update
    void Start()
    {
        theQM = FindObjectOfType<QuestManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            //check to see if quest is completed
            if(!theQM.questCompleted[questNumber])
            {
                //check to see if quest is currently active, if not activate it
                if(startQuest && !theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].gameObject.SetActive(true);
                    theQM.quests[questNumber].StartQuest();
                }

                if(endQuest && theQM.quests[questNumber].gameObject.activeSelf)
                {
                    theQM.quests[questNumber].EndQuest();
                }
            }
        }
    }
}
