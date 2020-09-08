using System;
using System.Collections.Generic;

namespace Task_30
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Players> players = new List<Players>();

            bool enterOrExit = true;

            while (enterOrExit)
            {
                Console.WriteLine("Выберите нужный пункт меню\n\n1- добавить игрока\n\n2- забанить игрока по порядковому номеру\n\n" +
                    "3 - разбанить игрока по порядковому номеру\n\n4- удалить игрока по порядковому номеру\n\n5 - выход\n\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        Players player = new Players(players.Count);
                        
                        players.Add(player);
                        break;
                    case 2:
                        BanOrUnbanPlayer(players, "забанен", true);
                        break;
                    case 3:
                         BanOrUnbanPlayer(players, "разбанен", false);
                        break;
                    case 4:
                        DeletePlayer(players);
                        break;
                    case 5:
                        enterOrExit = false;
                        break;                    
                }
                Console.WriteLine("Для продолжения нажмите любую клавишу...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void BanOrUnbanPlayer(List<Players> players, string text, bool isBan)
        {
            int playerId;
            Console.Write("Введите номер игрока : ");

            playerId = Convert.ToInt32(Console.ReadLine());

            if (playerId >= 0 && playerId <= players.Count - 1)
            {
                players[playerId].IsBan = isBan;
                Console.WriteLine($"Игрок под номером {playerId} " + text);
            }
            else
            {
                Console.WriteLine("Игрока с таким номером не существует");
            }
        }

        static void DeletePlayer(List<Players> players)
        {
            int playerId;

            Console.Write("Введите номер игрока : ");
            playerId = Convert.ToInt32(Console.ReadLine());

            if (playerId >= 0 && playerId <= players.Count)
            {
                players.RemoveAt(playerId);
                Console.WriteLine($"Игрок под номером {playerId} удален.");
            }
            else
            {
                Console.WriteLine("Игрока с таким номером не существует");
            }
        }
    }
    class Players
    {
        public int Id;
        public string Name;
        public int Level;
        public bool IsBan;
        
        public Players(int id)
        {
            Id = id + 1;
            IsBan = false;

            Console.Write("Введите имя игрока : ");
            Name = Console.ReadLine();

            Console.Write("Введите уровень игрока : ");
            Level = Convert.ToInt32(Console.ReadLine());
        }
    }
}
