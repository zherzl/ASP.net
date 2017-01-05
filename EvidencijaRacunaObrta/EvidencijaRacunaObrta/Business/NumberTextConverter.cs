using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EvidencijaRacunaObrta.Business
{
    public static class NumberTextConverter
    {

        public static string NumberToText(double cost)
        {
            int flagNula = 0;
            string text2;
            string text3;
            string text1 = cost.ToString();
            int num1 = text1.IndexOf(",");
            if (num1 > -1)
            {
                text2 = text1.Substring(0, text1.IndexOf(","));
                text3 = text1.Substring(text1.IndexOf(",") + 1);
            }
            else
            {
                text2 = text1;
                text3 = "0";
            }
            int[] numArray1 = new int[4];
            int num2 = 0;
            string text4 = "";
            int num3 = int.Parse(text2);
            int num4 = int.Parse(text3);

            if (num4 < 10)
            {
                if (text3.Length == 1)
                    num4 *= 10;
                else
                    flagNula = 1;
            }
            while (num3 > 0)
            {
                numArray1[num2] = num3 % 1000;
                num3 /= 1000;
                num2++;
            }
            for (int num5 = num2 - 1; num5 >= 0; num5--)
            {
                text4 = text4 + NumberTextConverter.IspisKuna(numArray1[num5], num5);
            }
            if (!text3.Equals("0"))
            {
                if (flagNula == 0)
                    return (text4 + " i " + NumberTextConverter.IspisLipa(num4));
                else
                {
                    switch (num4)
                    {
                        case 0:
                            {
                                text3 = "";
                                break;
                            }
                        case 1:
                            {
                                text3 = "jedna lipa";
                                break;
                            }
                        case 2:
                            {
                                text3 = "dvije lipe";
                                break;
                            }
                        case 3:
                            {
                                text3 = "tri lipe";
                                break;
                            }
                        case 4:
                            {
                                text3 = "\u010detiri lipe";
                                break;
                            }
                        case 5:
                            {
                                text3 = "pet lipa";
                                break;
                            }
                        case 6:
                            {
                                text3 = "\u0161est lipa";
                                break;
                            }
                        case 7:
                            {
                                text3 = "sedam lipa";
                                break;
                            }
                        case 8:
                            {
                                text3 = "osam lipa";
                                break;
                            }
                        case 9:
                            {
                                text3 = "devet lipa";
                                break;
                            }
                    }

                    return (text4 + " i " + text3);
                }


            }
            return text4;
        }

        private static string IspisLipa(int broj)
        {
            string text1 = null;
            string text2 = null;
            switch ((broj % 10))
            {
                case 0:
                    {
                        text2 = "";
                        break;
                    }
                case 1:
                    {
                        text2 = "jedna lipa";
                        break;
                    }
                case 2:
                    {
                        text2 = "dvije lipe";
                        break;
                    }
                case 3:
                    {
                        text2 = "tri lipe";
                        break;
                    }
                case 4:
                    {
                        text2 = "\u010detiri lipe";
                        break;
                    }
                case 5:
                    {
                        text2 = "pet lipa";
                        break;
                    }
                case 6:
                    {
                        text2 = "\u0161est lipa";
                        break;
                    }
                case 7:
                    {
                        text2 = "sedam lipa";
                        break;
                    }
                case 8:
                    {
                        text2 = "osam lipa";
                        break;
                    }
                case 9:
                    {
                        text2 = "devet lipa";
                        break;
                    }
            }
            switch ((broj / 10))
            {
                case 0:
                    {
                        text1 = "";
                        break;
                    }
                case 1:
                    {
                        text1 = "deset";
                        break;
                    }
                case 2:
                    {
                        text1 = "dvadeset";
                        break;
                    }
                case 3:
                    {
                        text1 = "trideset";
                        break;
                    }
                case 4:
                    {
                        text1 = "\u010detrdeset";
                        break;
                    }
                case 5:
                    {
                        text1 = "pedeset";
                        break;
                    }
                case 6:
                    {
                        text1 = "\u0161ezdeset";
                        break;
                    }
                case 7:
                    {
                        text1 = "sedamdeset";
                        break;
                    }
                case 8:
                    {
                        text1 = "osamdeset";
                        break;
                    }
                case 9:
                    {
                        text1 = "devedeset";
                        break;
                    }
            }
            if ((broj / 10) == 1)
            {
                switch ((broj % 10))
                {
                    case 0:
                        {
                            return "deset lipa";
                        }
                    case 1:
                        {
                            return "jedanaest lipa";
                        }
                    case 2:
                        {
                            return "dvanaest lipa";
                        }
                    case 3:
                        {
                            return "trinaest lipa";
                        }
                    case 4:
                        {
                            return "\u010detrnaest lipa";
                        }
                    case 5:
                        {
                            return "petnaest lipa";
                        }
                    case 6:
                        {
                            return "\u0161estnaest lipa";
                        }
                    case 7:
                        {
                            return "sedamnaest lipa";
                        }
                    case 8:
                        {
                            return "osamnaest lipa";
                        }
                    case 9:
                        {
                            return "devetnaest lipa";
                        }
                }
                return "";
            }
            if ((broj % 10) == 0)
            {
                return (text1 + text2 + " lipa");
            }
            return (text1 + text2);
        }

        private static string IspisKuna(int broj, int pozicija)
        {
            string text1 = null;
            string text2 = null;
            string text3 = null;
            switch ((broj % 10))
            {
                case 0:
                    {
                        text3 = "";
                        break;
                    }
                case 1:
                    {
                        text3 = "jedan";
                        break;
                    }
                case 2:
                    {
                        text3 = "dva";
                        break;
                    }
                case 3:
                    {
                        text3 = "tri";
                        break;
                    }
                case 4:
                    {
                        text3 = "\u010detiri";
                        break;
                    }
                case 5:
                    {
                        text3 = "pet";
                        break;
                    }
                case 6:
                    {
                        text3 = "\u0161est";
                        break;
                    }
                case 7:
                    {
                        text3 = "sedam";
                        break;
                    }
                case 8:
                    {
                        text3 = "osam";
                        break;
                    }
                case 9:
                    {
                        text3 = "devet";
                        break;
                    }
            }
            switch (((broj % 100) / 10))
            {
                case 0:
                    {
                        text2 = "";
                        break;
                    }
                case 1:
                    {
                        text2 = "deset";
                        break;
                    }
                case 2:
                    {
                        text2 = "dvadeset";
                        break;
                    }
                case 3:
                    {
                        text2 = "trideset";
                        break;
                    }
                case 4:
                    {
                        text2 = "\u010detrdeset";
                        break;
                    }
                case 5:
                    {
                        text2 = "pedeset";
                        break;
                    }
                case 6:
                    {
                        text2 = "\u0161ezdeset";
                        break;
                    }
                case 7:
                    {
                        text2 = "sedamdeset";
                        break;
                    }
                case 8:
                    {
                        text2 = "osamdeset";
                        break;
                    }
                case 9:
                    {
                        text2 = "devedeset";
                        break;
                    }
            }
            switch ((broj / 100))
            {
                case 0:
                    {
                        text1 = "";
                        break;
                    }
                case 1:
                    {
                        text1 = "sto";
                        break;
                    }
                case 2:
                    {
                        text1 = "dvjesto";
                        break;
                    }
                case 3:
                    {
                        text1 = "tristo";
                        break;
                    }
                case 4:
                    {
                        text1 = "\u010detiristo";
                        break;
                    }
                case 5:
                    {
                        text1 = "petsto";
                        break;
                    }
                case 6:
                    {
                        text1 = "\u0161esto";
                        break;
                    }
                case 7:
                    {
                        text1 = "sedamsto";
                        break;
                    }
                case 8:
                    {
                        text1 = "osamsto";
                        break;
                    }
                case 9:
                    {
                        text1 = "devetsto";
                        break;
                    }
            }
            if (pozicija == 0)
            {
                if (((broj % 100) / 10) == 1)
                {
                    switch ((broj % 10))
                    {
                        case 0:
                            {
                                return (text1 + "deset kuna ");
                            }
                        case 1:
                            {
                                return (text1 + "jedanaest kuna ");
                            }
                        case 2:
                            {
                                return (text1 + "dvanaest kuna ");
                            }
                        case 3:
                            {
                                return (text1 + "trinaest kuna ");
                            }
                        case 4:
                            {
                                return (text1 + "\u010detrnaest kuna ");
                            }
                        case 5:
                            {
                                return (text1 + "petnaest kuna ");
                            }
                        case 6:
                            {
                                return (text1 + "\u0161estnaest kuna ");
                            }
                        case 7:
                            {
                                return (text1 + "sedamnaest kuna ");
                            }
                        case 8:
                            {
                                return (text1 + "osamnaest kuna ");
                            }
                        case 9:
                            {
                                return (text1 + "devetnaest kuna ");
                            }
                    }
                    return "";
                }
                if ((broj % 10) == 1)
                {
                    return (text1 + text2 + "jedna kuna ");
                }
                if ((broj % 10) == 2)
                {
                    return (text1 + text2 + "dvije kune ");
                }
                if (((broj % 10) == 3) || ((broj % 10) == 4))
                {
                    return (text1 + text2 + text3 + " kune ");
                }
                return (text1 + text2 + text3 + " kuna ");
            }
            if (pozicija == 1)
            {
                if (((broj % 100) / 10) == 1)
                {
                    switch ((broj % 10))
                    {
                        case 0:
                            {
                                return (text1 + "deset tisu\u0107a ");
                            }
                        case 1:
                            {
                                return (text1 + "jedanaest tisu\u0107a ");
                            }
                        case 2:
                            {
                                return (text1 + "dvanaest tisu\u0107a ");
                            }
                        case 3:
                            {
                                return (text1 + "trinaest tisu\u0107a ");
                            }
                        case 4:
                            {
                                return (text1 + "\u010detrnaest tisu\u0107a ");
                            }
                        case 5:
                            {
                                return (text1 + "petnaest tisu\u0107a ");
                            }
                        case 6:
                            {
                                return (text1 + "\u0161estnaest tisu\u0107a ");
                            }
                        case 7:
                            {
                                return (text1 + "sedamnaest tisu\u0107a ");
                            }
                        case 8:
                            {
                                return (text1 + "osamnaest tisu\u0107a ");
                            }
                        case 9:
                            {
                                return (text1 + "devetnaest tisu\u0107a ");
                            }
                    }
                    return "";
                }
                if ((broj % 10) == 1)
                {
                    return (text1 + text2 + "jedna tisu\u0107a ");
                }
                if ((broj % 10) == 2)
                {
                    return (text1 + text2 + "dvije tisu\u0107e ");
                }
                if (((broj % 10) == 3) || ((broj % 10) == 4))
                {
                    return (text1 + text2 + text3 + " tisu\u0107e ");
                }
                if ((text1.Equals("") && text2.Equals("")) && text3.Equals(""))
                {
                    return "";
                }
                return (text1 + text2 + text3 + " tisu\u0107a ");
            }
            if (pozicija != 2)
            {
                return "milijarde...";
            }
            if (((broj % 100) / 10) != 1)
            {
                if ((broj % 10) == 1)
                {
                    return (text1 + text2 + "jedan milijun ");
                }
                return (text1 + text2 + text3 + " milijuna ");
            }
            switch ((broj % 10))
            {
                case 0:
                    {
                        return (text1 + "deset milijuna ");
                    }
                case 1:
                    {
                        return (text1 + "jedanaest milijuna ");
                    }
                case 3:
                    {
                        return (text1 + "trinaest milijuna ");
                    }
                case 4:
                    {
                        return (text1 + "\u010detrnaest milijuna ");
                    }
                case 5:
                    {
                        return (text1 + "petnaest milijuna ");
                    }
                case 6:
                    {
                        return (text1 + "\u0161estnaest milijuna ");
                    }
                case 7:
                    {
                        return (text1 + "sedamnaest milijuna ");
                    }
                case 8:
                    {
                        return (text1 + "osamnaest milijuna ");
                    }
                case 9:
                    {
                        return (text1 + "devetnaest milijuna ");
                    }
            }
            return "";
        }


    }
}