using UnityEngine;

public class Movement : MonoBehaviour
{
    public KeyCode jumpKey;

    public float speed = 10f;

    public SpriteRenderer m_SpriteRenderer;
    public Color m_NewColor;
    float m_Red, m_Blue, m_Green;

    void Start()
    {
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        Vector3 pos = transform.position;

        // "w" can be replaced with any key
        // this section moves the character up
        if (Input.GetKey("w"))
        {
            pos.y += speed * Time.deltaTime;
        }

        // "s" can be replaced with any key
        // this section moves the character down
        if (Input.GetKey("s"))
        {
            pos.y -= speed * Time.deltaTime;
        }

        // "d" can be replaced with any key
        // this section moves the character right
        if (Input.GetKey("d"))
        {
            pos.x += speed * Time.deltaTime;
        }

        // "a" can be replaced with any key
        // this section moves the character left
        if (Input.GetKey("a"))
        {
            pos.x -= speed * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_SpriteRenderer.color = m_NewColor;
        }
        transform.position = pos;
    }
}
