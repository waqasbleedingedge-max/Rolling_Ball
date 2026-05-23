//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Just_Net : MonoBehaviour
//{
//    public static Just_Net Instance;

//    public GameObject _Next;
//    public string tag = "Player";
//    public string _name = "Player_Ball";

//    GameObject _This;
//    MeshRenderer mr;
//    BoxCollider br;

//    void Awake()
//    {
//        Instance = this;
//    }

//    void OnEnable()
//    {
//        _This = this.gameObject;
//        mr = _This.GetComponent<MeshRenderer>();
//        br = _This.GetComponent<BoxCollider>();
//        mr.enabled = false;
//    }

//    void OnTriggerEnter(UnityEngine.Collider xXx)
//    {
//        if (xXx.transform.CompareTag(tag) && xXx.transform.gameObject.name == _name)
//        {
//            _Next = xXx.transform.gameObject;
//            Try();
//            PlayerPrefs.SetInt("Internet_Allow", 1);
//            print("Net= On Tri");
//        }
//    }

//    void OnCollisionEnter(Collision xXx)
//    {
//        if (xXx.transform.CompareTag(tag) && xXx.transform.gameObject.name == _name)
//        {
//            _Next = xXx.transform.gameObject;
//            Try();
//            PlayerPrefs.SetInt("Internet_Allow", 1);
//            print("Net= On Col");
//        }
//    }

//    void Try()
//    {
//        if (Admob_other.Instance.Internet == true)
//        {
//            // Time.timeScale = 1f;
//            _Next.GetComponent<Rigidbody>().isKinematic = false;
//        }
//        else
//        {
//            // Time.timeScale = 0f;
//            _Next.GetComponent<Rigidbody>().isKinematic = true;
//        }
//        print("Net= Try");
//    }

//    bool _Off;
//    public void Btn_Off()
//    {
//        if (_Off == false)
//        {
//            _Off = true;
//            if (_Next != null)
//            {
//                _Next.GetComponent<Rigidbody>().isKinematic = false;
//            }
//        }
//    }
//}