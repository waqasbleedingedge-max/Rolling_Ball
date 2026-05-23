using NA.Vehicles.Ball;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CollissionManager : MonoBehaviour
{
    public GameObject Temp;

    public string Barrel = "Barrel";
    public ParticleSystem Barrel_Effect;
    public AudioSource Barrel_Sound;

    public string Other = "Other";
    public ParticleSystem boundaryCollision;
    public AudioSource boundaryCollisionSound;

   // public BallUserControl bUC;
    public bool Once = false;

    private void OnCollisionEnter(Collision collision)
    {
        Temp = collision.gameObject;
        if (collision.gameObject.CompareTag("Boundary"))
        {
            if (collision.gameObject.name == Barrel)
            {
                print("Coll_B 0_" + Temp);
                Barrel_Effect.Play();
                Barrel_Effect.transform.position = this.transform.position;
                Barrel_Effect.transform.rotation = this.transform.rotation;
                Barrel_Effect.transform.SetPositionAndRotation(this.transform.position, Barrel_Effect.transform.rotation);
                Barrel_Effect.Play();

                Barrel_Sound.Play();
            }
            else
            {
                print("Coll_B 1_" + Temp);

                boundaryCollision.Play();
                // boundaryCollision.transform.SetPositionAndRotation(this.transform.position, boundaryCollision.transform.rotation);
                boundaryCollision.Play();

                boundaryCollisionSound.Play();
            }
        }
        else if (collision.gameObject.CompareTag("Pipe"))
        {
           // bUC.onPipes = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HittedObj"))
        {
            if (!Once)
            {
                Debug.Log("HittedBall");
                DestroyBallOn();
                Once = true;
            }
        }
        if (other.gameObject.CompareTag("Pipe"))
        {
           // bUC.onPipes = true;
        }
        if (other.gameObject.CompareTag("PowerUp"))
        {
          //  bUC.ball.m_MovePower = 20;
        }
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Pipe"))
        {
          //  bUC.onPipes = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pipe"))
        {

          //  bUC.onPipes = false;
        }

    }



    void DestroyBallOn()
    {
        //for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
        //{
        //    LevelManager.Instance.playerBalls[i].SetActive(false);
        //}
        //if (LevelManager.Instance.MetalBallChk)
        //{
        //    LevelManager.Instance.MetalBall.SetActive(false);
        //    BallUserControl.Instance.rb.isKinematic = true;
        //    Instantiate(LevelManager.Instance.MetalBallBr, transform.position, transform.rotation);
        //    LevelManager.Instance.CameraOnFail();
        //    StartCoroutine(Fail());
        //}
        //else if (LevelManager.Instance.PaperBallChk)
        //{
        //    //LevelManager.Instance.PaperBall.SetActive(false);
        //    //BallUserControl.Instance.rb.isKinematic = true;
        //    //Instantiate(LevelManager.Instance.PaperBallBr, transform.position, transform.rotation);
        //    //LevelManager.Instance.CameraOnFail();
        //    //StartCoroutine(Fail());
        //}
        //else
        //{
        //    //for (int i = 0; i < LevelManager.Instance.playerBalls.Length; i++)
        //    //{
        //    //    LevelManager.Instance.playerBalls[i].SetActive(false);
        //    //}
        //    //BallUserControl.Instance.rb.isKinematic = true;
        //    //Instantiate(LevelManager.Instance.BreakAbleBalls[LevelManager.Instance.SelectedBallIndex], transform.position, transform.rotation);
        //    //LevelManager.Instance.CameraOnFail();
        //    //StartCoroutine(Fail());
        //}

    }

    //IEnumerator Fail()
    //{
    //    //yield return new WaitForSeconds(2);
    //    //if (LevelManager.Instance.MetalBallChk)
    //    //{
    //    //    LevelManager.Instance.MetalBall.SetActive(true);
    //    //}
    //    //else if (LevelManager.Instance.PaperBallChk)
    //    //{
    //    //    LevelManager.Instance.PaperBall.SetActive(true);
    //    //}
    //    //else
    //    //{
    //    //    LevelManager.Instance.playerBalls[LevelManager.Instance.SelectedBallIndex].SetActive(true);//PlayerPrefs.GetInt("selectedball")
    //    //}
    //    //LevelManager.Instance.LevelFailedINIT();
    //    //Once = false;
    //}

}
