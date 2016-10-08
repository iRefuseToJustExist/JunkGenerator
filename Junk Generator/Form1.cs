using Junk_Generator.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Junk_Generator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public string base1 = @"public class %class%{";
        public string voidbase = @"public void %void%(){
//junk
}";
        Random random = new Random();
        public string rands(int length)
        {
            const string chars = @"abcdefghijklmnopqstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string k = new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());

            return k;
        }
        public string[] intchoose = new string[]
      {
            @"%variable% += %rand_%;" ,
            @"%variable% = %rand_%;" ,
            @"%variable% = %variable% + %rand_%;"

      };
        public string[] intfuncs = new string[]
        {
            @"while(%variable% == %var_val%){
%intchoose%
}" ,
            @"if(%variable% == %rand_%){
%intchoose%
}"
        };
        public string[] random_func = new string[]
        {
            @"",
            @"",
            @"Console.Write(%variable%.ToString());",
            @"Console.WriteLine(%variable%.ToString());",
            @"MessageBox.Show(%variable%.ToString());",
            @"try{
Console.WriteLine(%variable%.ToString());
}catch(Exception ex){
Console.WriteLine(ex.Message);
}",
                      @"try{
MessageBox.Show(%variable%.ToString());
}catch(Exception ex){
MessageBox.Show(ex.Message);
}" ,
@"Console.ReadKey();" ,
@"Console.ReadLine();" ,
@"object %randv%;
%randv% = %rand%;",
@"for( ; ;) {
Console.WriteLine(%rand%);
}" ,
@"int? %randv% = %randint%;
%randv% += %randint2%;" ,
@" bool? %randv% = new bool?();
%randv% = true;" ,
@"object %randv%;
%randv% = %rand%;
Console.WriteLine(%randv%.ToString().ToLower());" ,
@"try{
int %randv% = %randint%;
if(%randv% == %randint2%){
%randv%++;
}else{
%randv%--;
}
}catch(Exception ex){
MessageBox.Show(ex.Message);
}" ,
@"try{
int %randv% = %randint%;
if(%randv% == %randint2%){
%randv%++;
}else{
%randv%--;
Console.Write(%randv%.ToString());
}
}catch(Exception ex){
MessageBox.Show(ex.Message);
}" ,
@"int[] %randv% = { %randint% , %randint2% } ;
Random %randv2%= new Random();
Console.WriteLine(%randv%[%randv2%.Next(0,2)]);"


        };
        public string[] doublechoose = new string[]
        {
            @"%variable% = Math.Pow(double.MinValue, double.MaxValue);",
@"%variable% = Math.Pow(2, 2.1);",
@"%variable% = Math.Pow(double.NegativeInfinity, 2);",
@"%variable% = Math.Pow(5, 2);",
@"%variable% = Math.Floor(%rand%);",
@"double %randv% = %rand%;
%variable% = Math.Round(%randv%);",
@"double %randv% = %rand%;
%variable% = Math.Round(%randv% ,1,MidpointRounding.ToEven);",
@"double %randv% = %rand%;
%variable% = Math.Floor(%randv%);",
@"double %randv% = %rand%;
%variable% = Math.Ceiling(%randv%);",
@"%variable% = Math.Ceiling(Math.Acos(0));",
@"%variable% = Math.Ceiling(Math.Cos(2));",
@"%variable% = Math.Ceiling(Math.Cosh(5));",
@"%variable% = Math.Ceiling(Math.Asin(0.2));",
@"%variable% = Math.Ceiling(Math.Sin(2));",
@"%variable% = Math.Ceiling(Math.Sinh(-5));",
@"%variable% = Math.Ceiling(Math.Atan(-5));",
@"%variable% = Math.Ceiling(Math.Tan(1));",
@"%variable% = Math.Ceiling(Math.Tanh(0.1));",
@"double %randv% = Math.IEEERemainder(3, 4);
%variable% = %randv%;",
@"double %randv% = Math.Log(1000, 10);
%variable% = %randv%;",
@"double %randv% = %rand%;
%variable% = %randv% / 3;",
@"double %randv% = %rand%;
%variable% = %randv% * 2;",
@"%variable% = Math.Exp(2);",
@"%variable% = Math.Truncate(%variable%);",
@"%variable% = Math.Sqrt(4);",
@"double %randv% = %rand%;
%randv% = Math.Sqrt(3);
%variable% = %randv%;"
        };
        public string[] doublefuncs_ = new string[]
      {
            @"if(%variable% == %rand_%){
%choose%
%dostuff%
}",
            @"while(%variable% == %rand_%){
%choose%
%dostuff%
}",
            @"%choose%
