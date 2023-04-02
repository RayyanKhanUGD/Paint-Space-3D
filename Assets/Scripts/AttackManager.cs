using UnityEngine;
using UnityEngine.UI;

public class AttackManager : MonoBehaviour
{

    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject OtherPLayer;
    public float Health;
    public Image HealthFill;
    public int attackPower = 5;
    [SerializeField] Animator m_Animator;


    private void Start()
    {
        Health = 100f;
    }

    private void Update()
    {
        HealthFill.fillAmount = Health / 100;
    }

    public void HA()
    {
        GameObject e = Instantiate(prefab1, transform.position, prefab1.transform.rotation);
        OtherPLayer.GetComponent<AttackManager>().Health -= attackPower * 3;
        m_Animator.SetTrigger("onAttack");
        Destroy(e, 3);
    }

    public void LA()
    {
        GameObject e = Instantiate(prefab2, transform.position, prefab2.transform.rotation);
        OtherPLayer.GetComponent<AttackManager>().Health -= attackPower * 2;
        m_Animator.SetTrigger("onAttack");
        Destroy(e, 3);
    }

    public void A()
    {
        GameObject e = Instantiate(prefab3, transform.position, prefab3.transform.rotation);
        OtherPLayer.GetComponent<AttackManager>().Health -= attackPower;
        m_Animator.SetTrigger("onAttack");
        Destroy(e, 3);
    }
}
