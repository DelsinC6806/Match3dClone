using UnityEngine.UI;
using UnityEngine;

public class MatchingScript : MonoBehaviour
{
    GameObject first;
    GameObject second;
    public Transform point1;
    public Transform point2;
    Vector3 offset = new Vector3(0, 1f, 0);
    bool StartCombo;
    public Slider comboBarSlider;
    public Text comboText;
    float comboTime = 5;
    public static int comboNum = 0;
    void Update()
    {
        Matching();
        Combo();
        Debug.Log(comboNum);
    }

    void Combo()
    {
        comboText.text = "x" + comboNum;
        if (comboBarSlider.value >= 0)
        {
            comboBarSlider.value -= Time.deltaTime;
        }
        else
        {
            comboNum = 0;
            comboText.text = "x" + comboNum;
            StartCombo = false;
        }
    }

    void Matching()
    {
        if (DragNDrop.target != null)
        {
            if (Vector3.Distance(DragNDrop.target.transform.position, this.transform.position) <= 4)
            {
                if (first == null)
                {
                    first = DragNDrop.target;
                    first.transform.position = point1.position + offset;
                    first.GetComponent<Rigidbody>().isKinematic = true;
                    first.transform.rotation = Quaternion.Slerp(first.transform.rotation, Quaternion.EulerAngles(Vector3.zero), 1f);
                    DragNDrop.target = null;
                }
                else if (first != null && second == null)
                {
                    second = DragNDrop.target;
                    second.GetComponent<Rigidbody>().isKinematic = true;
                    second.transform.position = point2.position + offset;
                }
                else
                {
                    if (first.GetComponent<MeshFilter>().name == second.GetComponent<MeshFilter>().name)
                    {
                        Destroy(first);
                        Destroy(second);
                        first = null;
                        second = null;
                        comboNum += 1;
                        comboBarSlider.value = comboTime;
                        ScoreScript.instance.addScore();
                    }
                    else
                    {
                        second.GetComponent<Rigidbody>().isKinematic = false;
                        second.GetComponent<Rigidbody>().AddForce(2000f * transform.forward);
                        second = null;
                        DragNDrop.target = null;          
                    }
                }
            }
        }

        //Item back to normal if player drag out
        if (first != null)
        {
            if (Vector3.Distance(point1.position, first.transform.position) >= 2)
            {
                first.GetComponent<Rigidbody>().isKinematic = false;
                first = null;
            }
        }
        else if (second != null)
        {
            if (Vector3.Distance(point2.position, second.transform.position) >= 2)
            {
                second.GetComponent<Rigidbody>().isKinematic = false;
                second = null;
            }
        }
    }
}
