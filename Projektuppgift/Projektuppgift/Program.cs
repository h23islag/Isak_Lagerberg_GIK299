namespace Projektuppgift
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            MenuManager menu = new MenuManager();

            User user = menu.LoginMenu();
            if (user != null)
            {
                menu.DiaryMenu(user);
            }
        }

    }
}