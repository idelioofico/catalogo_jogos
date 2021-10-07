using System;

namespace catalogo_jogos.Exceptions
{
    public class AlreadyExistsException:Exception
    {
        public AlreadyExistsException():base("Already exists"){

        }
    }
}