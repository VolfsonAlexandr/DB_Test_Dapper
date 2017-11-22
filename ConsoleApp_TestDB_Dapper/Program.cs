using System;

namespace ConsoleApp_TestDB_Dapper
{

    class Program
    {
        static Action[] actionList = { ShowUserList, AddUser, WorkWithUser, FinishWorkMenu1 };
        static Action[] actionUserList = { ShowUserBounds, AddBound, UpdateUserInfo, DeleteUser, WorkWithBound, FinishWorkMenu2 };
        static Action[] actionBoundList = { ShowBoundFilters, AddFilter, DeleteFilter, DeleteBound, UpdateBoundInfo, FinishWorkMenu3 };
        static bool isContinueMenu1 = true;
        static bool isContinueMenu2 = true;
        static bool isContinueMenu3 = true;
        static Repository repository;
        static void Main(string[] args)
        {
            repository = new Repository();
            ShowMenu();
        }

        static void ShowMenu()
        {
            while (isContinueMenu1)
            {
                Console.Clear();
                Console.WriteLine("Для выбора пункта меню введите соответствующее число");
                string[] items = { "Посмотреть список пользователей", "Добавить пользователя", "Работать c конкретным пользователем", "Закончить работу" };
                for (int i = 0; i < items.Length; i++)
                    Console.WriteLine(items[i] + " - " + i);
                int selecteditem = int.Parse(Console.ReadLine());
                actionList[selecteditem]();
            }
        }

        static void ShowUserList()
        {
            Console.Clear();
            Console.WriteLine("Подождите...");
            var users = repository.GetAllUsers();
            foreach (var u in users)
                Console.WriteLine("Id: " + u.Id + " Login: " + u.Login + " Password: " + u.Password + " Name: " + u.Name + " Surname: " + u.Surname + " Birth: " + u.Birth);
            Console.ReadLine();
        }

        static void AddUser()
        {
            Console.Clear();
            UserData user = new UserData();
            Console.WriteLine("Введите поле Login");
            user.Login = Console.ReadLine();
            Console.WriteLine("Введите поле Password");
            user.Password = Console.ReadLine();
            Console.WriteLine("Введите поле Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите поле Surname");
            user.Surname = Console.ReadLine();
            Console.WriteLine("Введите поле Birth");
            user.Birth = Console.ReadLine();
            repository.AddUser(user);
        }

        static void WorkWithUser()
        {
            isContinueMenu2 = true;
            while (isContinueMenu2)
            {
                Console.Clear();
                Console.WriteLine("Для выбора пункта меню введите соответствующее число");
                string[] items = { "Посмотреть связки пользователя", "Добавить связку", "Редактировать личную информацию пользователя", "Удалить пользователя", "Работать с конкретной связкой пользователя", "Выйти в главное меню" };
                for (int i = 0; i < items.Length; i++)
                    Console.WriteLine(items[i] + " - " + i);
                int selecteditem = int.Parse(Console.ReadLine());
                actionUserList[selecteditem]();
            }
        }

        static void FinishWorkMenu1()
        {
            isContinueMenu1 = false;
        }

        static void FinishWorkMenu2()
        {
            isContinueMenu2 = false;
        }

        static void FinishWorkMenu3()
        {
            isContinueMenu3 = false;
        }

        static void ShowUserBounds()
        {
            Console.Clear();
            Console.WriteLine("Введите Id пользователя, с информацией которого хотите работать");
            int id = int.Parse(Console.ReadLine());
            var bounds = repository.GetAllBoundsOfUser(id);
            foreach(var b in bounds)
            {
                Console.WriteLine("Id: " + b.Id + " Instagram: " + b.Instgram + " Telegram: " + b.Telegram);
            }
            Console.ReadLine();
        }

        static void AddBound()
        {
            Console.Clear();
            Console.WriteLine("Введите Id пользователя, с информацией которого хотите работать");
            int id = int.Parse(Console.ReadLine());
            Bound bound = new Bound();
            bound.User_Id = id;
            Console.WriteLine("Введите поле Instagram");
            bound.Instgram = Console.ReadLine();
            Console.WriteLine("Введите поле Telegram");
            bound.Telegram = Console.ReadLine();
            repository.AddBound(bound);
        }
        static void UpdateUserInfo()
        {
            Console.Clear();
            Console.WriteLine("Введите Id пользователя, с информацией которого хотите работать");
            int id = int.Parse(Console.ReadLine());
            UserData user = new UserData();
            user.Id = id;
            Console.WriteLine("Введите поле Login");
            user.Login = Console.ReadLine();
            Console.WriteLine("Введите поле Password");
            user.Password = Console.ReadLine();
            Console.WriteLine("Введите поле Name");
            user.Name = Console.ReadLine();
            Console.WriteLine("Введите поле Surname");
            user.Surname = Console.ReadLine();
            Console.WriteLine("Введите поле Birth");
            user.Birth = Console.ReadLine();
            repository.UpdateUser(user);
        }

        static void DeleteUser()
        {
            Console.Clear();
            Console.WriteLine("Введите Id пользователя, которого хотите удалить");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Вы уверены? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                repository.DeleteUser(id);
            }
        }

        static void WorkWithBound()
        {
            isContinueMenu3 = true;
            while (isContinueMenu3)
            {
                Console.Clear();
                Console.WriteLine("Для выбора пункта меню введите соответствующее число");
                string[] items = { "Посмотреть фильтры связки", "Добавить фильтр", "Удалить фильтр", "Удалить связку", "Редактировать связку", "Выйти в предыдущее меню" };
                for (int i = 0; i < items.Length; i++)
                    Console.WriteLine(items[i] + " - " + i);
                int selecteditem = int.Parse(Console.ReadLine());
                actionBoundList[selecteditem]();
            }
        }
        static void ShowBoundFilters()
        {
            Console.Clear();
            Console.WriteLine("Введите Id связки, с которой хотите работать");
            int id = int.Parse(Console.ReadLine());
            var filters = repository.GetAllFiltersOfBound(id);
            foreach (var f in filters)
            {
                Console.WriteLine("Id: " + f.Id + " Filter: " + f.Filter);
            }
            Console.ReadLine();
        }

        static void AddFilter()
        {
            Console.Clear();
            Console.WriteLine("Введите Id связки, с которой хотите работать");
            BoundFilter filter = new BoundFilter();
            int bound_id = int.Parse(Console.ReadLine());
            filter.Bound_Id = bound_id;
            Console.WriteLine("Введите фильтр");
            filter.Filter = Console.ReadLine();
            repository.AddFilter(filter);
        }

        static void DeleteFilter()
        {
            Console.Clear();
            Console.WriteLine("Введите Id фильтра, который хотите удалить");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Вы уверены? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                repository.DeleteFilter(id);
            }
        }

        static void DeleteBound()
        {
            Console.Clear();
            Console.WriteLine("Введите Id связки, которую хотите удалить");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Вы уверены? (Y/N)");
            string answer = Console.ReadLine();
            if (answer == "Y")
            {
                repository.DeleteBound(id);
            }
        }

        static void UpdateBoundInfo()
        {
            Console.Clear();
            Console.WriteLine("Введите Id связки, с которой хотите работать");
            int id = int.Parse(Console.ReadLine());
            Bound bound = repository.GetBoundById(id);
            Console.WriteLine("Введите поле Instagram");
            bound.Instgram = Console.ReadLine();
            Console.WriteLine("Введите поле Telegram");
            bound.Telegram = Console.ReadLine();
            repository.UpdateBound(bound);
        }
    }
}
