
wusing System;

class Program {
    static Random rand = new Random();

    // プレイヤー
    static int x = 0;
    static int y = 0;

    static int maxHp = 100;
    static int hp = 100;
    static int attack = 10;
    static int defense = 5;
    static int speed = 5;

    static int level = 1;
    static int exp = 0;

    static void Main() {
        Console.WriteLine("RPG開始");

        while (true) {
            Console.WriteLine($"\n位置: ({x},{y})  HP:{hp}/{maxHp}  Lv:{level}  EXP:{exp}");
            Console.Write("移動 (WASD): ");

            string input = Console.ReadLine().ToUpper();

            Move(input);

            int distance = Math.Abs(x) + Math.Abs(y);
            int monsterLevel = GetMonsterLevel(distance);

            if (Encounter()) {
                Console.WriteLine("\n=== エンカウント発生！ ===");
                Battle(monsterLevel);

                if (hp <= 0) {
                    Console.WriteLine("ゲームオーバー");
                    break;
                }
            }
        }
    }

    static void Move(string input) {
        switch (input) {
            case "W": y++; break;
            case "S": y--; break;
            case "A": x--; break;
            case "D": x++; break;
        }
    }

    static bool Encounter() {
        // 約10マスに1回くらい（10%）
        return rand.Next(1, 101) <= 10;
    }

    static int GetMonsterLevel(int distance) {
        if (distance <= 50) return rand.Next(1, 3);      // Lv1~2
        if (distance <= 100) return rand.Next(3, 6);     // Lv3~5
        if (distance <= 150) return rand.Next(6, 9);     // Lv6~8
        if (distance <= 200) return rand.Next(9, 13);    // Lv9~12
        return rand.Next(13, 17);                         // Lv13~16
    }

    static void Battle(int monsterLevel) {
        int monsterHp = 50 + monsterLevel * 10;
        int monsterAttack = 5 + monsterLevel * 2;
        int monsterDefense = monsterLevel;

        Console.WriteLine($"モンスター出現！ Lv{monsterLevel}");

        while (monsterHp > 0 && hp > 0) {
            // プレイヤー攻撃
            int damageToMonster = Math.Max(1, attack - monsterDefense);
            monsterHp -= damageToMonster;

            Console.WriteLine($"プレイヤー攻撃！ {damageToMonster}ダメージ");

            if (monsterHp <= 0) break;

            // モンスター攻撃
            int damageToPlayer = Math.Max(1, monsterAttack - defense);
            hp -= damageToPlayer;

            Console.WriteLine($"モンスター攻撃！ {damageToPlayer}ダメージ");
        }

        if (hp > 0) {
            Console.WriteLine("勝利！");

            int gainedExp = monsterLevel * 10;
            exp += gainedExp;

            Console.WriteLine($"{gainedExp} EXP獲得");

            CheckLevelUp();
        }
    }

    static void CheckLevelUp() {
        int needExp = level * 50;

        while (exp >= needExp) {
            exp -= needExp;
            level++;

            maxHp += 10;
            attack += 2;
            defense += 1;
            speed += 1;

            hp = maxHp;

            Console.WriteLine($"レベルアップ！ Lv{level}");

            needExp = level * 50;
        }
    }
}