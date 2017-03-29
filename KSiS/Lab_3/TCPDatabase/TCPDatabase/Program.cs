﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Command;
using Database;
using Newtonsoft.Json;
using System.Reflection;
using Database;

namespace TCPDatabase
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var db = new Database.Database();
            var registry = new HandlersRegistry();

            registry.Reg(new AddGood().GetType(), new AddGoodCommandHandler(db));
            registry.Reg(new AddCategory().GetType(), new AddCategoryCommandHandler(db));
            registry.Reg(new AddUser().GetType(), new AddUserCommandHandler(db));

            registry.Reg(new RemoveGood().GetType(), new RemoveGoodCommandHandler(db));
            registry.Reg(new RemoveCategory().GetType(), new RemoveCategoryCommandHandler(db));
            registry.Reg(new RemoveUser().GetType(), new RemoveUserCommandHandler(db));

            registry.Reg(new GetData().GetType(), new GetDataCommandHandler(db));

            registry.RegDefault(new DefaultCommandHandler(db));

            var tcpServer = new TcpServer(17777, registry, new Serializer.Serializer());
            Console.ReadKey();
            tcpServer.EndAccepting();
        }
    }
}