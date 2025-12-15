using UnityEngine;
// INHERITANCE
public class ProductivityUnit : Unit
{

    private ResourcePile m_CurrentPile = null;
    public float ResourceMultiplier = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        BuildingInRange();
    }

    // POLYMORPHISM
    protected override void BuildingInRange()
    {
        if (m_CurrentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                Debug.Log("I AM WORKING");

                m_CurrentPile = pile;
                m_CurrentPile.ProductionSpeed *= ResourceMultiplier;
                Debug.Log($"BuildingInRange: m_Target={m_Target} is ResourcePile? {(m_Target is ResourcePile)}, currentProduction={m_CurrentPile?.ProductionSpeed}");
            }
        }
    }

    private void ResetProductivity()
    {
        if (m_CurrentPile != null)
        {
            m_CurrentPile.ProductionSpeed /= ResourceMultiplier;
            m_CurrentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 position)
    {
        ResetProductivity();
        base.GoTo(position);
    }
}
