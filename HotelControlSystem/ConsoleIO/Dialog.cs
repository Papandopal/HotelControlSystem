using System.Text;
using DoMain.Enums;
using HotelControlSystem.ConsoleIO.Behavior;
using HotelControlSystem.DTO;
using HotelControlSystem.Exceptions;

namespace HotelControlSystem.ConsoleIO
{
    internal class Dialog(UserMainInfoDTO userMainInfo, GeneralBehavior generalBehavior, CustomerBehavior customerBehavior)
    {
        private UserMainInfoDTO userMainInfo = userMainInfo;
        private List<Action> generalActions = generalBehavior.Actions;
        private List<Action>? roleActions;
        private uint curAction = 0;
        private int prevCursorPositionLine = 0;
        private bool exit = false;
        public void Start()
        {
            while (!exit)
            {
                try
                {
                    prevCursorPositionLine = Console.CursorTop;
                    Console.WriteLine(GetInfo());
                    SetRoleActions(userMainInfo.Role);
                    Console.WriteLine(GetMenu());
                    ChoiseAction();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e);
                }
            }
        }

        public string GetInfo()
        {
            if (userMainInfo.Role != UserRole.Unauthorised)
                return new string(' ', Symbols.SelectedItem.Length) + userMainInfo.ToString();
            else return "Unauthorised";
        }

        private void SetRoleActions(UserRole role)
        {
            switch (role)
            {
                case UserRole.Admin:

                    break;
                case UserRole.HotelManager:

                    break;
                case UserRole.Customer:
                    roleActions = customerBehavior.Actions;
                    break;
                case UserRole.Unauthorised:
                    roleActions = null;
                    break;
                default:
                    throw new UnknowRoleException($"actions for {role.ToString()} not found");
            }
        }

        private string GetMenu()
        {
            List<Action> actions = new(generalActions);
            if (roleActions is not null) actions.AddRange(roleActions);

            StringBuilder sb = new StringBuilder();
            int offsetForSelectSymbol = Symbols.SelectedItem.Length;

            for (int i = 0; i < actions.Count; i++)
            {
                if (i == curAction) sb.Append(Symbols.SelectedItem + generalActions[i].Method.Name+'\n');
                else sb.Append(new string(' ', offsetForSelectSymbol) + generalActions[i].Method.Name+'\n');
            }
            return sb.ToString();
        }

        private void ChoiseAction()
        {
            ConsoleKeyInfo input = Console.ReadKey(intercept: true);

            Action choise = input switch
            {
                ConsoleKeyInfo key when key.Key == Symbols.RunAction => RunAction,
                ConsoleKeyInfo key when key.Key == Symbols.NextAction => NextAction,
                ConsoleKeyInfo key when key.Key == Symbols.PrevAction => PrevAction,
                ConsoleKeyInfo key when key.Key == Symbols.Exit => Exit,
                _ => ChoiseAction
            };
            choise.Invoke();
        }
        
        private void RunAction()
        {
            if (curAction < generalActions.Count) generalActions[(int)curAction].Invoke();
            else if (roleActions is not null && curAction - generalActions.Count < roleActions.Count)
            {
                roleActions[(int)curAction - generalActions.Count].Invoke();
            }
        }

        private void NextAction()
        {
            for(int i = prevCursorPositionLine; i < Console.CursorTop; i++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = i;
                Console.Write(new string(' ', 100));
            }
            Console.CursorLeft = 0;
            Console.CursorTop = prevCursorPositionLine;
            if (curAction + 1 >= generalActions.Count + (roleActions is not null ? roleActions.Count : 0)) return;
            curAction++;
            
        }

        private void PrevAction()
        {
            for (int i = prevCursorPositionLine; i < Console.CursorTop; i++)
            {
                Console.CursorLeft = 0;
                Console.CursorTop = i;
                Console.Write(new string(' ', 100));
            }
            Console.CursorLeft = 0;
            Console.CursorTop = prevCursorPositionLine;
            if (curAction <= 0) return;
            curAction--;
        }

        private void Exit()
        {
            exit = true;
        }
    }
}
