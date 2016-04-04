using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace migration
{
    public class justin : destinParent
    {
        public override string Down()
        {
            return "unfuck justin";
        }

        public override string Up()
        {
            return "fuck justin";
        }
    }

    public class destin : destinParent
    {
        public override string Down()
        {
            return "unfuck ethan";
        }

        public override string Up()
        {
            return "fuck ethan";
        }
    }

    public abstract class destinParent
    {
        public abstract string Up();
        public abstract string Down();
    }

}
