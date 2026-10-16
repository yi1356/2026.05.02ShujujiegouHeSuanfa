using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 享元模式：把大量重复、不变的对象，只创建一次，全局共享使用，避免重复创建浪费内存
/// 这里的思路：每一个 Enemy 敌人实例 都包含两部分属性：
///1、共享属性
///抽离出来放到 EnemyBaseAttribute 对象里，同类型敌人共用这一个对象，不用每个敌人都重新创建一份一样的基础数据；
///2、独有属性
///直接作为 Enemy 自身的成员变量 存在，每个敌人自己独有、互不干扰，比如位置、当前血量这些每个人都不一样的数据。
/// </summary>
public class FlyWeightPatternTempel : MonoBehaviour
{
    private void Start()
    {
        EnemyFactory factory = new EnemyFactory();

        // ====================== 【创建多个敌人】 ======================
        // 敌人1：青铜敌人（位置(0,0)）
        Enemy enemy1 = new Enemy(factory, EnemyType.Bronze, new Vector3(0, 0, 0));
        enemy1.ShowInfo();

        // 敌人2：另一个青铜敌人（位置(10,10)）
        Enemy enemy2 = new Enemy(factory, EnemyType.Bronze, new Vector3(10, 10, 0));
        enemy2.ShowInfo();

        // 敌人3：白银敌人
        Enemy enemy3 = new Enemy(factory, EnemyType.Silver, new Vector3(5, 5, 0));
        enemy3.ShowInfo();

        // 敌人4：黄金敌人
        Enemy enemy4 = new Enemy(factory, EnemyType.Gold, new Vector3(0, 5, 0));
        enemy4.ShowInfo();

        // 测试：受伤（独有状态变化）
        enemy1.TakeDamage(3);
        enemy1.ShowInfo();
    }
}

public enum EnemyType
{
    Bronze,
    Silver,
    Gold
}

#region 【享元核心：共享部分 → 所有同类敌人共用，只存一份】
/// <summary>
/// 享元对象：敌人基础属性（不变、共享）
/// </summary>
public class EnemyBaseAttribute
{
    public string Name { get; }
    public int BaseHP { get; }       // 基础血量（共享）
    public float MoveSpeed { get; }
    public string PrefabName { get; }

    public EnemyBaseAttribute(string name, int hp, float moveSpeed, string prefabName)
    {
        Name = name;
        BaseHP = hp;
        MoveSpeed = moveSpeed;
        PrefabName = prefabName;
    }
}

/// <summary>
/// 享元工厂：管理共享对象
/// </summary>
public class EnemyFactory
{
    private Dictionary<EnemyType, EnemyBaseAttribute> mEnemyBaseAttrDict;

    public EnemyFactory()
    {
        mEnemyBaseAttrDict = new Dictionary<EnemyType, EnemyBaseAttribute>();
        InitBaseAttribute();
    }

    //用一个字典来缓存内部状态【共享部分】
    private void InitBaseAttribute()
    {
        mEnemyBaseAttrDict.Add(EnemyType.Bronze, new EnemyBaseAttribute("青铜", 10, 1, "BronzeModel"));
        mEnemyBaseAttrDict.Add(EnemyType.Silver, new EnemyBaseAttribute("白银", 30, 3, "SilverModel"));
        mEnemyBaseAttrDict.Add(EnemyType.Gold, new EnemyBaseAttribute("黄金", 50, 2, "GoldModel"));
    }

    public EnemyBaseAttribute GetBaseAttr(EnemyType type)
    {
        if (mEnemyBaseAttrDict.ContainsKey(type))
            return mEnemyBaseAttrDict[type];

        Debug.LogError("类型不存在：" + type);
        return null;
    }
}
#endregion

#region 【独有部分：每个敌人自己拥有，不共享】
/// <summary>
/// 独立敌人对象：包含共享属性 + 独有属性
/// </summary>
public class Enemy
{
    // ====================== 【共享部分】 ======================
    private EnemyBaseAttribute mBaseAttr;

    // ====================== 【独有部分：外部状态】 ======================
    private int mCurrentHP;          // 当前血量（独有的）
    private Vector3 mPosition;       // 位置（独有的）

    public Enemy(EnemyFactory factory, EnemyType type, Vector3 pos)
    {
        // 从工厂获取共享属性（享元核心！）
        mBaseAttr = factory.GetBaseAttr(type);

        // 初始化独有属性
        mCurrentHP = mBaseAttr.BaseHP;
        mPosition = pos;
    }

    // 受伤（独有状态变化）
    public void TakeDamage(int damage)
    {
        mCurrentHP -= damage;
        Debug.Log(mBaseAttr.Name + " 受到伤害！剩余血量：" + mCurrentHP);
    }

    // 显示信息
    public void ShowInfo()
    {
        Debug.Log($"【{mBaseAttr.Name}】"
                  + $" | 位置：{mPosition}"
                  + $" | 当前血量：{mCurrentHP}/{mBaseAttr.BaseHP}"
                  + $" | 移速：{mBaseAttr.MoveSpeed}");
    }
}
#endregion