%dostuff%"
      };
        public enum VarType
        {
            None,
            String,
            Int,
            Uint,
            Ushort,
            Short,
            Byte,
            Sbyte,
            Float,
            Double,
            Long,
            Ulong
        };
        public int get_int()
        {
            int id2 = random.Next(0, 5);
            int variable_value_i = 0;
            if (id2 == 0)
            {
                variable_value_i = random.Next(1, 99);
            }
            else if (id2 == 1)
            {
                variable_value_i = random.Next(1, 9999);
            }
            else if (id2 == 2)
            {
                variable_value_i = random.Next(1, 999999);
            }
            else if (id2 == 3)
            {
                variable_value_i = random.Next(1, 99999999);
            }
            else if (id2 == 4)
            {
                variable_value_i = random.Next(1, 999999999);
            }
            return variable_value_i;
        }
        long LongRandom(long min, long max, Random rand)
        {
            byte[] buf = new byte[8];
            rand.NextBytes(buf);
            long longRand = BitConverter.ToInt64(buf, 0);
            return (Math.Abs(longRand % (max - min)) + min);
        }
        static float NextFloat(Random random)
        {
            double mantissa = (random.NextDouble() * 2.0) - 1.0;
            double exponent = Math.Pow(2.0, random.Next(-126, 128));
            return (float)(mantissa * exponent);
        }
        public string make_vars()
        {
            string data = "";

  
            int vars = Convert.ToInt32(variable.Value);
            string[] variables = new string[vars];
            string[] variable_value_s = new string[vars];
            int[] variable_value_i = new int[vars];
            long[] variable_value_l = new long[vars];
            float[] variable_value_f = new float[vars];
            int[] fag = new int[vars]; 
            VarType currvar = VarType.None;
            foreach (int i in fag)
            {

                string local_string = "";
               int id = random.Next(0, 11);
              
                if (id == 0)
                {
                    local_string = "string %rand% = \"%string%\"; \n";
                }
                else if (id == 1)
                {
                    local_string = "sbyte %rand% =  %sbyte%; \n";
                }
                else if (id == 2)
                {
                    local_string = "byte %rand% =  %byte%; \n";
                }
                else if (id == 3)
                {
                    local_string = "short %rand% = %short%; \n";
                }
                else if (id == 4)
                {
                    local_string = "ushort %rand% = %ushort%; \n";
                }
                else if (id == 5)
                {
                    local_string = "uint %rand% = %uint%; \n";
                }
                else if (id == 6)
                {
                    local_string = "int %rand% = %int%; \n";
                }
                else if (id == 7)
                {
                    local_string = "long %rand% = %long%; \n";
                }
                else if (id == 8)
                {
                    local_string = "ulong %rand% = %ulong%; \n";
                }
                else if (id == 9)
                {
                    local_string = "float %rand% = %float%*; \n";
                }
                else if (id == 10)
                {
                    local_string = "double %rand% = %double%; \n";
                }

                int minx = Convert.ToInt32(min.Value);
                int maxx = Convert.ToInt32(max.Value);
                variables[i] = rands(random.Next(minx, maxx));


                local_string = local_string.Replace("%rand%", variables[i]);
                if (local_string.Contains("%string%"))
                {

                    variable_value_s[i] = rands(random.Next(minx, maxx));
                    local_string = local_string.Replace("%string%", variable_value_s[i]);
                    currvar = VarType.String;
                }
                else if (local_string.Contains("%sbyte%"))
                {
                    variable_value_i[i] = random.Next(-128, 127);
                    local_string = local_string.Replace("%sbyte%", variable_value_i[i].ToString());
                    currvar = VarType.Sbyte;
                }
                else if (local_string.Contains("%byte%"))
                {
                    variable_value_i[i] = random.Next(0, 255);
                    local_string = local_string.Replace("%byte%", variable_value_i[i].ToString());
                    currvar = VarType.Byte;
                }
                else if (local_string.Contains("%short%"))
                {
                    variable_value_i[i] = random.Next(-32768, 32767);
                    local_string = local_string.Replace("%short%", variable_value_i[i].ToString());
                    currvar = VarType.Short;
                }
                else if (local_string.Contains("%ushort%"))
                {
                    variable_value_i[i] = random.Next(0, 65535);
                    local_string = local_string.Replace("%ushort%", variable_value_i[i].ToString());
                    currvar = VarType.Ushort;
                }
                else if (local_string.Contains("%uint%"))
                {
                    variable_value_i[i] = get_int();
                    local_string = local_string.Replace("%uint%", variable_value_i[i].ToString());
                    currvar = VarType.Uint;
                }
                else if (local_string.Contains("%int%"))
                {

                    variable_value_i[i] = get_int();
                    local_string = local_string.Replace("%int%", variable_value_i[i].ToString());
                    currvar = VarType.Int;
                }
                else if (local_string.Contains("%long%"))
                {

                    variable_value_l[i] = LongRandom(1, 90000000000000050, random);
                    local_string = local_string.Replace("%long%", variable_value_l[i].ToString());
                    currvar = VarType.Long;
                }
                else if (local_string.Contains("%ulong%"))
                {

                    variable_value_l[i] = LongRandom(1, 90000000000000050, random);
                    local_string = local_string.Replace("%ulong%", variable_value_l[i].ToString());
                    currvar = VarType.Ulong;
                }
                else if (local_string.Contains("%float%"))
                {

                    variable_value_f[i] = NextFloat(random);
                    local_string = local_string.Replace("%float%", variable_value_f[i].ToString());
                    local_string = local_string.Replace(",", ".");
                    local_string = local_string.Replace("*", "F");
                    currvar = VarType.Float;
                }
                else if (local_string.Contains("%double%"))
                {

                    variable_value_f[i] = NextFloat(random);
                    local_string = local_string.Replace("%double%", variable_value_f[i].ToString());
                    local_string = local_string.Replace(",", ".");
                    currvar = VarType.Double;
                }
                else
                {
                    MessageBox.Show("Unknown type!");
                }
                if (currvar != VarType.None)
                {
                    data += local_string;
                }
                if (currvar == VarType.Double && currvar != VarType.None)
                {

                    string doublefunc = doublefuncs_[random.Next(0, doublefuncs_.Length)];
                    doublefunc = doublefunc.Replace("%variable%", variables[i]);
                    string rand = NextFloat(random).ToString();
                    rand = rand.Replace(',', '.');
                    string rand2 = NextFloat(random).ToString();
                    rand2 = rand2.Replace(',', '.');
                    doublefunc = doublefunc.Replace("%rand_%", rand);

                    string double_ = doublechoose[random.Next(0, doublechoose.Length)];
                    double_ = double_.Replace("%variable%", variables[i]);
                    double_ = double_.Replace("%randv%", rands(random.Next(5, 30)));
                    double_ = double_.Replace("%rand%", rand2);
                    doublefunc = doublefunc.Replace("%choose%", double_);

                    string rand3 = NextFloat(random).ToString();
                    rand3 = rand3.Replace(',', '.');
                    string doublez = random_func[random.Next(0, random_func.Length)];
                    doublez = doublez.Replace("%variable%", variables[i]);
                    doublez = doublez.Replace("%randv%", rands(random.Next(5, 30)));
                    doublez = doublez.Replace("%randv2%", rands(random.Next(5, 30)));
                    doublez = doublez.Replace("%rand%", rand3);
                    doublez = doublez.Replace("%randint%", random.Next(1, 9999999).ToString());
                    doublez = doublez.Replace("%randint2%", random.Next(1, 99999).ToString());
                    doublefunc = doublefunc.Replace("%dostuff%", doublez);
                    data += doublefunc;

                }
                if (currvar == VarType.Int && currvar != VarType.None)
                {

                    string intfuncz = intfuncs[random.Next(0, 2)];
                    intfuncz = intfuncz.Replace("%variable%", variables[i]);

                    string intfunc = intchoose[random.Next(0, 3)];
                    intfuncz = intfuncz.Replace("%rand_%", random.Next(1, 999999).ToString());
                    intfunc = intfunc.Replace("%variable%", variables[i]);
                    intfunc = intfunc.Replace("%rand_%", random.Next(1, 999999).ToString());
                    intfuncz = intfuncz.Replace("%intchoose%", intfunc);
                    intfuncz = intfuncz.Replace("%var_val%", variable_value_i[i].ToString());
                    data += intfuncz;
                }



            }
          
            return data;
        }
        public string make_void()
        {
            string base_ = voidbase;
            int minx = Convert.ToInt32(min.Value);
            int maxx = Convert.ToInt32(max.Value);
            
            string voidname = rands(random.Next(minx, maxx));
            base_ = base_.Replace("%void%", voidname);
            base_ = base_.Replace("//junk", make_vars());

            return base_;
        }
        public string make_class()
        {
            string base_ = base1;
            int minx = Convert.ToInt32(min.Value);
            int maxx = Convert.ToInt32(max.Value);
         
            string classname = rands(random.Next(minx, maxx));
            base_ = base_.Replace("%class%", classname);
            for (int i = 0; i < functions.Value; i++)
            {
                base_ += make_void();
            }
            base_ += "\n} ";
            return base_;
        }
        public string curr_junk = "";
        public void construct()
        {
            string junk = "";

            for (int i = 0; i < classes.Value; i++)
            {
                junk += make_class();
            }
            curr_junk = junk;

            MessageBox.Show("Done!");
            richTextBox1.Text = curr_junk;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            construct();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
           
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, curr_junk);
        }
    }
   
}
