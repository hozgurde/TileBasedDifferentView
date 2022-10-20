using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{

    enum DayTime
    {
        Day = 0,
        Night = 1
    }

    public TilemapRenderer nightTilemapRenderer;
    public SpriteMask dayMask;
    public Player player;

    public SpriteRenderer nightFilter;
    public TilemapRenderer dayTilemapRenderer;

    private DayTime dayTime;

    // Start is called before the first frame update
    void Start()
    {
        dayTime = DayTime.Day;
        dayTilemapRenderer.sortingOrder = 1;
        dayTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
        nightTilemapRenderer.sortingOrder = 0;
        nightTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
        nightFilter.sortingOrder = 0;
        nightFilter.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPlayer();
    }

    private void FollowPlayer()
    {
        dayMask.transform.position = player.transform.position;
    }

    public void ChangeTimeDemo()
    {
        switch (dayTime)
        {
            case DayTime.Day:
                dayTime = DayTime.Night;
                break;
            case DayTime.Night:
                dayTime = DayTime.Day;
                break;
            default:
                break;
        }

        switch (dayTime)
        {
            case DayTime.Day:
                dayTilemapRenderer.sortingOrder = 1;
                dayTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                nightTilemapRenderer.sortingOrder = 0;
                nightTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                nightFilter.sortingOrder = 0;
                nightFilter.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                break;
            case DayTime.Night:
                dayTilemapRenderer.sortingOrder = 0;
                dayTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleInsideMask;
                nightTilemapRenderer.sortingOrder = 1;
                nightTilemapRenderer.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                nightFilter.sortingOrder = 1;
                nightFilter.maskInteraction = SpriteMaskInteraction.VisibleOutsideMask;
                break;
            default:
                break;
        }

    }
}
