using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace igra
{
    class BattleArena
    {
        public Hero Hero { get; set; }
        public Enemy Enemy { get; set; }
        public Backpack HeroBackPack { get; set; }
        public Backpack EnemyBackPack { get; set; }

        private int heroFreezeCounter = 0;
        private int heroPoisonCounter = 0;
        private int heroCritCounter = 0;

        private int enemyFreezeCounter = 0;
        private int enemyPoisonCounter = 0;
        private int enemyCritCounter = 0;

        private bool isHeroAttacks = true;

        public BattleArena(Hero hero, Enemy enemy, Backpack heroBackPack, Backpack enemyBackPack)
        {
            Hero = hero;
            Enemy = enemy;
            HeroBackPack = heroBackPack;
            EnemyBackPack = enemyBackPack;
        }

        public void StartBattle()
        {
            while (Hero.Health > 0 && Enemy.Health > 0)
            {
                if (isHeroAttacks == true)
                {
                    // Атака героя с учетом модификаторов
                    foreach (var item in HeroBackPack.Items)
                    {
                        // Яд
                        if (item.Mod == "Яд")
                        {
                            heroPoisonCounter++;
                            if (heroPoisonCounter < 5)
                            {
                                Console.WriteLine($"{Enemy.Name} отравлен");
                                Enemy.Health -= 10;
                            }
                            else
                            {
                                HeroBackPack.Items.Remove(item);
                                heroPoisonCounter = 0;
                            }
                        }
                        // КРИТ
                        if (item.Mod == "Крит")
                        {
                            heroCritCounter++;
                            if (heroCritCounter == 3)
                            {
                                Console.WriteLine($"КРИТ! {Hero.Name} нанес {Hero.Damage * 1.5} урона!");
                                Enemy.Health -= Convert.ToInt32(Hero.Damage * 1.5);
                                heroCritCounter = 0;
                            }
                        }
                        else
                        {
                            //Атака героя без крита
                            Enemy.Health -= Hero.Damage;
                            Console.WriteLine($"{Hero.Name} атакует {Enemy.Name} и наносит {Hero.Damage} урона!");
                        }
                        // Заморозка
                        if (item.Mod == "Заморозка")
                        {
                            heroFreezeCounter++;
                            if (heroFreezeCounter == 5)
                            {
                                Console.WriteLine($"{Enemy.Name} заморожен");
                                heroFreezeCounter = 0;
                                continue;
                            }
                        }
                        isHeroAttacks = false;
                    }
                }
                else
                {
                    // Атака врага с учетом модификаторов
                    foreach (var item in EnemyBackPack.Items)
                    {
                        // Яд
                        if (item.Mod == "Яд")
                        {
                            enemyPoisonCounter++;
                            if (enemyPoisonCounter < 5)
                            {
                                Console.WriteLine($"{Hero.Name} отравлен");
                                Hero.Health -= 10;
                            }
                            else
                            {
                                EnemyBackPack.Items.Remove(item);
                                enemyPoisonCounter = 0;
                            }
                        }
                        // КРИТ
                        if (item.Mod == "Крит")
                        {
                            enemyCritCounter++;
                            if (enemyCritCounter == 3)
                            {
                                Console.WriteLine($"КРИТ! {Enemy.Name} нанес {Enemy.Damage * 1.5} урона!");
                                Enemy.Health -= Convert.ToInt32(Hero.Damage * 1.5);
                                enemyCritCounter = 0;
                            }
                        }
                        else
                        {
                            //Атака врага без крита
                            Hero.Health -= Enemy.Damage;
                            Console.WriteLine($"{Enemy.Name} атакует {Hero.Name} и наносит {Enemy.Damage} урона!");
                        }
                        // Заморозка
                        if (item.Mod == "Заморозка")
                        {
                            enemyFreezeCounter++;
                            if (enemyFreezeCounter == 5)
                            {
                                Console.WriteLine($"{Hero.Name} заморожен");
                                enemyFreezeCounter = 0;
                                continue;
                            }
                        }
                        isHeroAttacks = true;
                    }
                }
                // Вывод статистики
                Console.WriteLine($"{Hero.Name}| Здоровье: {Hero.Health}| Урон: {Hero.Damage}");
                Console.WriteLine($"{Enemy.Name}| Здоровье: {Enemy.Health}| Урон: {Enemy.Damage}\n");
                Console.ReadKey();

                // Если здоровье врага меньше 0
                if (Enemy.Health <= 0)
                {
                    Console.WriteLine($"{Hero.Name} победил! Красава, чел");
                    break;
                }
                // Если здоровье героя меньше 0
                if (Hero.Health <= 0)
                {
                    Console.WriteLine($"{Enemy.Name} победил. Ну ты и лузер");
                    break;
                }
            }
        }
    }
}
