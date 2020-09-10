using System;
using System.Collections.Generic;

namespace Task_30
{
    class Program
    {
        static void Main(string[] args)
        {
            DataBase dataBase = new DataBase();
            bool enterOrExit = true;

            while (enterOrExit)
            {
                Console.WriteLine("Выберите нужный пункт меню\n\n1- добавить игрока\n\n2- забанить игрока по порядковому номеру\n\n" +
                    "3 - разбанить игрока по порядковому номеру\n\n4- удалить игрока по порядковому номеру\n\n5 - выход\n\n");

                switch (Convert.ToInt32(Console.ReadLine()))
                {
                    case 1:
                        dataBase.AddPlayer();
                        break;
                    case 2:
                        dataBase.BanOrUnbanPlayer("забанен");
                        break;
                    case 3:
                        dataBase.BanOrUnbanPlayer("разбанен");
                        break;
                    case 4:
                        dataBase.DeletePlayer();
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
    }
    class Player
    {
        private string _name;
        private int _level;
        public bool IsBan;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {

            }
        }        
        public Player(string name, int level)
        {
            _name = name;
            _level = level;
            IsBan = false;
        }
    }

    class DataBase
    {
        
        private List<Player> players = new List<Player>();

        public void AddPlayer()
        {
            Console.Write("Введите имя игрока : ");
            string name = Console.ReadLine();
            Console.Write("Введите уровень игрока : ");
            int level = Convert.ToInt32(Console.ReadLine());
            Player player = new Player(name, level);
            players.Add(player);
        }
        public void DeletePlayer()
        {
            Console.Write("Введите имя игрока : ");
            string name = Console.ReadLine();

            bool isFound = false;

            for (int i = 0; i < players.Count; i++)
            {
                if(name == players[i].Name)
                {
                    players.RemoveAt(i);
                    Console.WriteLine($"Выудалили игрока с именем : {players[i].Name}");
                    isFound = true;
                }
            }
            if(isFound == false)
            {
                Console.WriteLine("Игрока с таким именем не существует");
            }
        }
        public void BanOrUnbanPlayer(string text)
        {  
            Console.Write("Введите имя игрока : ");
            string name = Console.ReadLine();

            bool isFound = false;

            for (int i = 0; i < players.Count; i++)
            {
                if (name == players[i].Name)
                {
                    players[i].IsBan = true;
                    Console.WriteLine($"Игрок под именем {players[i].Name}" + text);
                    isFound = true;
                }
            }
            if (isFound == false)
            {
                Console.WriteLine("Игрока с таким именем не существует");
            }
        }
    }
}
