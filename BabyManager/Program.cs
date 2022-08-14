using System;

namespace BabyManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Dodawanie wpisu
            ////1.1 Jedna z trzech kategorii: rejestracja karmień, snu i przewijań
            ////1.2 Data zdarzenia
            //2. Usuwanie wpisu
            //// 2.1 Podawanie przez użytkownika id wpisu, który ma być usunięty
            //// 2.2 Usunięcie danego wpisu z listy
            //3. Wyświetlanie wpisów
            //// 3.1 Użytkownik wybiera opcję, czy chce wyświetlać wszystkie zdarzenia z danego dnia czy z danej kategorii
            //// 3.2 Wyświetlanie listy wpisów

            MenuActionService actionService = new MenuActionService();
            RecordService recordService = new RecordService();
            actionService = Initialize(actionService);
            bool shouldContinue = true;

            Console.WriteLine("Welcome to your baby's growth app ;)");
            while (shouldContinue)
            {
                Console.WriteLine("Type a proper number to execute one of below actions:");

                var mainMenu = actionService.GetMenuActionsByMenuName("Main");

                for (int i = 0; i < mainMenu.Count; i++)
                {
                    Console.WriteLine($"{mainMenu[i].Id}. {mainMenu[i].Name}");
                }

                var operation = Console.ReadKey();
                
                switch (operation.KeyChar)
                {
                    case '1':
                        var keyInfo = recordService.AddNewRecordView(actionService);
                        var id = recordService.AddNewRecord(keyInfo.KeyChar);
                        break;
                    case '2':
                        var removeId = recordService.RemoveRecordView();
                        recordService.RemoveRecord(removeId);
                        break;
                    case '3':
                        var typeId = recordService.RecordTypeSelectionView();
                        recordService.RecordsByTypeIdView(typeId);
                        break;
                    case '4':
                        string dateSelected = recordService.RecordDateSelectionView();
                        recordService.RecordsByDateView(dateSelected);
                        break;
                    case '5':
                        shouldContinue = false;
                        break;
                    default:
                        Console.WriteLine("Action you entered does not exist");
                        break;
                }
            }
            
        }
        
        private static MenuActionService Initialize(MenuActionService actionService)
        {
            actionService.AddNewAction(1, "Add record", "Main");
            actionService.AddNewAction(2, "Remove record", "Main");
            actionService.AddNewAction(3, "Show records with specific type", "Main");
            actionService.AddNewAction(4, "Show records from specific date", "Main");
            actionService.AddNewAction(5, "Exit", "Main");

            actionService.AddNewAction(1, "Feeding", "AddNewRecordMenu");
            actionService.AddNewAction(2, "Sleeping", "AddNewRecordMenu");
            actionService.AddNewAction(3, "Changing", "AddNewRecordMenu");

            return actionService;
        }
    }
}
