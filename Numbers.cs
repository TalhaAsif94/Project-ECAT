using System;


namespace Talha
{
    enum Base
    {
        Binary, Decimal, Hexadecimal, Octal
    }


    class Numbers
    {
        ///Data
        double number;
        Base Nbase;



        ///Operators
        //Addition
        public static Numbers operator +(Numbers Num1, Numbers Num2)
        {
            Numbers result;
            result = new Numbers();
            result.Nbase = Num1.Nbase;
            result.number = Num1.number + Num2.number;
            return result;
        }


        //Multiplication
        public static Numbers operator *(Numbers Num1, Numbers Num2)
        {
            Numbers result;
            result = new Numbers();
            result.Nbase = Num1.Nbase;
            result.number = Num1.number * Num2.number;
            return result;
        }


        //Division
        public static Numbers operator /(Numbers Num1, Numbers Num2)
        {
            Numbers result;
            result = new Numbers();
            result.Nbase = Num1.Nbase;
            result.number = Num1.number / Num2.number;
            return result;
        }



        ///Private Conversions
        //Converts From Decimal To Binary
        string ToBinary()
        {
            var values = number.ToString().Split('.');
            uint Inum = uint.Parse(values[0]), rem;
            string result = null, temp = null;
            double Fnum = Math.Abs(number) - Convert.ToDouble(Inum);


            //Converts Integer Part To Binary
            while (Inum > 1)
            {
                rem = Inum % 2;
                Inum /= 2;
                temp += Convert.ToString(Convert.ToChar(rem + '0'));
            }
            temp += Convert.ToString(Convert.ToChar(Inum + '0'));
            for (ushort i = 0; i < temp.Length; i++)
                result += temp[temp.Length - 1 - i].ToString();
            temp = ".";


            //Converts Fractional Part To Binary
            for (ushort i = 0; i < 8 && values.Length == 2; i++)
            {
                Fnum *= 2;
                values = Fnum.ToString().Split('.');
                Inum = uint.Parse(values[0]);
                Fnum = Math.Abs(Fnum) - Convert.ToDouble(Inum);
                temp += Convert.ToString(Convert.ToChar(Inum + '0'));
            }
            result += temp;


            return result;
        }


        //Converts To Decimal Number
        static double ToDecimal(string number, Base @base)
        {
            ushort count = 0;
            double result = 0.0;

            for (ushort i = 0; i < number.Length; i++)
            {
                if (number[i] == '.')
                {
                    count = i;
                    break;
                }
            }


            switch(@base)
            {
                case Base.Binary:
                    if (count == 0)
                    {
                        for (ushort i = 0; i < number.Length; i++)
                            result += Convert.ToDouble(number[i].ToString()) * Math.Pow(2, number.Length - 1 - i);
                    }
                    else
                    {
                        for (ushort i = 0; i < count; i++)
                            result += Convert.ToDouble(number[i].ToString()) * Math.Pow(2, count - 1 - i);
                        for (ushort i = ++count, j = 1; i < number.Length; i++, j++)
                            result += Convert.ToDouble(number[i].ToString()) * Math.Pow(2, -j);
                    }
                    break;


                case Base.Octal:
                    if (count == 0)
                    {
                        for (ushort i = 0; i < number.Length; i++)
                            result += Convert.ToDouble(number[i].ToString()) * Math.Pow(8, number.Length - 1 - i);
                    }
                    else
                    {
                        for (ushort i = 0; i < count; i++)
                            result += Convert.ToDouble(number[i].ToString()) * Math.Pow(8, count - 1 - i);
                        for (ushort i = ++count, j = 1; i < number.Length; i++, j++)
                            result += Convert.ToDouble(number[i].ToString()) * Math.Pow(8, -j);
                    }
                    break;


                case Base.Hexadecimal:
                    if (count == 0)
                    {
                        for (ushort i = 0; i < number.Length; i++)
                        {
                            if (number[i] >= 'A' && number[i] <= 'F')
                                result += Convert.ToDouble(number[i] - 'A' + 10) * Math.Pow(16, number.Length - 1 - i);
                            else
                                result += Convert.ToDouble(number[i].ToString()) * Math.Pow(16, number.Length - 1 - i);
                        }
                    }
                    else
                    {
                        for (ushort i = 0; i < count; i++)
                        {
                            if (number[i] >= 'A' && number[i] <= 'F')
                                result += Convert.ToDouble(number[i] - 'A' + 10) * Math.Pow(16, count - 1 - i);
                            else
                                result += Convert.ToDouble(number[i].ToString()) * Math.Pow(16, count - 1 - i);
                        }
                        for (ushort i = ++count, j = 1; i < number.Length; i++, j++)
                        {
                            if (number[i] >= 'A' && number[i] <= 'F')
                                result += Convert.ToDouble(number[i] - 'A' + 10) * Math.Pow(16, -j);
                            else
                                result += Convert.ToDouble(number[i].ToString()) * Math.Pow(16, -j);
                        }
                    }
                    break;


                default:
                    result = Convert.ToDouble(number);
                    break;
            }


            return result;
        }


