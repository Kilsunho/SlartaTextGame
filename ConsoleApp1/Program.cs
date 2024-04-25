namespace Game
{
    internal class GameStart
    {
        static int thisscreen = 0;
        static void Main(string[] args)
        {
            bool gameStart = true;
            bool characterScreen = false;
            bool inventoryScreen = false;
            bool shopScreen = false;
            bool InventorymanagerScreen = false;
            bool buyitem = false;
            bool saleitem = false;
            int select = 0;
            thisscreen = 1;

            //if 세이브가 있다면 진행 없다면 직업선택 창 뜨게하기


            Character character = new Character();
            character.Lv = 1;
            character.job = "Jack";
            character.power = 10;
            character.defense = 5;
            character.hp = 100;
            character.gold = 1500;

            Item noviceArmor = new Item();
            noviceArmor.SetItem("수련자 갑옷     ", 2, 5f, "수련에 도움을 주는 갑옷입니다.                   ", 1000, 1);
            Item ironArmor = new Item();
            ironArmor.SetItem("무쇠갑옷        ", 2, 9f, "무쇠로 만들어져 튼튼한 갑옷입니다.               ", 1800, 2);
            Item spartanArmor = new Item();
            spartanArmor.SetItem("스파르타의 갑옷 ", 2, 15f, "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 3500, 3);
            Item wornSword = new Item();
            wornSword.SetItem("낡은 검         ", 1, 2f, "쉽게 볼 수 있는 낡은 검 입니다.                  ", 600, 4);
            Item bronzeAxe = new Item();
            bronzeAxe.SetItem("청동 도끼       ", 1, 5f, "어디선가 사용됐던거 같은 도끼입니다.             ", 1500, 5);
            Item spartanSpear = new Item();
            spartanSpear.SetItem("스파르타의 창   ", 1, 7f, "스파르타의 전사들이 사용했다는 전설의 창입니다.  ", 2700, 6);
            Item spartanshield = new Item();
            spartanshield.SetItem("스파르타의 방패 ", 3, 10f, "스파르타의 전사들이 사용했다는 전설의 방패입니다.", 100, 7);

            Item[] shopItems = new Item[] { noviceArmor, ironArmor, spartanArmor, wornSword, bronzeAxe, spartanSpear, spartanshield };

            List<Item> myItems = [];

            List<string> loadItemStr = new List<string>();

            do
            {
                thisscreen = 1;
                Console.Clear();
                Console.WriteLine("\n스파르타 마을에 오신 여러분 환영합니다.\n이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
                Console.WriteLine("\n1. 상태 보기\n2. 인벤토리\n3. 상점\n0. 게임 종료");
                Console.WriteLine("\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                select = ReadNum(3);
                switch (select)
                {
                    case 0:
                        Console.WriteLine("게임을 종료합니다.");
                        gameStart = false;
                        break;
                    case 1:
                        characterScreen = true;
                        do
                        {
                            CharacterScreen();
                        } while (characterScreen);
                        break;
                    case 2:
                        inventoryScreen = true;
                        do
                        {
                            InventoryScreen();
                        } while (inventoryScreen);
                        break;
                    case 3:
                        shopScreen = true;
                        do
                        {
                            ShopScreen();
                        } while (shopScreen);
                        break;

                }
            } while (gameStart);

            static void Error()
            {
                Console.WriteLine("잘못된 입력입니다.");
                Console.Write(">>");
            }
            static int ReadNum(int i)
            {
                int menuNum = i;
                int select = 0;
                bool selectchek;
                do
                {
                    string num = Console.ReadLine();
                    selectchek = int.TryParse(num, out select);
                    if (!selectchek)
                    {
                        Error();
                    }
                    if (select == 0)
                    {

                    }
                    else if (select > menuNum)
                    {
                        Error();
                    }
                } while (!selectchek || select > menuNum);
                return select;
            }// 사용자 입력값 받기


            void CharacterScreen() // 상태 씬
            {
                float itemPower = 0;
                float itemDefense = 0;

                thisscreen = 2;
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine("\nLv. " + character.Lv);
                Console.WriteLine("Chad (" + character.job + ")");



                foreach (Item item in myItems)                                  
                {
                    if (item.type == 1)
                    {
                        if (item.equip)
                        {
                            itemPower += item.value;
                        }
                    }
                }

                foreach (Item item in myItems)                     
                {
                    if (item.type == 2)
                    {
                        if (item.equip)
                        {
                            itemDefense += item.value;
                        }
                    }
                }
                foreach (Item item in myItems)                   
                {
                    if (item.type == 3)
                    {
                        if (item.equip)
                        {
                            itemDefense += item.value;
                        }
                    }
                }

                if (itemPower == 0)
                    Console.WriteLine($"공격력 : {character.power}");
                else
                    Console.WriteLine($"공격력 : {character.power} (+{itemPower})");

                if (itemDefense == 0)
                    Console.WriteLine($"공격력 : {character.defense}");
                else
                    Console.WriteLine($"공격력 : {character.defense} (+{itemDefense})");

                Console.WriteLine("체  력 : " + character.hp);
                Console.WriteLine("Gold : " + character.gold);
                Console.WriteLine("\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                select = ReadNum(0);
                switch (select)
                {
                    case 0:
                        characterScreen = false;
                        break;
                }
            }
            void InventoryScreen() // 인벤토리씬
            {
                thisscreen = 3;
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("[아이템 목록]");
                foreach (Item name in myItems)
                {
                    if (name.equip)
                    {
                        if (name.type == 1)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- [E]{name.name}| 공격력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- [E]{name.name}| 공격력 +{name.value}  | {name.information}");
                            }

                        }

                        else if (name.type == 2)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- [E]{name.name}| 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- [E]{name.name}| 방어력 +{name.value}  | {name.information}");
                            }
                        }
                        else if (name.type == 3)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- [E]{name.name}| 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- [E]{name.name}| 방어력 +{name.value}  | {name.information}");
                            }
                        }
                    }
                    else
                    {
                        if (name.type == 1)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {name.name}   | 공격력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {name.name}   | 공격력 +{name.value}  | {name.information}");
                            }
                        }

                        else if (name.type == 2)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {name.name}   | 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {name.name}   | 방어력 +{name.value}  | {name.information}");
                            }
                        }
                        else if (name.type == 3)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {name.name}   | 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {name.name}   | 방어력 +{name.value}  | {name.information}");
                            }
                        }
                    }
                }
                Console.WriteLine("\n1. 장착 관리\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                int select = ReadNum(1);
                switch (select)
                {
                    case 0:
                        inventoryScreen = false;
                        break;
                    case 1:
                        InventorymanagerScreen = true;
                        do
                        {
                            InventoryManagerScreen();
                        } while (InventorymanagerScreen);
                        break;

                }
            }
            void InventoryManagerScreen() // 장착관리 씬
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n\n[아이템 목록]\n");
                int i = 0;
                foreach (Item name in myItems)
                {
                    i++;
                    if (name.equip)
                    {
                        if (name.type == 1)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 공격력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 공격력 +{name.value}  | {name.information}");
                            }
                        }

                        else if (name.type == 2)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value}  | {name.information}");
                            }
                        }

                        else if (name.type == 3)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value}  | {name.information}");
                            }
                        }
                    }
                    else
                    {
                        if (name.type == 1)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} {name.name}   | 공격력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} {name.name}   | 공격력 +{name.value}  | {name.information}");
                            }
                        }

                        else if (name.type == 2)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value}  | {name.information}");
                            }
                        }
                        else if (name.type == 3)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value} | {name.information}");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value}  | {name.information}");
                            }
                        }
                    }
                }
                Console.WriteLine("\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int equipAction = ReadNum(myItems.Count);

                if (equipAction == 0)
                {
                    InventorymanagerScreen = false;
                }
                else if (myItems[equipAction - 1].equip)
                {
                    if (myItems[equipAction - 1].type == 1)
                    {
                        character.power -= myItems[equipAction - 1].value;
                    }
                    else
                    {
                        character.adddefense -= myItems[equipAction - 1].value;
                    }
                    myItems[equipAction - 1].equip = false;
                }
                else
                {
                    foreach (Item item in myItems)
                    {
                        if (item.equip)
                        {
                            if (item.type == myItems[equipAction - 1].type)
                            {
                                if (myItems[equipAction - 1].type == 1)
                                {
                                    character.addpower -= myItems[equipAction - 1].value;
                                }
                                else
                                {
                                    character.adddefense -= myItems[equipAction - 1].value;
                                }
                                item.equip = false;
                            }
                        }
                    }
                    myItems[equipAction - 1].equip = true;

                    if (myItems[equipAction - 1].type == 1)
                    {
                        character.addpower += myItems[equipAction - 1].value;
                    }
                    else
                    {
                        character.adddefense += myItems[equipAction - 1].value;
                    }


                }
            }

            void ShopScreen() //상점씬
            {
                thisscreen = 3;
                Console.Clear();
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 잇는 상점입니다.\n\n[보유 골드]");
                Console.WriteLine($"{character.gold} G\n");
                Console.WriteLine("[아이템 목록]");
                for (int i = 0; i < shopItems.Length; i++)
                {
                    if (!shopItems[i].get)
                    {
                        if (shopItems[i].type == 1)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 공격력 +{shopItems[i].value} | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 공격력 +{shopItems[i].value}  | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                        }

                        else if (shopItems[i].type == 2)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                        }
                        else if (shopItems[i].type == 3)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                        }
                    }
                    else
                    {
                        if (shopItems[i].type == 1)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 공격력 +{shopItems[i].value} | {shopItems[i].information}| 구매완료");
                            }
                            else
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 공격력 +{shopItems[i].value}  | {shopItems[i].information}| 구매완료");
                            }
                        }

                        else if (shopItems[i].type == 2)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| 구매완료");
                            }
                            else
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| 구매완료");
                            }
                        }
                        else if (shopItems[i].type == 3)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| 구매완료");
                            }
                            else
                            {
                                Console.WriteLine($"- {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| 구매완료");
                            }
                        }
                    }
                }
                Console.WriteLine("\n1. 아이템 구매\n2. 아이템 판매\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int shopAction = ReadNum(2);

                switch (shopAction)
                {
                    case 0:
                        shopScreen = false;
                        break;
                    case 1:
                        buyitem = true;

                        do
                        {
                            BuyItem();
                        }
                        while (buyitem);

                        break;
                    case 2:
                        saleitem = true;
                        do
                        {
                            SeleItem();
                        }
                        while (saleitem);
                        break;
                }
            }

            void BuyItem() //구매씬
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 구매\n필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]");
                Console.WriteLine($"{character.gold} G");
                Console.WriteLine("\n[아이템 목록]");

                for (int i = 0; i < shopItems.Length; i++)
                {
                    if (!shopItems[i].get)
                    {
                        if (shopItems[i].type == 1)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 공격력 +{shopItems[i].value} | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 공격력 +{shopItems[i].value}  | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                        }

                        else if (shopItems[i].type == 2)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                        }
                        else if (shopItems[i].type == 3)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| {shopItems[i].gold} G");
                            }
                        }
                    }
                    else
                    {
                        if (shopItems[i].type == 1)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 공격력 +{shopItems[i].value} | {shopItems[i].information}| 구매완료");
                            }
                            else
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 공격력 +{shopItems[i].value}  | {shopItems[i].information}| 구매완료");
                            }
                        }

                        else if (shopItems[i].type == 2)
                        {
                            if (shopItems[i].value > 9)
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 방어력 +{shopItems[i].value} | {shopItems[i].information}| 구매완료");
                            }
                            else
                            {
                                Console.WriteLine($"- {i + 1} {shopItems[i].name}| 방어력 +{shopItems[i].value}  | {shopItems[i].information}| 구매완료");
                            }
                        }
                    }
                }
                Console.WriteLine("\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int buyAction = ReadNum(shopItems.Length);

                if (buyAction == 0)
                {
                    buyitem = false;
                }
                else if (shopItems[buyAction - 1].get)
                {
                    Console.WriteLine("이미 구매한 아이템입니다.");
                }
                else
                {
                    if (character.gold >= shopItems[buyAction - 1].gold)
                    {
                        Console.WriteLine("구매를 완료했습니다.\n(앤터를 눌러주세요)");
                        character.gold -= shopItems[buyAction - 1].gold;
                        shopItems[buyAction - 1].get = true;
                        myItems.Add(shopItems[buyAction - 1]);
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Gold 가 부족합니다.\n(앤터를 눌러주세요)");
                        Console.ReadLine();
                    }
                }

            }
            void SeleItem() //판매씬
            {
                Console.Clear();
                Console.WriteLine("상점 - 아이템 판매");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.\n\n[보유 골드]\n");
                Console.WriteLine($"{character.gold} G\n\n[아이템 목록]");
                int i = 0;
                foreach (Item name in myItems)
                {
                    i++;
                    if (name.equip)
                    {
                        if (name.type == 1)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 공격력 +{name.value} | {name.information}|  {name.gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 공격력 +{name.value}  | {name.information}|  {name.gold} G");
                            }
                        }

                        else if (name.type == 2)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value} | {name.information}|  {name.gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value}  | {name.information}|  {name.gold} G");
                            }
                        }
                        else if (name.type == 3)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value} | {name.information}|  {name.gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} [E]{name.name}| 방어력 +{name.value}  | {name.information}|  {name.gold} G");
                            }
                        }
                    }
                    else
                    {
                        if (name.type == 1)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} {name.name}   | 공격력 +{name.value} | {name.information}|  {name.gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} {name.name}   | 공격력 +{name.value}  | {name.information}|  {name.gold} G");
                            }
                        }

                        else if (name.type == 2)
                        {

                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value} | {name.information}|  {name.gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value}  | {name.information}|  {name.gold} G");
                            }
                        }
                        else if (name.type == 3)
                        {
                            if (name.value > 9)
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value} | {name.information}|  {name.gold} G");
                            }
                            else
                            {
                                Console.WriteLine($"- {i} {name.name}   | 방어력 +{name.value}  | {name.information}|  {name.gold} G");
                            }
                        }
                    }
                }
                Console.WriteLine("\n0. 나가기\n\n원하시는 행동을 입력해주세요.");
                Console.Write(">>");

                int saleAction = ReadNum(myItems.Count);

                if (saleAction == 0)
                {
                    saleitem = false;
                }
                else
                {
                    int sellConfirm = 0;
                    Console.WriteLine($"정말 {myItems[saleAction - 1].name}을(를) 판매하시겠습니까?\n1. 예\n0. 아니오");
                    Console.Write(">>");
                    sellConfirm = ReadNum(1);
                    if (sellConfirm == 1)
                    {
                        character.gold += (myItems[saleAction - 1].gold * 85 / 100);
                        myItems[saleAction - 1].equip = false;
                        myItems[saleAction - 1].get = false;
                        myItems.RemoveAt(saleAction - 1);
                    }

                }

            }
        }//main 함수
    }// GameStart class
    public class Character()
    {
        public int Lv = 0;
        public string job = "";
        public float power = 0;
        public float addpower = 0;
        public float defense = 0;
        public float adddefense = 0;
        public int hp = 0;
        public int gold = 0;
    }// Character class
    public class Item
    {
        public string name = "";
        public int type = 0; // 1 = 무기, 2 = 방어구, 3 = 방패
        public float value = 0; 
        public string information = "";
        public int gold = 0;
        public bool get = false; // 소지여부
        public bool equip = false; // 장착여부
        public int number = 0; //아이템 코드

        public void SetItem(string Name, int Type, float Value, string Information, int Price, int num)
        {
            name = Name;
            type = Type;
            value = Value;
            information = Information;
            gold = Price;
            number = num;
        }
    }// Item class

}
