using UnityEngine;

public class PoolableObject : MonoBehaviour
{
    /* The parent object pool this object belongs to */
    private ObjectPool m_Parent;

    /* Safe keep boolean check to eliminate multiple pools of this object */
    protected bool m_IsAlreadyPooled = false;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    /*
     * called once when the object is created
     */
    public virtual void OnStart()
    {

    }

    public virtual void OnEnable()
    {
        m_IsAlreadyPooled = false;
    }

    /*
     * When object is disabled, it returns to the parents pool
     */
    public virtual void OnDisable()
    {
        m_Parent.ReturnToPool(this);
    }

    /*
     * Calls the OnDisable() function, which returns object to their object pools
     */
    public void Pool()
    {
        if (!m_IsAlreadyPooled)
        {
            gameObject.SetActive(false);
            m_IsAlreadyPooled = true;
        }
    }

    public void SetParent(ObjectPool parent)
    {
        m_Parent = parent;
    }
}
