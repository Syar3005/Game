using igra;

// Создаем героя
Hero hero = new Hero("Рыцарь", 100, 10);

// Создаем рюкзак героя с предметами
Backpack heroBackpack = new Backpack(10);
heroBackpack.Items.Add(new Item("Зелье заморозки", 5, "Заморозка"));
heroBackpack.Items.Add(new Item("Меч", 15, "Крит"));


// Создаем врага
Enemy enemy = new Enemy("Бандит", 50, 5);

// Создаем рюкзак врага с предметами
Backpack enemyBackpack = new Backpack(10);
enemyBackpack.Items.Add(new Item("Отравленный кинжал", 10, "Яд"));


// Создаем арену и запускаем битву
BattleArena arena = new BattleArena(hero, enemy, heroBackpack, enemyBackpack);
arena.StartBattle();

// Если герой выжил, то он получает лут с побежденного врага
if (hero.Health > 0)
{
    Console.WriteLine($"{hero.Name} получил:");
    foreach (Item item in enemyBackpack.Items)
    {
        Console.WriteLine($"- {item.Name}");
        heroBackpack.Items.Add(item);
    }
}
else
{
    Console.WriteLine($"{enemy.Name} победил!");
}

// Выводим информацию о предметах в рюкзаке героя
Console.WriteLine($"В рюкзаке {hero.Name} сейчас следующие предметы:");
foreach (Item item in heroBackpack.Items)
{
    Console.WriteLine($"- {item.Name}");
}

Console.ReadLine();