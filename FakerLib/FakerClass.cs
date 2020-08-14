using FakerLib.Properties;
using System;
using System.Collections.Generic;

namespace FakerLib
{
    public class Name
    {        
        string[] maleNames;
        string[] femaleNames;
        string[] maleSurnames;
        string[] femaleSurnames;
        string[] malePatronymic;
        string[] femalePatronymic;
        bool en = false;
        Random r = new Random((int)(DateTime.Now.Ticks % 100000000000));
        public Name(string region)
        {
            if (region == "be_BY")
            {
                maleNames = Resources.BY_Male_Names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femaleNames = Resources.BY_Female_Names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                maleSurnames = Resources.BY_Male_Surnames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femaleSurnames = Resources.BY_Female_Surnames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                malePatronymic = Resources.BY_Male_Patr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femalePatronymic = Resources.BY_Female_Patr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (region == "ru_RU")
            {
                maleNames = Resources.RUS_Male_Names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femaleNames = Resources.RUS_Female_Names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                maleSurnames = Resources.RUS_Male_Surnames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femaleSurnames = Resources.RUS_Female_Surnames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                malePatronymic = Resources.RUS_Male_Patr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femalePatronymic = Resources.RUS_Female_Patr.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (region == "en_EN")
            {
                maleNames = Resources.EN_Male_Names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                femaleNames = Resources.EN_Female_Names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                maleSurnames = Resources.EN_Surnames.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                en = true;
            }
            else
            {
                Console.Error.WriteLine("ERROR:    Choosen region is invalid");
            }
        }

        enum Sex
        {
            Male,
            Female
        }     
        public string FullNameGen()
        {
            Sex sex = (Sex)r.Next(2);
            string FirstName, Surname, Patronymic;
            if (en)
            {                
                FirstName = sex == Sex.Male ? maleNames[r.Next(0, maleNames.Length)] : femaleNames[r.Next(0, femaleNames.Length)];
                Surname = maleSurnames[r.Next(0, maleSurnames.Length)];
                Patronymic = "";
            }
            else
            {
                FirstName = sex == Sex.Male ? maleNames[r.Next(0, maleNames.Length)] : femaleNames[r.Next(0, femaleNames.Length)] ;
                Surname =  sex == Sex.Male ? maleSurnames[r.Next(0, maleSurnames.Length)] : femaleSurnames[r.Next(0, femaleSurnames.Length)];
                Patronymic =  sex == Sex.Male ? malePatronymic[r.Next(0, malePatronymic.Length)] : femalePatronymic[r.Next(0, femalePatronymic.Length)];
            }

            return Surname + " " + FirstName + " " + Patronymic;
        }
    }
    public class Adress
    {
        string[] city;
        string[] street;
        string aparts;
        int house;
        int index;
        Random r = new Random((int)(DateTime.Now.Ticks % 100000000000));
        public Adress(string region)
        {
            if (region == "be_BY")
            {
                house = r.Next(1, 1000); 
                city = Resources.BY_City.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                street = Resources.BY_Street.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (region == "ru_RU")
            {
                house = r.Next(1, 1000);
                aparts = "кв. " + r.Next(1, 1000);
                city = Resources.RUS_City.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                street = Resources.RUS_Street.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
            else if (region == "en_EN")
            {
                house = r.Next(1, 1000);
                aparts = r.Next(1, 1000).ToString();
                city = Resources.EN_City.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                street = Resources.EN_Street.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            }
        }
        public string AdressGen()
        {            
            index = r.Next(100000, 999999);
            return index + ", " + city[r.Next(0, city.Length)] + ", "
                + street[r.Next(0, street.Length)] + " " + house + " " + aparts;
        }

    }
    public class Phone
    {
        Random r = new Random((int)(DateTime.Now.Ticks % 100000000000));
        string CountryCode;
        string[] OperatorCode;
        string number;

        public Phone(string region)
        {
            if (region == "be_BY")
            {
                CountryCode = "375";
                OperatorCode = new string[] {" (25) ", " (29) ", " (44) "};
            }
            else if (region == "ru_RU")
            {
                CountryCode = "7";
                OperatorCode = new string[] { " (901) ", " (902) ", " (912) ", " (930) ", " (939) ",
                    " (955) ", " (958) ", " (970) ", " (971) ", " (991) ", " (992) ", " (993) " };                
            }
            else if (region == "en_EN")
            {
                CountryCode = "44";
                OperatorCode = new string[] { " (7773) ", " (7779) ", " (7800) ", " (7790) ", " (7976) ", " (7974) " };
            }
        }

        public string PhoneGen()
        {
            number = r.Next(100, 999) + "-" + r.Next(10, 99) + "-" + r.Next(10, 99);
            return CountryCode + OperatorCode[r.Next(0, OperatorCode.Length)] + number;
        }
    }
    public class Person
    {
        Random r = new Random((int)(DateTime.Now.Ticks % 100000000000));
        List<string> person = new List<string>();

        static int count;
        double peace_errCount, errCount;
        static string region;
        char first = (char)0x0410, last = (char)0x44F;
        public Person(string reg, int _count, double _errCount, double _peace_errCount)
        {
            region = reg;
            count = _count;
            errCount = _errCount;
            peace_errCount = _peace_errCount;
            if(reg == "en_EN")
            {
                first = (char)0x0041;
                last = (char)0x007A;
            }
        }

        string[] arr = new string[count];

        public string errGen(int errType, string str, int errcunt)
        {
            char[] tmpStr = str.ToCharArray();
            for (int i = 0; i < errcunt; i++)
            {
                char letter = (char)r.Next(first, last);
                switch (errType)
                {
                    case 0:
                    {
                        while (true)
                        {
                            int rnd = r.Next(0, str.Length - 1);
                            if (str[rnd] != ' ' && str[rnd] != ';')
                            {
                                tmpStr[rnd] = letter;
                                str = new string(tmpStr);
                                break;
                            }
                        }
                        break;
                    }
                    case 1:
                    {
                        while (true)
                        {
                            int rnd = r.Next(0, str.Length - 1);
                            if (str[rnd] != ' ' && str[rnd] != ';')
                            {
                                tmpStr[rnd] = str[rnd + 1];
                                tmpStr[rnd + 1] = str[rnd];
                                str = new string(tmpStr);
                                break;
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        while (true)
                        {
                            int rnd = r.Next(0, str.Length - 1);
                            if (str[rnd] != ' ' && str[rnd] != ';')
                            {
                                str.Substring(rnd, 1);
                                break;
                            }
                        }
                        break;
                    }
                }
            }
            return str;
        }
        public void PersonGen()
        {
            Name name = new Name(region);
            Adress adress = new Adress(region);
            Phone phone = new Phone(region);

            int err = (int)Math.Floor(errCount);
            if (errCount >= 1)
            {
                string personTmp;
                if (peace_errCount > 0)
                {
                    for (int i = 1; i < count + 1; i++)
                    {
                        personTmp = name.FullNameGen() + "; " + adress.AdressGen() + "; " + phone.PhoneGen();
                        person.Add(errGen(r.Next(0, 2), personTmp, err));
                        if (i % 1/peace_errCount == 0)
                        {
                            person.Add(errGen(r.Next(0, 2), personTmp, 1));
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < count + 1; i++)
                    {
                        personTmp = name.FullNameGen() + "; " + adress.AdressGen() + "; " + phone.PhoneGen();
                        person.Add(errGen(r.Next(0, 2), personTmp, err));
                    }
                }
            }
            else
            {
                for (int i = 1; i < count; i++)
                {
                    string personTmp;
                    personTmp = name.FullNameGen() + "; " + adress.AdressGen() + "; " + phone.PhoneGen();
                    if (i % errCount == 0)
                    {
                        person.Add(errGen(r.Next(0, 2), personTmp, 1));
                    }
                    else
                    {
                        person.Add(personTmp);
                    }
                }
            }
        }
        public void PersonOutput()
        {
            for (int i = 0; i < person.Count; i++)
            {
                Console.Error.WriteLine(person[i]);
            }
        }
    }
}
