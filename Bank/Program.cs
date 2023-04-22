using _6.Exception.Models;
using MyLibrary;
using System;

namespace _6.Exception
{
    internal class Program
    {

        public static void ShowListElements<T>(List<T> list)
        {
            Console.Clear();

            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }

            Thread.Sleep(5000);
        }

        static void Main(string[] args)
        {
            //  Fake cards
            List<Card> fakeCards = new List<Card>()
            {
                new Card("1234567984561234", "8856","123",new DateOnly(2024,11,26),25000),
                new Card("5649821236846554", "2134","586",new DateOnly(2028,4,5),50000),
                new Card("8451143215665158", "8312","892",new DateOnly(2026,9,18),100000),
            };

            //  List of cards Pans
            List<string> cardsPAN = new List<string>() { "1234567984561234", "5649821236846554", "8451143215665158" };

            //  Operations
            List<Operation> operations = new List<Operation>();

            //  Create client CAVID
            Client client = new Client
                (Guid.NewGuid(), "Cavid", "Atamoghlanov", 28, 3000,
                new Card("2356498846544845", "1234", "566", new DateOnly(2026, 9, 18), 150000)
                );

            do
            {
                try
                {
                    //  Enter password client
                    Console.Write("Please Cavid enter your card's password: ");
                    string password = Console.ReadLine();
                    //  If the entered pin is correct
                    if (password == client.card.PIN)
                    {
                        //  Main menu
                        List<string> optionsMainMenu = new List<string>() { "Show balance", "Cash", "Show operations", "Card to card", "Exit" };
                        do
                        {
                            byte optionMainMenu = MyMenu.createMenu("Please select option from Main Menu:", optionsMainMenu);
                            switch (optionMainMenu)
                            {
                                // Show balance
                                case 0:
                                    MyConsole.ShowDescriptionInGreen($"Balance: {Convert.ToString(client.card.Balance)}");
                                    break;

                                //  Menu cash
                                case 1:
                                    List<string> optionsCashMenu = new List<string>() { "Widraw from card", "Add amount to card", "Exit" };
                                    try
                                    {
                                        do
                                        {
                                            byte optionCashMenu = MyMenu.createMenu("Please select option from Cash Menu", optionsCashMenu);
                                            decimal amount;
                                            Operation operation;
                                            try
                                            {
                                                switch (optionCashMenu)
                                                {

                                                    //  Widraw from card
                                                    case 0:
                                                        amount = Convert.ToDecimal(MyConsole.GetInformationFromUser("Please enter amount that you want withdraw: "));
                                                        client.card.WithdrawFromBalance(amount);
                                                        operation = new Operation("Withdraw", amount, DateTime.Now);
                                                        operations.Add(operation);
                                                        break;

                                                    //  Add amount to card
                                                    case 1:
                                                        amount = Convert.ToDecimal(MyConsole.GetInformationFromUser("Please enter amount that you want add to card: "));
                                                        client.card.AddMoneyToBalance(amount);
                                                        operation = new Operation("Add", amount, DateTime.Now);
                                                        operations.Add(operation);
                                                        break;

                                                    //  Exit
                                                    case 2:
                                                        throw new MyException("You are back to the main menu");
                                                        break;

                                                }
                                            }
                                            catch (MyException ex)
                                            {
                                                MyConsole.ShowDescriptionInRed(ex.Message);
                                                break;
                                            }
                                            catch (System.Exception ex)
                                            {
                                                MyConsole.ShowDescriptionInRed(ex.Message);
                                            }
                                        } while (true);
                                    }
                                    catch (System.Exception ex)
                                    {
                                        MyConsole.ShowDescriptionInRed(ex.Message);
                                    }
                                    break;

                                //  Show operations
                                case 2:
                                    Program.ShowListElements<Operation>(operations);
                                    break;

                                //  Card to card
                                case 3:
                                    do
                                    {
                                        try
                                        {
                                            byte optionCardsPAN = MyMenu.createMenu("Please select card:", cardsPAN);
                                            decimal amount = Convert.ToDecimal(MyConsole.GetInformationFromUser("Please enter amount that you want send: "));
                                            if (amount < client.card.Balance)
                                            {
                                                client.card.Balance -= amount;
                                                break;
                                            }
                                            else
                                            {
                                                throw new System.Exception("You do not have enough money in your balance!");
                                            }

                                        }
                                        catch (System.Exception ex)
                                        {
                                            MyConsole.ShowDescriptionInRed(ex.Message);
                                        }
                                    } while (true);
                                    break;

                                //  Exit
                                case 4:
                                    throw new System.Exception("You have logged out");
                                    break;

                            }

                        } while (true);

                    }
                    else
                    {
                        throw new System.Exception("Password incorrect!");
                    }
                }
                catch (System.Exception ex)
                {
                    MyConsole.ShowDescriptionInRed(ex.Message);
                }
            } while (true);






        }
    }
}