using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class F2FNPCSystemAI : MonoBehaviour
{


    NavMeshAgent agent;

    Animator animator;

    public GameObject ObjectToFollow;

    bool ShouldFollowPlayer = false;

    public GameObject[] RandomSpots;

    bool ShouldGoToRandomSpots = false;

    public int RandomSpotNumber = 0;

    // num 1 = rs 1, numb 2 = rs 2, num 3 = rs 3


    // part 3 

    bool ShouldGoToFinalDestination = false;

    public GameObject FinalDestination_GameObject;

    bool AIIsTalking = false;

    bool AITalkedOnce = false;

    // talk

    public Text subtext;

    public GameObject TalkPanel;

    // talk


    // part 3 


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


        // tell the ai what to do

        ShouldFollowPlayer = false;

        ShouldGoToRandomSpots = false;

        ShouldGoToFinalDestination = true;

        // tell the ai what to do


        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        
    }

    // Update is called once per frame
    void Update()
    {



        if (Input.GetKeyDown(KeyCode.F))
        {


            ShouldFollowPlayer = true;
            ShouldGoToRandomSpots = false;
            RandomSpotNumber = 0;





        }

        if (Input.GetKeyDown(KeyCode.T))
        {


            ShouldGoToRandomSpots = true;
            ShouldFollowPlayer = false;
            RandomSpotNumber = 2;


        }



        if(ShouldFollowPlayer == true)
        {



            float Distance = Vector3.Distance(transform.position, ObjectToFollow.transform.position);

            if (Distance < 5)
            {

                // IDLE 

                agent.isStopped = true;

                animator.SetInteger("C", 0);


            }
            else if (Distance >= 5 && Distance < 12)
            {


                // Walk

                agent.isStopped = false;

                animator.SetInteger("C", 1);

                agent.speed = 3;

                agent.SetDestination(ObjectToFollow.transform.position);

            }
            else if (Distance >= 12)
            {


                // Run

                agent.isStopped = false;

                animator.SetInteger("C", 2);

                agent.speed = 6;

                agent.SetDestination(ObjectToFollow.transform.position);

            }


        }


        if(ShouldGoToRandomSpots == true)
        {

            if(RandomSpotNumber == 1)
            {


                // ai to go to 1

                float Distance = Vector3.Distance(transform.position, RandomSpots[0].transform.position);

                agent.SetDestination(RandomSpots[0].transform.position);

                if(Distance < 2)
                {


                    agent.isStopped = true;

                    animator.SetInteger("C", 0);


                }
                else if(Distance >= 2 && Distance <= 6)
                {


                    agent.isStopped = false;
                    animator.SetInteger("C", 1);

                    agent.speed = 3;


                }
                else if(Distance > 6)
                {


                    agent.isStopped = false;
                    animator.SetInteger("C", 2);

                    agent.speed = 6;

                }



            }
            else if(RandomSpotNumber == 2)
            {



                // ai to go to 2

                float Distance = Vector3.Distance(transform.position, RandomSpots[1].transform.position);

                agent.SetDestination(RandomSpots[1].transform.position);

                if (Distance < 2)
                {


                    agent.isStopped = true;

                    animator.SetInteger("C", 0);


                }
                else if (Distance >= 2 && Distance <= 6)
                {


                    agent.isStopped = false;
                    animator.SetInteger("C", 1);
                    agent.speed = 3;

                }
                else if (Distance > 6)
                {


                    agent.isStopped = false;
                    animator.SetInteger("C", 2);
                    agent.speed = 6;
                }


            }
            else if(RandomSpotNumber == 3)
            {


                // ai to go to 3

                float Distance = Vector3.Distance(transform.position, RandomSpots[2].transform.position);

                agent.SetDestination(RandomSpots[2].transform.position);

                if (Distance < 2)
                {


                    agent.isStopped = true;

                    animator.SetInteger("C", 0);


                }
                else if (Distance >= 2 && Distance <= 6)
                {


                    agent.isStopped = false;
                    animator.SetInteger("C", 1);
                    agent.speed = 3;

                }
                else if (Distance > 6)
                {


                    agent.isStopped = false;
                    animator.SetInteger("C", 2);
                    agent.speed = 6;
                }




            }




        }



        if(ShouldGoToFinalDestination == true && AIIsTalking == false)
        {


            float DistanceUstoAI = Vector3.Distance(transform.position, ObjectToFollow.transform.position);

            float DistanceFinal = Vector3.Distance(transform.position, FinalDestination_GameObject.transform.position);



            if(DistanceUstoAI <= 15)
            {




                if (DistanceFinal < 5)
                {


                    // Ai reached Destination

                    agent.isStopped = true; // stop the ai 

                    animator.SetInteger("C", 0); // idle animation



                }
                else if (DistanceFinal >= 5)
                {


                    // Ai should go to destination

                    agent.isStopped = false; // activate AI

                    animator.SetInteger("C", 1); // walk animation

                    agent.speed = 3;

                    agent.SetDestination(FinalDestination_GameObject.transform.position); // tell the ai to go to the final destination

                    AITalkedOnce = false;



                }



            }
            else if(DistanceUstoAI > 15)
            {


                // stop the ai and wait for the player to come in 

                agent.isStopped = true; // stop the ai

                animator.SetInteger("C", 0); // idle animation


                if(AITalkedOnce == false)
                {

                    StartCoroutine(AITalkingCO());


                }

                



            }



            




        }





        
    }







    IEnumerator AITalkingCO()
    {


        AIIsTalking = true;

        AITalkedOnce = true;

        TalkPanel.SetActive(true);
        subtext.text = "Move Faster, We are late";

        yield return new WaitForSeconds(2f);

        TalkPanel.SetActive(false);
        subtext.text = "";

        AIIsTalking = false;




    }



}
