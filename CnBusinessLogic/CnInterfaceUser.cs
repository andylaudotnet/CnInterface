using System;
using System.Collections.Generic;
using System.Text;
using CnDataAcess;

namespace CnBusinessLogic
{
    public class CnInterfaceUser
    {
        public static int GetUserLevel(string username)
        {
            return ObjectCreate.CreateInterfaceUser().GetUserLevel(username);
        }
    }
}
