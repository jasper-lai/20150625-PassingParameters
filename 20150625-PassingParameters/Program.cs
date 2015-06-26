using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20150625_PassingParameters
{
    /// <summary>
    /// 用以測試傳遞物件的狀況
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string GetString()
        {
            return String.Concat("Id: ", this.Id, "  Name: ", this.Name);
        }
    }

    /// <summary>
    /// Console 主程式
    /// </summary>
    class Program
    {
        #region 字串參數傳遞問題重現
        private static void Change(string inStr)
        {
            inStr = "DEF";
            Console.WriteLine("[Change] inStr={0}", inStr);
        }

        private static void ChangeByRef(ref string inStr)
        {
            inStr = "DEF";
            Console.WriteLine("[ChangeByRef] inStr={0}", inStr);
        }
        #endregion

        #region ValueType 呼叫
        private static void ValueTypeCall(int inId)			//##1.2##
        {
            inId = 10;		//##1.3##
            Console.WriteLine("[ValueTypeCall] id={0}", inId);
        }

        private static void ValueTypeCallByRef(ref int inId)		//##2.2##
        {
            inId = 10;	//##2.3##
            Console.WriteLine("[ValueTypeCallByRef] id={0}", inId);
        }
        #endregion

        #region StringType 呼叫
        private static void StringTypeCall(string inStr)		//##3.2##
        {
            inStr = "DEF";		//##3.3##
            Console.WriteLine("[StringTypeCall] inStr={0}", inStr);
        }

        private static void StringTypeCallByRef(ref string inStr)		//##4.2##
        {
            inStr = "DEF";		//##4.3##
            Console.WriteLine("[StringTypeCallByRef] inStr={0}", inStr);
        }
        #endregion

        #region ObjectType 呼叫
        private static void ObjectTypeCall(Customer inCust)	//##5.2##
        {
            inCust.Name = "Jasper";		//##5.3##
            Console.WriteLine("[ObjectTypeCall] Id={0}, Name={1}", inCust.Id, inCust.Name);
        }

        private static void ObjectTypeCall(ref Customer inCust)	//##6.2##
        {
            inCust.Name = "Jasper";		//##6.3##
            Console.WriteLine("[ObjectTypeCall] Id={0}, Name={1}", inCust.Id, inCust.Name);
        }
        #endregion

        static void Main(string[] args)
        {

            //=======================================
            //字串參數傳遞問題重現 測試: 
            //=======================================
            string strX = "ABC";

            //呼叫 Change
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("[Main](before call Change()) strX={0}", strX);
            Change(strX);
            Console.WriteLine("[Main](after call Change()) strX={0}", strX);

            //呼叫 ChangeByRef
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("[Main](before call ChangeByRef()) strX={0}", strX);
            ChangeByRef(ref strX);
            Console.WriteLine("[Main](after call ChangeByRef()) strX={0}", strX);

            //=======================================
            //Value Type 測試: 
            //=======================================
            int id = 1;		//##1.1##
            //呼叫 ValueTypeCall
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[Main](before call ValueTypeCall()) id={0}", id);
            ValueTypeCall(id);
            Console.WriteLine("[Main](after call ValueTypeCall()) id={0}", id);		//##1.4##

            //呼叫 ValueTypeCallByRef
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[Main](before call ValueTypeCallByRef()) id={0}", id);
            ValueTypeCallByRef(ref id);
            Console.WriteLine("[Main](after call ValueTypeCallByRef()) id={0}", id);	//##2.4##

            //=======================================
            //Reference Type 測試:  (String)
            //=======================================
            string str = "ABC";			//##3.1##
            //呼叫 StringTypeCall
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("[Main](before call StringTypeCall()) str={0}", str);
            StringTypeCall(str);
            Console.WriteLine("[Main](after call StringTypeCall()) str={0}", str);		//##3.4##

            //呼叫 StringTypeCallByRef
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("[Main](before call StringTypeCallByRef()) str={0}", str);
            StringTypeCallByRef(ref str);
            Console.WriteLine("[Main](after call StringTypeCallByRef()) str={0}", str);	//##4.4##

            //=======================================
            //Reference Type 測試:  (Object)
            //=======================================
            //呼叫 ObjectTypeCall
            Console.ForegroundColor = ConsoleColor.Yellow;
            Customer cust = new Customer { Id = 1, Name = "Tester" };		//##5.1##
            Console.WriteLine("[Main](before call ObjectTypeCall()) Id={0}, Name={1}", cust.Id, cust.Name);
            ObjectTypeCall(cust);
            Console.WriteLine("[Main](after call ObjectTypeCall()) Id={0}, Name={1}", cust.Id, cust.Name);	//##5.4##

            //呼叫 ObjectTypeCallByRef
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            cust = new Customer { Id = 1, Name = "Tester" };		//##6.1##
            Console.WriteLine("[Main](before call ObjectTypeCallByRef()) Id={0}, Name={1}", cust.Id, cust.Name);
            ObjectTypeCall(ref cust);
            Console.WriteLine("[Main](after call ObjectTypeCallByRef()) Id={0}, Name={1}", cust.Id, cust.Name);	//##6.4##

            Console.ReadLine();
        }

    }

}
