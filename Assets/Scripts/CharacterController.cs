using PaintIn3D;
using UnityEngine;
using UnityEngine.UI;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private GameObject paint;
    [SerializeField] private GameObject brush;
    [SerializeField] private GameObject snakePaint;
    [SerializeField] private GameObject brushController;
    [SerializeField] private GameObject otherPlayerPaint;
    [SerializeField] private GameObject otherPlayerSnakePaint;
    [SerializeField] private GameObject otherPlayerAttackManager;

    [SerializeField] private Image pickUp;
    [SerializeField] private Sprite[] pickUpSprites;
    [SerializeField] private Sprite pickUpEmptySprites;

    [SerializeField] private Animator m_Animator;

    private bool isHoldAbility;
    private int abilityNumber;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Health") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 0;
            pickUp.sprite = pickUpSprites[abilityNumber];
        }
        if (other.CompareTag("Brush") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 1;
            pickUp.sprite = pickUpSprites[abilityNumber];
        }
        if (other.CompareTag("Axe") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 2;
            pickUp.sprite = pickUpSprites[abilityNumber];
        }
        if (other.CompareTag("Snake") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 3;
            pickUp.sprite = pickUpSprites[abilityNumber];
        }
        if (other.CompareTag("Spell") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 4;
            pickUp.sprite = pickUpSprites[0];
        }
        if (other.CompareTag("Shield") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 5;
            pickUp.sprite = pickUpSprites[abilityNumber];
        }
        if (other.CompareTag("Freeze") && !isHoldAbility)
        {
            Destroy(other.gameObject);
            isHoldAbility = true;
            abilityNumber = 6;
            pickUp.sprite = pickUpSprites[abilityNumber];
        }
    }

    private void ReturnBrushRadiusSize()
    {
        paint.GetComponent<P3dPaintSphere>().Radius = 0.1f;
        brush.transform.localScale = new(75, 75, 1470);
    }

    private void Return_to_OldAttackPower()
    {
        gameObject.transform.localScale = new(1f, 1f, 1f);
        gameObject.transform.parent.GetComponent<AttackManager>().attackPower = 5;
    }

    private void HideSnakesAttackPower()
    {
        snakePaint.SetActive(false);
    }

    private void RemoveSpellEffectiveness()
    {
        otherPlayerPaint.SetActive(true);
    }

    private void RemoveShieldEffectiveness()
    {
        otherPlayerAttackManager.GetComponent<AttackManager>().attackPower = 5;
        m_Animator.SetBool("isShilded", false);
    }

    private void RemoveFreezerEffectiveness()
    {
        if (paint.GetComponent<P3dPaintSphere>().Color == Color.red)
        {
            brushController.GetComponent<BrushController>().greenBrushRotationSpeed = 100;
            brushController.GetComponent<BrushController>().greenBrushSpeed = 0.02f;
        }
        else if (paint.GetComponent<P3dPaintSphere>().Color == Color.green)
        {
            brushController.GetComponent<BrushController>().redBrushRotationSpeed = 100;
            brushController.GetComponent<BrushController>().redBrushSpeed = 0.02f;
        }
    }

    public void OnAbblityButtonClicked()
    {
        if (isHoldAbility)
        {
            switch (abilityNumber)
            {
                case 0:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    gameObject.transform.parent.GetComponent<AttackManager>().Health = 100;
                    break;
                case 1:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    paint.GetComponent<P3dPaintSphere>().Radius = 0.15f;
                    brush.transform.localScale = new(120, 120, 2360);
                    Invoke(nameof(ReturnBrushRadiusSize), 3f);
                    break;
                case 2:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    gameObject.transform.parent.GetComponent<AttackManager>().attackPower = 7;
                    gameObject.transform.localScale = new(1.5f, 1.5f, 1.5f);
                    Invoke(nameof(Return_to_OldAttackPower), 5f);
                    break;
                case 3:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    snakePaint.SetActive(true);
                    Invoke(nameof(HideSnakesAttackPower), 8.5f);
                    break;
                case 4:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    otherPlayerPaint.SetActive(false);
                    otherPlayerSnakePaint.SetActive(false);
                    Invoke(nameof(RemoveSpellEffectiveness), 6.5f);
                    break;
                case 5:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    otherPlayerAttackManager.GetComponent<AttackManager>().attackPower = 0;
                    m_Animator.SetBool("isShilded", true);
                    Invoke(nameof(RemoveShieldEffectiveness), 5.5f);
                    break;
                case 6:
                    isHoldAbility = false;
                    pickUp.sprite = pickUpEmptySprites;
                    if (paint.GetComponent<P3dPaintSphere>().Color == Color.red)
                    {
                        brushController.GetComponent<BrushController>().greenBrushRotationSpeed = 0;
                        brushController.GetComponent<BrushController>().greenBrushSpeed = 0;
                    }
                    else if (paint.GetComponent<P3dPaintSphere>().Color == Color.green)
                    {
                        brushController.GetComponent<BrushController>().redBrushRotationSpeed = 0;
                        brushController.GetComponent<BrushController>().redBrushSpeed = 0;
                    }
                    Invoke(nameof(RemoveFreezerEffectiveness), 4.5f);
                    break;
                default: break;
            }
        }
    }
}