        //Converts From Decimal To Octal
        string ToOctal()
        {
            var values = number.ToString().Split('.');
            uint Inum = uint.Parse(values[0]), rem;
            string result = null, temp = null;
            double Fnum = Math.Abs(number) - Convert.ToDouble(Inum);


            //Converts Integer Part To Octal
            while (Inum > 1)
            {
                rem = Inum % 8;
                Inum /= 8;
                temp += Convert.ToString(Convert.ToChar(rem + '0'));
            }
            temp += Convert.ToString(Convert.ToChar(Inum + '0'));
            for (ushort i = 0; i < temp.Length; i++)
                result += temp[temp.Length - 1 - i].ToString();
            temp = ".";


            //Converts Fractional Part To Octal
            for (ushort i = 0; i < 8 && values.Length == 2; i++)
            {
                Fnum *= 8;
                values = Fnum.ToString().Split('.');
                Inum = uint.Parse(values[0]);
                Fnum = Math.Abs(Fnum) - Convert.ToDouble(Inum);
                temp += Convert.ToString(Convert.ToChar(Inum + '0'));
            }
            result += temp;


            return result;
        }


        //Converts From Decimal To Hexadecimal
        string ToHexadecimal()
        {
            var values = number.ToString().Split('.');
            uint Inum = uint.Parse(values[0]), rem;
            string result = null, temp = null;
            double Fnum = Math.Abs(number) - Convert.ToDouble(Inum);


            //Converts Integer Part To Hexadecimal
            while (Inum > 1)
            {
                rem = Inum % 16;
                Inum /= 16;
                if (rem < 10)
                    temp += Convert.ToString(Convert.ToChar(rem + '0'));
                else
                    temp += Convert.ToString(Convert.ToChar(rem - 10 + 'A'));
            }
            if (Inum < 10)
                temp += Convert.ToString(Convert.ToChar(Inum + '0'));
            else
                temp += Convert.ToString(Convert.ToChar(Inum - 10 + 'A'));
            for (ushort i = 0; i < temp.Length; i++)
                result += temp[temp.Length - 1 - i].ToString();
            temp = ".";


            //Converts Fractional Part To Hexadecimal
            for (ushort i = 0; i < 8 && values.Length == 2; i++)
            {
                Fnum *= 16;
                values = Fnum.ToString().Split('.');
                Inum = uint.Parse(values[0]);
                Fnum = Math.Abs(Fnum) - Convert.ToDouble(Inum);
                if (Inum < 10)
                    temp += Convert.ToString(Convert.ToChar(Inum + '0'));
                else
                    temp += Convert.ToString(Convert.ToChar(Inum - 10 + 'A'));
            }
            result += temp;


            return result;
        }



        ///Public Static Members
        //Divides Number By 100
        public static Numbers Percentage(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = num.number / 100;
            result.Nbase = num.Nbase;
            return result;
        }


        //Factorial Of A Number
        public static Numbers Factorial(Numbers num)
        {
            Numbers result = new Numbers();
            result.Nbase = num.Nbase;
            //Rounds Off The Number
            int var = Convert.ToInt32(num.number);
            result.number = 1.0;
            for (int i = 2; i <= var; i++)
                result.number *= Convert.ToDouble(i);
            return result;
        }


