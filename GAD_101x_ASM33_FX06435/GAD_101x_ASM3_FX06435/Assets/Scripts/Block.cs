using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Block : MonoBehaviour
{
    [SerializeField]
    private TextMeshPro textHP;
    [SerializeField]
    private float blockHP = 99;
    [SerializeField]
    private float fallingSpeed = 3.0f;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        textHP.text = blockHP.ToString();
        timer = fallingSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //moi 3s block se dich chuyen xuong 1 lan
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            gameObject.transform.position = new Vector2(gameObject.transform.position.x, gameObject.transform.position.y - 0.1f);
            timer = fallingSpeed;
        }
    }

    public void OnDamaged(float damage)
    {
        //HP cua block se bi giam bang luong damage cua dan
        if (blockHP > 0)
        {
            blockHP -= damage;
        }

        //cap nhat lai hien thi HP cua block
        textHP.text = blockHP.ToString();

        //neu HP <= 0 block se bi destroy
        if (blockHP <= 0)
        {
            Destroy(gameObject);
            BlockController.instance.blockCount -= 1;

            if (BlockController.instance.blockCount <= 0)
            {
                BlockController.instance.ActiveWinPopUp();
            }
        }
    }
}
