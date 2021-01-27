using UnityEngine.UI;
using UnityEngine;

public class MatchingScript : MonoBehaviour
{
    GameObject first;
    GameObject second;
    public Transform point1;
    public Transform point2;
    Vector3 offset = new Vector3(0, 1.5f, 0);
    bool StartCombo;
    public Slider comboBarSlider;
    public Text comboText;
    float comboTime = 5;
    public static int comboNum = 0;
    float speed = 10f;
    float rotSpeed = 10f;
    bool correct;


    void Update()
    {
        Matching();
        Combo();
    }

    void Combo()
    {
        comboText.text = "x" + comboNum;
        if (comboBarSlider.value > 0)
        {
            comboBarSlider.value -= Time.deltaTime * comboNum /2;
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
            Vector3 targetPosIn2D = DragNDrop.target.transform.position;
            targetPosIn2D.y = 0;
            Vector3 platformPosIn2D = this.transform.position;
            platformPosIn2D.y = 0;
            var dist = Vector3.Distance(targetPosIn2D, platformPosIn2D);
            if (dist <= 5 && !DragNDrop.isMouseDragging)
            {
                if (first == null)
                {//put in first point
                    first = DragNDrop.target;
                    first.transform.position = point1.position + offset;
                    first.GetComponent<Rigidbody>().isKinematic = true;
                    DragNDrop.target = null;
                }
                else if (second == null)
                {//put in second point
                    second = DragNDrop.target;
                    second.transform.position = point2.position + offset;
                    second.GetComponent<Rigidbody>().isKinematic = true;
                }
                else
                {//Correct Match
                    if (first.GetComponent<MeshFilter>().name == second.GetComponent<MeshFilter>().name)
                    {
                        DragNDrop.target = null;
                        first.GetComponent<Collider>().enabled = false;
                        second.GetComponent<Collider>().enabled = false;
                        correct = true;
                    }
                    else
                    {//Incorrect Match
                        second.GetComponent<Rigidbody>().isKinematic = false;
                        second.GetComponent<Rigidbody>().AddForce(100000f * transform.forward * Time.deltaTime);
                        DragNDrop.target = null;
                    }
                }
            }
        }
        if (correct)
        {
            if (first.transform.position != second.transform.position)
            {
                first.transform.position = Vector3.MoveTowards(first.transform.position, second.transform.position, speed * Time.deltaTime);
                second.transform.position = Vector3.MoveTowards(second.transform.position, first.transform.position, speed * Time.deltaTime);
            }
            else
            {
                Destroy(first);
                Destroy(second);
                correct = false;
                first = null;
                second = null;
                comboNum += 1;
                comboBarSlider.value = comboTime;
                ScoreScript.instance.addScore();
            }
        }
        

        if (first != null)
        {
            first.transform.rotation = Quaternion.Slerp(first.transform.rotation, Quaternion.Euler(Vector3.zero), rotSpeed * Time.deltaTime);
            if (Vector3.Distance(point1.position, first.transform.position) >= 4)
            {
                first.GetComponent<Rigidbody>().isKinematic = false;
                first = null;
            }
        }
         
        if (second != null)
        {
            second.transform.rotation = Quaternion.Slerp(second.transform.rotation, Quaternion.Euler(Vector3.zero), rotSpeed * Time.deltaTime);
            if (Vector3.Distance(point2.position, second.transform.position) >= 4)
            {
                second.GetComponent<Rigidbody>().isKinematic = false;
                second = null;
            }
        }
    }
}