        //Finds The Nth Power Of A Number
        public static Numbers Power(Numbers num, Numbers exponent)
        {
            Numbers result = new Numbers();
            result.number = Math.Pow(num.number, exponent.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Exponential Raised To A Power
        public static Numbers Exponential(Numbers exponent)
        {
            Numbers result = new Numbers();
            result.number = Math.Exp(exponent.number);
            result.Nbase = exponent.Nbase;
            return result;
        }


        //Finds The Logarithm Of A Number To A Base
        public static Numbers Logarithm(Numbers num, Numbers nbase)
        {
            Numbers result = new Numbers();
            result.number = Math.Log10(num.number) / Math.Log10(nbase.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Natural Logarithm Of A Number
        public static Numbers NaturalLogarithm(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Log(num.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Sine Of The Angle
        public static Numbers Sine(Numbers angle)
        {
            Numbers result = new Numbers();
            result.number = Math.Sin(angle.number);
            result.Nbase = angle.Nbase;
            return result;
        }


        //Finds The Hyperbolic Sine Of The Angle
        public static Numbers Sineh(Numbers angle)
        {
            Numbers result = new Numbers();
            result.number = Math.Sinh(angle.number);
            result.Nbase = angle.Nbase;
            return result;
        }


        //Finds The Cosine Of The Angle
        public static Numbers Cosine(Numbers angle)
        {
            Numbers result = new Numbers();
            result.number = Math.Cos(angle.number);
            result.Nbase = angle.Nbase;
            return result;
        }


        //Finds The Hyperbolic Cosine Of The Angle
        public static Numbers Cosineh(Numbers angle)
        {
            Numbers result = new Numbers();
            result.number = Math.Cosh(angle.number);
            result.Nbase = angle.Nbase;
            return result;
        }


        //Finds The Tangent Of The Angle
        public static Numbers Tangent(Numbers angle)
        {
            Numbers result = new Numbers();
            result.number = Math.Tan(angle.number);
            result.Nbase = angle.Nbase;
            return result;
        }


        //Finds The Hyperbolic Tangent Of The Angle
        public static Numbers Tangenth(Numbers angle)
        {
            Numbers result = new Numbers();
            result.number = Math.Tanh(angle.number);
            result.Nbase = angle.Nbase;
            return result;
        }


        //Finds The Arc Sine Of The Number
        public static Numbers ArcSine(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Asin(num.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Hyperbolic Arc Sine Of The Number
        public static Numbers ArcSineh(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Asinh(num.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Arc Cosine Of The Number
        public static Numbers ArcCosine(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Acos(num.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Hyperbolic Arc Cosine Of The Number
        public static Numbers ArcCosineh(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Acosh(num.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Arc Tangent Of The Number
        public static Numbers ArcTangent(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Atan(num.number);
            result.Nbase = num.Nbase;
            return result;
        }


        //Finds The Hyperbolic Arc Cosine Of The Number
        public static Numbers ArcTangenth(Numbers num)
        {
            Numbers result = new Numbers();
            result.number = Math.Atanh(num.number);
            result.Nbase = num.Nbase;
            return result;
        }



        ///Public Members
        //Default Constructor
        public Numbers()
        {
            number = 0;
            Nbase = Base.Decimal;
        }


        //Parameterized Constructor
        public Numbers(string num, Base @base)
        {
            if (num[0] == '$')
            {
                num = num.Remove(0, 1);
                number = Numbers.ToDecimal(num, @base);
                Nbase = @base;
                Negate();
            }
            else
            {
                number = Numbers.ToDecimal(num, @base);
                Nbase = @base;
            }
        }


        //Sets The Number
        public void Setnumber(string num, Base @base)
        {
            if (num[0] == '$')
            {
                num = num.Remove(0, 1);
                number = Numbers.ToDecimal(num, @base);
                Nbase = @base;
                Negate();
            }
            else
            {
                number = Numbers.ToDecimal(num, @base);
                Nbase = @base;
            }
        }


        //Returns The Number In String Format
        public string Getnumber()
        {
            string result;
            if (number == Math.Abs(number))
            {
                switch (Nbase)
                {
                    case Base.Binary:
                        result = ToBinary();
                        break;
                    case Base.Hexadecimal:
                        result = ToHexadecimal();
                        break;
                    case Base.Octal:
                        result = ToOctal();
                        break;
                    default:
                        result = Convert.ToString(number);
                        break;
                }
            }
            else
            {
                number *= -1.0;
                result = "$";
                switch (Nbase)
                {
                    case Base.Binary:
                        result += ToBinary();
                        break;
                    case Base.Hexadecimal:
                        result += ToHexadecimal();
                        break;
                    case Base.Octal:
                        result += ToOctal();
                        break;
                    default:
                        result += Convert.ToString(number);
                        break;
                }
                number *= -1.0;
            }
            return result;
        }


        //Negates A Number
        public void Negate() { number *= -1; }
    }
}
