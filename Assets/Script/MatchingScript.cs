using UnityEngine.UI;
using UnityEngine;

public class MatchingScript : MonoBehaviour
{
    GameObject first;
    GameObject second;
    public Transform point1;
    public Transform point2;
    public Transform matchingPoint;
    Vector3 offset = new Vector3(0, 1f, 0);
    bool StartCombo;
    public Slider comboBarSlider;
    public Text comboText;
    float comboTime = 5;
    public static int comboNum = 0;
    float speed = 5f;
    float rotSpeed = 3f;

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
            if (Vector3.Distance(DragNDrop.target.transform.position, this.transform.position) <= 5 && !DragNDrop.isMouseDragging)
            {
                if (first == null)
                {
                    first = DragNDrop.target;
                    first.transform.position = point1.position + offset;
                    first.GetComponent<Rigidbody>().isKinematic = true;
                    DragNDrop.target = null;
                }
                else if (second == null)
                {
                    second = DragNDrop.target;
                    second.transform.position = point2.position + offset;
                    second.GetComponent<Rigidbody>().isKinematic = true;     
                }
                else
                {
                    if (first.GetComponent<MeshFilter>().name == second.GetComponent<MeshFilter>().name) 
                    {
                        if(first.transform.rotation == Quaternion.Euler(Vector3.zero) && second.transform.rotation == Quaternion.Euler(Vector3.zero))
                        DragNDrop.target = null;
                        first.GetComponent<Collider>().enabled = false;
                        second.GetComponent<Collider>().enabled = false;
                        first.transform.position = Vector3.MoveTowards(first.transform.position,second.transform.position,speed * Time.deltaTime);
                        second.transform.position = Vector3.MoveTowards(second.transform.position,first.transform.position, speed * Time.deltaTime);
                        if(first.transform.position == second.transform.position)
                        {
                            Destroy(first);
                            Destroy(second);
                            first = null;
                            second = null;
                            comboNum += 1;
                            comboBarSlider.value = comboTime;
                            ScoreScript.instance.addScore();
                        }

                    }
                    else
                    {
                        second.GetComponent<Rigidbody>().isKinematic = false;
                        second.GetComponent<Rigidbody>().AddForce(200000f * transform.forward*Time.deltaTime);
                        second = null;
                        DragNDrop.target = null;          
                    }
                }
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
