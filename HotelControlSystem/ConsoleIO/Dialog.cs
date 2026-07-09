using System.Text;
using DoMain.Enums;
using HotelControlSystem.DTOs.AuthorisationDTOs;
using HotelControlSystem.Exceptions;
using HotelControlSystem.RoleBehavior;
using UseCase.DTOs;

namespace HotelControlSystem.ConsoleIO
{
    internal class Dialog(IUserSession userSession, GeneralBehavior generalBehavior, CustomerBehavior customerBehavior,
        AdminBehavior adminBehavior, ManagerBehavior managerBehavior)
    {
        private IUserSession userSession = userSession;
        private List<Action> generalActions = generalBehavior.Actions;
        private List<Action>? roleActions;
        private uint curAction = 0;
        private bool exit = false;
        public void Start()
        {
            while (!exit)
            {
                try
                {
                    int beforePrint = Console.CursorTop;

                    Output.WriteLine(GetInfo());

                    SetRoleActions(userSession.currentUser.Role);

                    Output.Write(GetMenu());

                    ChoiseAction();
                }
                catch (Exception e)
                {
#if DEBUG
                    Console.WriteLine(e);
#else
                    Console.WriteLine(e.Message);
#endif
                }
            }
        }
        public string GetInfo()
        {
            if (userSession.currentUser.Role != UserRole.Unauthorised)
                return new string(' ', Symbols.SelectedItem.Length) + userSession.ToString();
            else return "Unauthorised";
        }
        private void SetRoleActions(UserRole role)
        {
            switch (role)
            {
                case UserRole.Admin:
                    roleActions = adminBehavior.Actions;
                    break;
                case UserRole.HotelManager:
                    roleActions = managerBehavior.Actions;
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
            string actionName;

            for (int i = 0; i < actions.Count; i++)
            {
                //MethodNames must be called "***Action"
                actionName = actions[i].Method.Name.Remove(actions[i].Method.Name.Length - "Action".Length);

                if (i == curAction) sb.Append(Symbols.SelectedItem + actionName + '\n');
                else sb.Append(new string(' ', offsetForSelectSymbol) + actionName + '\n');
            }
            return sb.ToString();
        }
        private void ChoiseAction()
        {
            ConsoleKeyInfo input = Console.ReadKey(intercept: true);

            Action choise = input switch
            {
                ConsoleKeyInfo key when key.Key == SpecialKeys.RunAction => RunAction,
                ConsoleKeyInfo key when key.Key == SpecialKeys.NextAction => NextAction,
                ConsoleKeyInfo key when key.Key == SpecialKeys.PrevAction => PrevAction,
                ConsoleKeyInfo key when key.Key == SpecialKeys.Exit => Exit,
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
            curAction = 0;
        }
        private void NextAction()
        {
            Output.ConsoleClear();
            if (curAction + 1 >= (generalActions.Count + (roleActions?.Count ?? 0)))
            {
                curAction = 0;
                return;
            }
            curAction++;

        }
        private void PrevAction()
        {
            Output.ConsoleClear();
            if (curAction <= 0)
            {
                curAction = (uint)(generalActions.Count + (roleActions?.Count ?? 0)) - 1;
                return;
            }
            curAction--;
        }
        private void Exit()
        {
            exit = true;
        }
    }
}
