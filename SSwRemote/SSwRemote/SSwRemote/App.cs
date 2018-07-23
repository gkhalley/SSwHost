using System;
using SSwRemote.Helpers;
using SSwRemote.Models;
using SSwRemote.Services;

namespace SSwRemote
{
    public class App
    {

        public static void Initialize()
        {
            ServiceLocator.Instance.Register<IDataStore<Item>, MockDataStore>();
        }
    }
}
