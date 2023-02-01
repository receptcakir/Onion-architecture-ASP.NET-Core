using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GOAL.Application.Abstractions.Services
{
    public interface IQRCodeService
    {
        byte[] GenerateQRCode(string text);
    }
}
