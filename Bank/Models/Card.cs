using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Exception.Models
{
    //  Fields with Full Property
    internal partial class Card
    {
        //  16-digit code
        private string _PAN;
        public string PAN
        {
            get { return _PAN; }
            set
            {
                //  Check only numbers in PAN
                if (MyString.CheckOnlyNumberInstring(value))
                {
                    //  Length should equal to 16
                    if (value.Length == 16)
                    {
                        _PAN = value;
                    }

                    //  if the condition is not met
                    else
                    {
                        throw new System.Exception("Length of PAN should equal to 16");
                    }
                }

                //  if the condition is not met
                else
                {
                    throw new System.Exception("PAN should contain only numbers!");
                }
            }
        }

        //  4-digits code for entry
        private string _PIN;
        public string PIN
        {
            get { return _PIN; }
            set
            {
                //  Check only numbers in PIN
                if (MyString.CheckOnlyNumberInstring(value))
                {
                    //  Length should equal to 4
                    if (value.Length == 4)
                    {
                        _PIN = value;
                    }

                    //  if the condition is not met
                    else
                    {
                        throw new System.Exception("Length of PIN should equal to 16");
                    }
                }

                //  if the condition is not met
                else
                {
                    throw new System.Exception("PIN should contain only numbers!");
                }
            }
        }

        //  3-digits code for autofication
        private string _CVC;
        public string CVC
        {
            get { return _CVC; }
            set
            {
                //  Check only numbers in CVC
                if (MyString.CheckOnlyNumberInstring(value))
                {
                    //  Length should equal to 4
                    if (value.Length == 3)
                    {
                        _CVC = value;
                    }

                    //  if the condition is not met
                    else
                    {
                        throw new System.Exception("Length of CVC should equal to 16");
                    }
                }

                //  if the condition is not met
                else
                {
                    throw new System.Exception("CVC should contain only numbers!");
                }
            }
        }

        //  Expire Date
        private DateOnly _ExpireDate;
        public DateOnly ExpireDate
        {
            get { return _ExpireDate; }
            set
            {
                //  Check the entered year with the year of the current date
                if (value.Year >= DateTime.Now.Year)
                {
                    //  If the entered year is equal to the year of the current date
                    if (value.Year == DateTime.Now.Year)
                    {
                        //  Check the entered month with the year of the current month
                        if (value.Month >= DateTime.Now.Month)
                        {
                            //  If the entered month is equal to the month of the current date
                            if (value.Month == DateTime.Now.Month)
                            {
                                //  Check the entered day with the year of the current day
                                if (value.Day > DateTime.Now.Day)
                                {
                                    _ExpireDate = value;
                                }

                                //  If the condition is not met
                                else
                                {
                                    throw new System.Exception("The entered day cannot be smaller than the day of the current date");
                                }
                            }
                            else
                            {
                                _ExpireDate = value;
                            }

                        }
                        //  If the condition is not met
                        else
                        {
                            throw new System.Exception("The entered month cannot be smaller than the month of the current date");
                        }
                    }
                    else
                    {
                        _ExpireDate = value;
                    }
                }

                //  If the condition is not met
                else
                {
                    throw new System.Exception("The entered year cannot be smaller than the year of the current date");
                }
            }
        }

        //  Balance of card
        private decimal _Balance;

        public decimal Balance
        {
            get { return _Balance; }
            set
            {
                //  The entered balance should be more than 0
                if (value > 0)
                {
                    _Balance = value;
                }

                //  If the contidion is not met
                else
                {
                    throw new System.Exception("Balance should be positive number!");
                }
            }
        }


    }

    //  Methods
    internal partial class Card
    {
        //  Constructor with parametres
        public Card(string pAN, string pIN, string cVC, DateOnly expireDate, decimal balance)
        {
            PAN = pAN;
            PIN = pIN;
            CVC = cVC;
            ExpireDate = expireDate;
            Balance = balance;
        }

        //  Withdraw
        public void WithdrawFromBalance(decimal withdraw)
        {
            //  If withdraw less than balance
            if (withdraw <= _Balance)
            {
                _Balance -= withdraw;
            }

            //  If the condition isnot met
            else
            {
                throw new System.Exception("Withdraw never been more than balance!");
            }
        }

        //  Add money to balance
        public void AddMoneyToBalance(decimal amount)
        {
            _Balance += amount;
        }

        //  For show in console
        public override string ToString()
        {
            return $"PAN: {_PAN}\nPIN: {_PIN}\nCVC: {_CVC}\nExpire Date: {_ExpireDate.ToString()}\nBalance: {_Balance}\n";
        }

    }
}
