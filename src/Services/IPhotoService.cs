using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wobble.src.Services
{
    public interface IPhotoService
    {
        FileStream Get(string filename);
    }
}