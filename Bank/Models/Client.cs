using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6.Exception.Models
{
    //  Fields
    internal partial class Client
    {
        //  ID
        public Guid ID { get; set; }

        //  Name
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                //  Check only letters in the entered name
                if (MyString.CheckOnlyLettersInString(value))
                {
                    //  Length of Name should be MIN 3
                    if (value.Length >= 3)
                    {
                        _name = value;
                    }

                    //  if the condition is not met
                    else
                    {
                        throw new System.Exception("Length of Name should be MIN 3!");
                    }
                }

                //  if the condition is not met
                else
                {
                    throw new System.Exception("Name should contain only letters!");
                }
            }
        }

        //  Surname
        private string _surname;
        public string Surname
        {
            get { return _surname; }
            set
            {
                //  Check only letters in the entered Surname
                if (MyString.CheckOnlyLettersInString(value))
                {
                    //  Length of Surname should be MIN 3
                    if (value.Length >= 3)
                    {
                        _surname = value;
                    }

                    //  if the condition is not met
                    else
                    {
                        throw new System.Exception("Length of Surname should be MIN 3!");
                    }
                }

                //  if the condition is not met
                else
                {
                    throw new System.Exception("Surname should contain only letters!");
                }
            }
        }


        //  Age
        private byte _age;
        public byte Age
        {
            get { return _age; }
            set
            {
                //  Age should be MIN 18
                if (value >= 18)
                {
                    _age = value;
                }

                //  If the condition is not met
                else
                {
                    throw new System.Exception("Age should be MIN 18!");
                }
            }
        }

        //  Salary
        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                //  Salary should be MIN 345
                if (value >= 345)
                {
                    _salary = value;
                }

                //  If the condition is not met
                else
                {
                    throw new System.Exception("Salary should be MIN 345 AZN!");
                }
            }
        }

        //  List of cards
        public Card card { get; set; }

    }

    //  Methods
    internal partial class Client
    {
        //  Constrcutor with parametres
        public Client(Guid iD, string name, string surname, byte age, double salary, Card card)
        {
            ID = iD;
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            this.card = card;
        }
        //  For show in console
        public override string ToString()
        {
            return $"ID: {ID.ToString()}\nName: {_name}\nSurname: {_surname}\nAge: {_age}\nSalary: {_salary}\n\nCard info:\n{card.ToString()}\n";
        }
    }
}
