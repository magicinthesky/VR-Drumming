using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Valve.VR.InteractionSystem
{
    public class Tutorial : MonoBehaviour
    {

        float waitTime = 0.0f;
        float timer = 0.0f;
        float waiter = 0.0f;
        float betweener = 0.0f;
        bool check = true;

        public Material Light;
        public Material Default;
        public Material Correct;
        public Material Wrong;

        public GameObject lefthand;
        public GameObject righthand;
        public Vector3 velocityl;
        public Vector3 velocityr;

        GameObject w;

        // Use this for initialization
        void Start()
        {
            waiter = Time.time;
            waitTime = Time.time;
        }

        // Update is called once per frame
        void Update()
        {
            velocityl = lefthand.GetComponent<VelocityEstimator>().speed;
            velocityr = righthand.GetComponent<VelocityEstimator>().speed;

            timer = Time.time;
            betweener = timer - waiter;
            if (check)
            {
                for (int i = 1; i <= 4; i++)
                {
                    if (betweener > 0.0f && betweener < 1.0f)
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 1.1f && betweener < 2.0f)
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 2.1f && betweener < 3.0f)
                    {
                        GameObject.FindWithTag("04inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 3.1f && betweener < 3.5f)
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 3.6f && betweener < 4.0f)
                    {
                        GameObject.FindWithTag("25inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 4.1f && betweener < 5.0f)
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 5.1f && betweener < 6.0f)
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 6.1f && betweener < 7.0f)
                    {
                        GameObject.FindWithTag("04inner").GetComponent<Renderer>().material = Light;
                    }
                    else if (betweener > 7.1f && betweener < 7.8f)
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Light;
                    }
                    else
                    {
                        GameObject.FindWithTag("24inner").GetComponent<Renderer>().material = Default;
                        GameObject.FindWithTag("25inner").GetComponent<Renderer>().material = Default;
                        GameObject.FindWithTag("04inner").GetComponent<Renderer>().material = Default;
                    }

                    if (timer - waiter >= 8.0f)
                    {
                        waiter = timer;
                    }
                }
            }
            if (timer > 32.0f + waitTime)
            {
                check = false;
            }
        }

        void OnCollisionEnter(Collision collision)
        {
            if(velocityl.y < 0 || velocityr.y < 0)
            {
                if (timer <= 32.0f + waitTime)
                {
                    if (betweener > 0.0f && betweener < 1.0f)
                    {
                        if (collision.gameObject.tag == "24inner")
                        {
                            GameObject s = GameObject.FindWithTag("24inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);

                        }
                    }
                    if (betweener > 1.1f && betweener < 2.0f)
                    {
                        if (collision.gameObject.tag == "24inner")
                        {
                            GameObject s = GameObject.FindWithTag("24inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }

                    if (betweener > 2.1f && betweener < 3.0f)
                    {
                        if (collision.gameObject.tag == "04inner")
                        {
                            GameObject s = GameObject.FindWithTag("04inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }
                    if (betweener > 3.1f && betweener < 3.5f)
                    {
                        if (collision.gameObject.tag == "24inner")
                        {
                            GameObject s = GameObject.FindWithTag("24inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }
                    if (betweener > 3.6f && betweener < 4.0f)
                    {
                        if (collision.gameObject.tag == "25inner")
                        {
                            GameObject s = GameObject.FindWithTag("25inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }
                    if (betweener > 4.1f && betweener < 5.0f)
                    {
                        if (collision.gameObject.tag == "24inner")
                        {
                            GameObject s = GameObject.FindWithTag("24inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }
                    if (betweener > 5.1f && betweener < 6.0f)
                    {
                        if (collision.gameObject.tag == "24inner")
                        {
                            GameObject s = GameObject.FindWithTag("24inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }

                    if (betweener > 6.1f && betweener < 7.0f)
                    {
                        if (collision.gameObject.tag == "04inner")
                        {
                            GameObject s = GameObject.FindWithTag("04inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }
                    if (betweener > 7.1f && betweener < 8.0f)
                    {
                        if (collision.gameObject.tag == "24inner")
                        {
                            GameObject s = GameObject.FindWithTag("24inner");
                            s.GetComponents<AudioSource>()[0].Play();
                            s.GetComponent<Renderer>().material = Correct;
                            ScoreManager.score++;
                        }
                        else
                        {
                            GameObject s = GameObject.Find("Steering");
                            s.GetComponent<AudioSource>().Play();
                            w = collision.gameObject;
                            w.GetComponent<Renderer>().material = Wrong;
                            Invoke("Disappear", 0.1f);
                        }
                    }
                }
            }
            

        }

        void Disappear()
        {
            w.GetComponent<Renderer>().material = Default;
        }

    }

}