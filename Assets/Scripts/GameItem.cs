using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameItem
{
    public ItemKey key;
    public long amount;
    public GameItem(ItemKey key, long amount)
    {
        this.key = key;
        this.amount = amount;
    }
    public GameItem AddValue(int levelEnhance)
    {
        return new GameItem(key, amount * levelEnhance);
    }
}

[Serializable]
public enum ItemKey
{
    //currency
    Gold,
    Stone,
    Ruby,
    Gem,
    Food,
    ArenaTicket
}