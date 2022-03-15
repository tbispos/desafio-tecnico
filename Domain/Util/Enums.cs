using System;
using System.ComponentModel;

namespace Domain.Util
{
    public class Enums
    {

        [Serializable()]
        public enum ListaStatus
        {
            [Description("Para Fazer")]
            ToDo = 0,
            [Description("Fazendo")]
            Doing = 1,
            [Description("Finalizado")]
            Done = 2
        }
    }
}
