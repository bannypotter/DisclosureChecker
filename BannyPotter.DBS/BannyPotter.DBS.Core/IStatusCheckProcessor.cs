using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BannyPotter.DBS.Core
{
    public interface IStatusCheckProcessor
    {
        StatusCheckResponse Check(StatusCheckRequest request);
    }
}
